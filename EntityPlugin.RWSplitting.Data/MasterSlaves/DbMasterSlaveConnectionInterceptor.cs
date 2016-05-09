﻿using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System;

namespace EntityPlugin.RWSplitting.MasterSlaves
{
	/// <summary>
	/// 定义一个 EF 实体数据库主从读写分离服务的数据库连接动作执行拦截器，用于配合 <see cref="DbMasterSlaveCommandInterceptor"/> 实现数据库读写分离操作。
	/// </summary>
	internal class DbMasterSlaveConnectionInterceptor : NullDbConnectionInterceptor
	{
		private DbMasterSlaveConfigContext _config;

		/// <summary>
		/// 以指定的 EF 数据库主从读写分离配置上下文对象作为 <see cref="Config"/> 属性值初始化类型 <see cref="DbMasterSlaveConnectionInterceptor"/> 的新实例。
		/// </summary>
		internal DbMasterSlaveConnectionInterceptor(DbMasterSlaveConfigContext config)
		{
			if (config == null)
				throw new ArgumentNullException(nameof(config));
			_config = config;
		}

		internal DbMasterSlaveConfigContext Config
		{
			get { return this._config; }
		}

		/// <summary>
		/// 在打开数据库连接动作执行前瞬间触发。将数据库连接字符串更新至 EF 数据库主从读写分离服务中配置的相关值。
		/// </summary>
		public override void Opening(DbConnection connection, DbConnectionInterceptionContext interceptionContext)
		{
			UpdateConnectionStringIfNeed(connection, this.Config.UsableMasterConnectionString, interceptionContext.DbContexts);
		}

		/// <summary>
		/// 在开启一个数据库事务动作执行前瞬间触发。当开始事务操作时将数据库连接字符串更新至 Master 数据库。
		/// </summary>
		public override void BeginningTransaction(DbConnection connection, BeginTransactionInterceptionContext interceptionContext)
		{
			UpdateConnectionStringIfNeed(connection, this.Config.UsableMasterConnectionString, interceptionContext.DbContexts);
		}

		private void UpdateConnectionStringIfNeed(DbConnection connection, string connectionString, IEnumerable<System.Data.Entity.DbContext> contexts)
		{
			if (contexts.Any(this.Config.CanApplyTo))
			{
				if (!DbMasterSlaveCommandInterceptor.ConnectionStringEquals(connection, connectionString))
				{
					DbMasterSlaveCommandInterceptor.UpdateConnectionString(connection, connectionString);
				}
			}
		}
	}
}