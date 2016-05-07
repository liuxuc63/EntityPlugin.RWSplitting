using EntityPlugin.RWSplitting.EnterpriseLibrary;
using System.Data;
using System.Data.Common;

namespace EntityPlugin.RWSplitting.Common
{
	public abstract partial class Database
    {
        /// <summary>
        /// 开始一个数据库事务。
        /// </summary>
        /// <returns>一个数据库事务 <see cref="System.Data.Common.DbTransaction"/> 对象。</returns>
        public DbTransaction BeginTransaction()
        {
            return DatabaseExtensions.BeginTransaction(PrimitiveDatabase);
        }

        /// <summary>
        /// 以指定的事务锁定级别开始一个数据库事务。
        /// </summary>
        /// <param name="isolationLevel">指定的数据库事务锁定级别 <see cref="IsolationLevel"/>。</param>
        /// <returns>一个指定了事务锁定级别的数据库事务 <see cref="System.Data.Common.DbTransaction"/> 对象。</returns>
        public DbTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return DatabaseExtensions.BeginTransaction(PrimitiveDatabase, isolationLevel);
        }
    }
}
