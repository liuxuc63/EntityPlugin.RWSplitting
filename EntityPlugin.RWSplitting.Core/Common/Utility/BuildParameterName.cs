using EntityPlugin.RWSplitting.EnterpriseLibrary;
using System.Data.Common;

namespace EntityPlugin.RWSplitting.Common
{
	public abstract partial class Database
    {
        /// <summary>
        /// 找出 <paramref name="command"/> 脚本中定义的参数列表，并将参数列表加入其属性 Parameters 中。
        /// </summary>
        /// <param name="command">用于查找参数列表的 <see cref="DbCommand"/> 对象。</param>
        public virtual void DiscoverParameters(DbCommand command)
        {
            DatabaseExtensions.DiscoverParameters(PrimitiveDatabase, command);
        }
    }
}
