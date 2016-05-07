﻿using System;
using System.Data.Common;
using System.Linq;

namespace EntityPlugin.RWSplitting.MasterSlaves
{
	/// <summary>
	/// 表示 EF 读写分离服务中实体数据库上下文对象所使用的主从读写分离配置上下文详情信息。
	/// </summary>
	public class DbMasterSlaveConfigContext : Disposable
    {
        private ApplyItemElement _applyItem;

        private bool _autoSwitchSlaveOnMasterFauled;
        private bool _autoSwitchMasterOnSlavesFauled;
        private bool _slaveRandomization;
        private int _serverStateScanInterval;
        private bool _serverStateScanWithNonOffline;
        private Type _targetContextType;

        private DbMasterServer _master;
        private DbSlaveServerCollection _slaves;

        private DbServerStateScanner _scanner;

        /// <summary>
        /// 初始化类型 <see cref="DbMasterSlaveConfigContext"/> 的新实例。
        /// </summary>
        private DbMasterSlaveConfigContext()
        {
			Disposing += MasterSlaveContextConfig_Disposing;
        }

		/// <summary>
		/// 以指定的 <see cref="ApplyItemSection"/> 配置信息初始化类型 <see cref="DbMasterSlaveConfigContext"/> 的新实例。
		/// </summary>
		/// <param name="applyItem"></param>
		internal DbMasterSlaveConfigContext(ApplyItemElement applyItem)
			: this()
		{
			if (applyItem == null)
				throw new ArgumentNullException(nameof(applyItem));

			_applyItem = applyItem;
			InitializeProperties();
		}

		/// <summary>
		/// 以指定目标 EF 实体数据库上下文类型初始化类型 <see cref="DbMasterSlaveConfigContext"/> 的新实例。
		/// </summary>
		/// <param name="targetContextType"></param>
		internal DbMasterSlaveConfigContext(Type targetContextType)
			: this(DbMasterSlaveConfig.DefaultInstance.GetApplyItem(targetContextType))
		{
		}

        /// <summary>
        /// 获取当前 EF 读写分离服务配置详情所使用的基础配置文件节信息。
        /// </summary>
        protected ApplyItemElement ApplyItemSection
		{
			get { return this._applyItem; }
		}

        /// <summary>
        /// 确定当前配置对象能否应用于指定的 EF 实体数据库上下文对象。
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool CanApplyTo(System.Data.Entity.DbContext context)
        {
            return this.ApplyItemSection.CanApplyTo(context);
        }

        /// <summary>
        /// 确定当前配置对象能否应用于指定的 EF 实体数据库上下文类型。
        /// </summary>
        /// <param name="contextType"></param>
        /// <returns></returns>
        public bool CanApplyTo(Type contextType)
        {
            return this.ApplyItemSection.CanApplyTo(contextType);
        }

        #region 从配置文件节中获取的相关配置属性

        /// <summary>
        /// 获取该 EF 读写分离服务配置详情中表示 Master 数据库的节点。
        /// </summary>
        protected internal DbMasterServer MasterServer
        {
            get { return this._master; }
        }

        /// <summary>
        /// 获取该 EF 读写分离服务配置详情中表示 Slave 数据库的节点集合。
        /// </summary>
        protected internal DbSlaveServerCollection SlaveServers
        {
            get { return this._slaves; }
        }

        /// <summary>
        /// 获取该 EF 读写分离服务配置详情中所有 State 属性状态值为 <see cref="DbServerState.Online"/> 的表示 Slave 数据库的节点集合。
        /// </summary>
        protected internal DbSlaveServer[] OnlineSlaveServers
        {
            get { return this.SlaveServers.Where(item => item.State == DbServerState.Online).ToArray(); }
        }


        /// <summary>
        /// 获取一个当前 EF 读写分离服务中可用的 Master 数据库连接字符串。
        /// <para>读取该属性值时，将首先判断 <see cref="MasterServer"/> 的 State 状态值是否为 <see cref="DbServerState.Offline"/>，如果是，将直接返回 <see cref="MasterServer"/> 所示的数据库连接字符串。</para>
        /// <para>如果 <see cref="MasterServer"/> 离线，则根据 <see cref="AutoSwitchSlaveOnMasterFauled"/> 属性参数的设定值获取 <see cref="OnlineSlaveServers"/> 中的第一个可用项。</para>
        /// </summary>
        public string UsableMasterConnectionString
        {
            get
            {
                if (this.MasterServer.State == DbServerState.Offline)
                {
                    if (!this.AutoSwitchSlaveOnMasterFauled)
                    {
                        throw new InvalidOperationException(string.Format("无法获取当前可用的 Master 数据库连接，因为 Master 连接配置所示的 {0} 对象 State 已经标记为 {1}，并且当前 EF 读写分离服务的配置项 {2} 值为 {3}。",
                               "MasterServer",
                               DbServerState.Offline,
                               "AutoSwitchSlaveOnMasterFauled",
                               this.AutoSwitchSlaveOnMasterFauled));
                    }
                    DbSlaveServer[] servers = this.OnlineSlaveServers;
                    if (servers.Length == 0)
                    {
                        throw new InvalidOperationException(string.Format("无法获取当前可用的 Master 数据库连接，因为 Master 连接配置所示的 {0} 对象 State 已经标记为 {1}，并且所有的 Slave 服务器节点也都处于不可用状态。",
                            "MasterServer",
                            DbServerState.Offline
                            ));
                    }
                    return servers[0].ConnectionString;
                }
                return this.MasterServer.ConnectionString;
            }
        }

        /// <summary>
        /// 获取一个当前 EF 读写分离服务中可用的 Slave 数据库连接字符串。
        /// <para>读取该属性值时，将首先判断 <see cref="OnlineSlaveServers"/> 属性中的可用连接数量；</para>
        /// <para>如果 <see cref="OnlineSlaveServers"/> 属性中存在可用连接，则根据 <see cref="SlaveRandomization"/> 属性参数的设定随机选择或者顺序选择其中的项返回。</para>
        /// <para>如果 <see cref="OnlineSlaveServers"/> 属性中不存在可用连接，则根据 <see cref="AutoSwitchMasterOnSlavesFauled"/> 属性参数的设定来获取 <see cref="MasterServer"/> 定义的数据库连接返回或抛出异常。</para>
        /// </summary>
        public string UsableSlaveConnectionString
        {
            get
            {
                if (this.MasterServer.State == DbServerState.Offline)
                    return this.UsableMasterConnectionString;

                DbSlaveServer[] slaves = this.OnlineSlaveServers;
                if (slaves.Length == 0)
                {
                    if (!this.AutoSwitchMasterOnSlavesFauled)
                    {
                        throw new InvalidOperationException(string.Format("无法获取当前可用的 Slave 数据库连接，因为当前 EF 读写分离服务配置中的所有 Slave 数据库节点的 State 均被检测为 {0}，且配置项 {1}（是否允许当所有的 Slave 服务器离线后自动将 Master 服务器节点作为 Slave 服务器使用） 的值定义为 {2}。",
                            DbServerState.Offline,
                            "AutoSwitchMasterOnSlavesFauled",
                            this.AutoSwitchMasterOnSlavesFauled));
                    }
                    if (this.MasterServer.State == DbServerState.Offline)
                    {
                        throw new InvalidOperationException(string.Format("无法获取当前可用的 Slave 数据库连接，因为当前 EF 读写分离配置中定义的所有 Slave 数据库节点和 Master 数据库节点的 State 均被检测为 {0} 状态。",
                            DbServerState.Offline));
                    }
                    return this.MasterServer.ConnectionString;
                }
                if (slaves.Length == 1 || !this.SlaveRandomization)
                    return slaves[0].ConnectionString;

                Random random = new Random(Guid.NewGuid().GetHashCode());
                return slaves[random.Next(slaves.Length)].ConnectionString;
            }
        }


        /// <summary>
        /// 表示 EF 读写分离服务配置环境中是否允许当 Master 服务器离线后自动将 Slave 服务器节点作为 Master 服务器使用。
        /// </summary>
        public bool AutoSwitchSlaveOnMasterFauled
        {
            get { return _autoSwitchSlaveOnMasterFauled; }
        }

        /// <summary>
        /// 表示 EF 读写分离服务配置环境中是否允许当所有的 Slave 服务器离线后自动将 Master 服务器节点作为 Slave 服务器使用。
        /// </summary>
        public bool AutoSwitchMasterOnSlavesFauled
        {
            get { return _autoSwitchMasterOnSlavesFauled; }
        }

        /// <summary>
        /// 表示 EF 读写分离服务配置环境中是否在每次执行 查询 请求时随机选择 <see cref="SlaveServers"/> 集合中的任意一台可用的 Slave 服务器节点作为查询服务器使用。
        /// </summary>
        public bool SlaveRandomization
        {
            get { return _slaveRandomization; }
        }


        /// <summary>
        /// 表示当 EF 读写分离服务配置环境中定义了多个数据库服务器节点时，系统轮询扫描检测每个数据库服务器节点在线状态的时间间隔。
        /// </summary>
        public int ServerStateScanInterval
        {
            get { return _serverStateScanInterval; }
        }

        /// <summary>
        /// 表示 EF 读写分离服务配置环境中是否在每次轮询扫描检测每个服务器节点可用状态时，是否排除检测已经标记为离线的数据库服务器节点。
        /// </summary>
        public bool ServerStateScanWithNonOffline
        {
            get { return _serverStateScanWithNonOffline; }
        }


        /// <summary>
        /// 获取该 <see cref="DbMasterSlaveConfigContext"/> 对象所表示的目标 EF 实体数据库上下文类型。
        /// </summary>
        public Type TargetContextType
        {
            get { return this._targetContextType; }
        }

        #endregion



        #region 数据库连接状态可用性轮询检测

        /// <summary>
        /// 在当前对象的属性 <see cref="ServerStateScanInterval"/> 值有效的情况下开启数据库连接状态可用性轮询检测功能。
        /// <param name="factory">该参数表示一个 ADO.NET 对象创建工厂，所用是定义如何来根据连接字符串创建每个数据库连接。</param>
        /// </summary>
        public void StartDbServersStateScanTaskIfNeed(DbProviderFactory factory)
        {
            if (this.ServerStateScanInterval <= 0)
                return;

            if (this._scanner == null)
                this._scanner = new DbServerStateScanner(this);

            this._scanner.StartScanTask(factory);
        }

        #endregion



        #region 在对象执行 Dispose 方法时进行资源释放

        private void MasterSlaveContextConfig_Disposing(object sender, EventArgs e)
        {
            if (this._scanner != null)
            {
                this._scanner.Dispose();
            }
        }

		#endregion

		#region 初始化对象的相关基础属性值

		private void InitializeProperties()
		{
			this._autoSwitchSlaveOnMasterFauled = this.ApplyItemSection.AutoSwitchSlaveOnMasterFauled;
			this._autoSwitchMasterOnSlavesFauled = this.ApplyItemSection.AutoSwitchMasterOnSlavesFauled;
			this._slaveRandomization = this.ApplyItemSection.SlaveRandomization;
			this._serverStateScanInterval = this.ApplyItemSection.ServerStateScanInterval;
			this._serverStateScanWithNonOffline = this.ApplyItemSection.ServerStateScanWithNonOffline;
			this._targetContextType = this.ApplyItemSection.TargetContextType;

			this.InitializeMasterServer(this.ApplyItemSection.MasterConnectionString);
			this.InitializeSlaveServers(this.ApplyItemSection.SlaveConnectionStrings);
		}

		private void InitializeMasterServer(MasterConnectionStringElement master)
		{
			if (master == null)
				throw new ArgumentNullException(nameof(master));

			_master = new DbMasterServer(master.ConnectionString);
		}

		private void InitializeSlaveServers(SlaveConnectionStringCollection slaves)
		{
			if (slaves == null)
				throw new ArgumentNullException(nameof(slaves));

			SlaveConnectionStringElement[] elements = slaves.OfType<SlaveConnectionStringElement>().OrderBy(item => item.Order).ToArray();
			if (elements != null)
				throw new ArgumentNullException(nameof(elements));

			this._slaves = new DbSlaveServerCollection();
			for (int i = 0; i < elements.Length; i++)
			{
				SlaveConnectionStringElement element = elements[i];
				DbSlaveServer slave = new DbSlaveServer(element.ConnectionString, i);
				_slaves.Add(slave);
			}
		}

        #endregion
    }
}
