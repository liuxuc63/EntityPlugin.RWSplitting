using EntityPlugin.RWSplitting.EnterpriseLibrary;
using System.Data.Common;

namespace EntityPlugin.RWSplitting.Common
{
	public abstract partial class Database
    {
        /// <summary>
        /// 创建并返回与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbConnection"/> 对象。
        /// </summary>
        /// <returns>与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbConnection"/> 对象。</returns>
        public virtual DbConnection CreateConnection()
        {
            return DatabaseExtensions.CreateConnection(this.PrimitiveDatabase);
        }
    }
}
