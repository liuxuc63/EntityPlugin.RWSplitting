using System;

namespace EntityPlugin.RWSplitting.MasterSlaves
{
	/// <summary>
	/// 表示当 EF 数据库主从读写分离服务扫描配置中的数据库服务器节点可用性状态时所引发事件的数据。
	/// </summary>
	public class DbServerStateScanEventArgs : EventArgs
	{

		/// <summary>
		/// 初始化类型 <see cref="DbServerStateScanEventArgs"/> 的新实例。
		/// </summary>
		private DbServerStateScanEventArgs()
		{
			this.DbServerType = DbServerType.Master;
			this.DbServerState = DbServerState.Online;
		}

		/// <summary>
		/// 以指定的属性值初始化类型 <see cref="DbServerStateScanEventArgs"/> 的新实例。
		/// </summary>
		public DbServerStateScanEventArgs(string connectionString, DbServerType serverType, DbServerState serverState)
			: this()
		{
			if (string.IsNullOrEmpty(connectionString))
				throw new ArgumentNullException(nameof(connectionString));

			connectionString = connectionString.Trim();
			ConnectionString = connectionString;
			DbServerType = serverType;
			DbServerState = serverState;
		}

		/// <summary>
		/// 获取该引发该事件的数据库服务器节点可用性状态检测动作所扫描的数据库连接字符串。
		/// </summary>
		public string ConnectionString
		{
			get;
			private set;
		}

		/// <summary>
		/// 获取该引发该事件的数据库服务器节点可用性状态检测动作所扫描的数据库服务器类型。
		/// </summary>
		public DbServerType DbServerType
		{
			get;
			private set;
		}

		/// <summary>
		/// 获取该引发该事件的数据库服务器节点可用性状态检测动作所扫描的数据库服务器的可用性状态。
		/// </summary>
		public DbServerState DbServerState
		{
			get;
			private set;
		}
	}
}
