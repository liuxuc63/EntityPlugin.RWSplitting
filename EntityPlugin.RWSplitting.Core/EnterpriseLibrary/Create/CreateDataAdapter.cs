using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace EntityPlugin.RWSplitting.EnterpriseLibrary
{
	public static partial class DatabaseExtensions
    {
        /// <summary>
        /// 创建并返回与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。
        /// </summary>
        /// <param name="database">表示当前 <see cref="Microsoft.Practices.EnterpriseLibrary.Data.Database"/> 对象。</param>
        /// <returns>与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。</returns>
        public static DbDataAdapter CreateDataAdapter(this Database database)
        {
            return database.GetDataAdapter();
        }
    }
}
