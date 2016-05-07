﻿namespace EntityPlugin.RWSplitting.Common
{
	public abstract partial class Database
    {
        /// <summary>
        /// 根据指明的变量名称，创建一个适用于当前数据库类型（依据当前对象的 <see cref="DbProviderFactory"/> 属性所创建的 <see cref="DbConnection"/>）的变量参数名称。
        /// </summary>
        /// <param name="name">指明的用于包装变量参数名称。</param>
        /// <returns>一个表示可用于表示当前数据库类型（依据当前对象的 <see cref="DbProviderFactory"/> 属性所创建的 <see cref="DbConnection"/>）的变量参数名称。</returns>
        public string BuildParameterName(string name)
        {
            return PrimitiveDatabase.BuildParameterName(name);
        }
    }
}
