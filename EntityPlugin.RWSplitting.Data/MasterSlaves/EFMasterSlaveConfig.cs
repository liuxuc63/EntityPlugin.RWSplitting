using System;
using System.Data.Entity.Infrastructure.Interception;

namespace EntityPlugin.RWSplitting.MasterSlaves
{
	/// <summary>
	/// 提供对 EntityFramework 的数据库操作读写分离服务的注册配置功能。
	/// </summary>
	public class EFMasterSlaveConfig
    {
        /// <summary>
        /// 将指定的 EF 实体数据库上下文类型注册到读写分离服务中。这是 EF 读写分离服务启动的入口点。
        /// <para>注意：传入的参数 <paramref name="contextType"/> 所表示的类型必须是 <see cref="System.Data.Entity.DbContext"/> 或者该类型的子类型。</para>
        /// </summary>
        public static void Register(Type contextType)
        {
			if (contextType == null)
				throw new ArgumentNullException(nameof(contextType));

            DbMasterSlaveCommandInterceptor commandInterceptor = new DbMasterSlaveCommandInterceptor(contextType);
            DbMasterSlaveConnectionInterceptor connectionInterceptor = new DbMasterSlaveConnectionInterceptor(commandInterceptor.Config);

            DbInterception.Remove(commandInterceptor);
            DbInterception.Remove(connectionInterceptor);

            DbInterception.Add(commandInterceptor);
            DbInterception.Add(connectionInterceptor);
        }

    }
}
