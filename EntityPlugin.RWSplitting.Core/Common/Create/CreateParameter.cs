﻿using EntityPlugin.RWSplitting.EnterpriseLibrary;
using System.Data;
using System.Data.Common;

namespace EntityPlugin.RWSplitting.Common
{
	public abstract partial class Database
    {
        /// <summary>
        /// 创建并返回与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。
        /// </summary>
        /// <returns>与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。</returns>
        public virtual DbParameter CreateParameter()
        {
            return DatabaseExtensions.CreateParameter(this.PrimitiveDatabase);
        }

        /// <summary>
        /// 以指定的名称创建并返回与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。
        /// </summary>
        /// <param name="parameterName">参数名称。</param>
        /// <returns>与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。</returns>
        public virtual DbParameter CreateParameter(string parameterName)
        {
            return DatabaseExtensions.CreateParameter(this.PrimitiveDatabase, parameterName);
        }


        /// <summary>
        /// 以指定的名称、数据类型为配置创建并返回与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。
        /// </summary>
        /// <param name="parameterName">参数名称。</param>
        /// <param name="dbType">参数数据类型。</param>
        /// <returns>与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。</returns>
        public DbParameter CreateParameter(string parameterName, DbType dbType)
        {
            return DatabaseExtensions.CreateParameter(this.PrimitiveDatabase, parameterName, dbType);
        }

        /// <summary>
        /// 以指定的名称、长度为配置创建并返回与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。
        /// </summary>
        /// <param name="parameterName">参数名称。</param>
        /// <param name="size">参数长度。</param>
        /// <returns>与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。</returns>
        public DbParameter CreateParameter(string parameterName, int size)
        {
            return DatabaseExtensions.CreateParameter(this.PrimitiveDatabase, parameterName, size);
        }

        /// <summary>
        /// 以指定的名称、数据类型、长度为配置创建并返回与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。
        /// </summary>
        /// <param name="parameterName">参数名称。</param>
        /// <param name="dbType">参数数据类型。</param>
        /// <param name="size">参数长度。</param>
        /// <returns>与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。</returns>
        public DbParameter CreateParameter(string parameterName, DbType dbType, int size)
        {
            return DatabaseExtensions.CreateParameter(this.PrimitiveDatabase, parameterName, dbType, size);
        }

        /// <summary>
        /// 以指定的名称、数据类型、长度、输入输出类型、可空类型为配置创建并返回与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。
        /// </summary>
        /// <param name="parameterName">参数名称。</param>
        /// <param name="dbType">参数数据类型。</param>
        /// <param name="size">参数长度。</param>
        /// <param name="direction">一个表示参数为输入还是输出类型的枚举值。</param>
        /// <param name="isNullable"></param>
        /// <returns>与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。</returns>
        public DbParameter CreateParameter(string parameterName, DbType dbType, int size, ParameterDirection direction, bool isNullable)
        {
            return DatabaseExtensions.CreateParameter(this.PrimitiveDatabase, parameterName, dbType, size, direction, isNullable);
        }

        /// <summary>
        /// 以指定的名称、数据类型、长度、输入输出类型、可空类型等配置创建并返回与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。 
        /// </summary>
        /// <param name="parameterName">参数名称。</param>
        /// <param name="dbType">参数数据类型。</param>
        /// <param name="size">参数长度。</param>
        /// <param name="direction">一个表示参数为输入还是输出类型的枚举值。</param>
        /// <param name="isNullable">参数是否可为空(DBNull.Value)。</param>
        /// <param name="sourceColumn">参数的源列名称，该源列映射到 <see cref="System.Data.DataSet"/> 并用于加载或返回 <seealso cref="System.Data.Common.DbParameter.Value"/>。</param>
        /// <param name="sourceColumnNullMapping">指示源列是否可以为 null。 这使得 <see cref="System.Data.Common.DbCommandBuilder"/> 能够正确地为可以为 null 的列生成 Update 语句。</param>
        /// <param name="sourceVersion">指示参数在加载 <seealso cref="System.Data.Common.DbParameter.Value"/> 时使用的 <see cref="System.Data.DataRowVersion"/>。</param>
        /// <returns>与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。</returns>
        public DbParameter CreateParameter(string parameterName, DbType dbType, int size, ParameterDirection direction, bool isNullable, string sourceColumn, bool sourceColumnNullMapping, DataRowVersion sourceVersion)
        {
            return DatabaseExtensions.CreateParameter(this.PrimitiveDatabase, parameterName, dbType, size, direction, isNullable, sourceColumn, sourceColumnNullMapping, sourceVersion);
        }


        /// <summary>
        /// 以指定的名称、值为配置创建并返回与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。
        /// </summary>
        /// <param name="parameterName">参数名称。</param>
        /// <param name="value">参数值。</param>
        /// <returns>与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。</returns>
        public DbParameter CreateParameter(string parameterName, object value)
        {
            return DatabaseExtensions.CreateParameter(this.PrimitiveDatabase, parameterName, value);
        }

        /// <summary>
        /// 以指定的名称、值、数据类型为配置创建并返回与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。
        /// </summary>
        /// <param name="parameterName">参数名称。</param>
        /// <param name="value">参数值。</param>
        /// <param name="dbType">参数数据类型。</param>
        /// <returns>与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。</returns>
        public DbParameter CreateParameter(string parameterName, object value, DbType dbType)
        {
            return DatabaseExtensions.CreateParameter(this.PrimitiveDatabase, parameterName, value, dbType);
        }

        /// <summary>
        /// 以指定的名称、值、长度为配置创建并返回与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。
        /// </summary>
        /// <param name="parameterName">参数名称。</param>
        /// <param name="value">参数值。</param>
        /// <param name="size">参数长度。</param>
        /// <returns>与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。</returns>
        public DbParameter CreateParameter(string parameterName, object value, int size)
        {
            return DatabaseExtensions.CreateParameter(this.PrimitiveDatabase, parameterName, value, size);
        }

        /// <summary>
        /// 以指定的名称、值、数据类型、长度为配置创建并返回与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。
        /// </summary>
        /// <param name="parameterName">参数名称。</param>
        /// <param name="value">参数值。</param>
        /// <param name="dbType">参数数据类型。</param>
        /// <param name="size">参数长度。</param>
        /// <returns></returns>
        public DbParameter CreateParameter(string parameterName, object value, DbType dbType, int size)
        {
            return DatabaseExtensions.CreateParameter(this.PrimitiveDatabase, parameterName, value, dbType, size);
        }

        /// <summary>
        /// 以指定的名称、值、数据类型、长度、输入输出类型、可空类型为配置创建并返回与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。
        /// </summary>
        /// <param name="parameterName">参数名称。</param>
        /// <param name="value">参数值。</param>
        /// <param name="dbType">参数数据类型。</param>
        /// <param name="size">参数长度。</param>
        /// <param name="direction">一个表示参数为输入还是输出类型的枚举值。</param>
        /// <param name="isNullable">参数是否可为空(DBNull.Value)。</param>
        /// <returns>与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。</returns>
        public DbParameter CreateParameter(string parameterName, object value, DbType dbType, int size, ParameterDirection direction, bool isNullable)
        {
            return DatabaseExtensions.CreateParameter(this.PrimitiveDatabase, parameterName, value, dbType, size, direction, isNullable);
        }

        /// <summary>
        /// 以指定的名称、值、数据类型、长度、输入输出类型、可空类型等配置创建并返回与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。
        /// </summary>
        /// <param name="parameterName">参数名称。</param>
        /// <param name="value">参数值。</param>
        /// <param name="dbType">参数数据类型。</param>
        /// <param name="size">参数长度。</param>
        /// <param name="direction">一个表示参数为输入还是输出类型的枚举值。</param>
        /// <param name="isNullable">参数是否可为空(DBNull.Value)。</param>
        /// <param name="sourceColumn">参数的源列名称，该源列映射到 <see cref="System.Data.DataSet"/> 并用于加载或返回 <seealso cref="System.Data.Common.DbParameter.Value"/>。</param>
        /// <param name="sourceColumnNullMapping">指示源列是否可以为 null。 这使得 <see cref="System.Data.Common.DbCommandBuilder"/> 能够正确地为可以为 null 的列生成 Update 语句。</param>
        /// <param name="sourceVersion">指示参数在加载 <seealso cref="System.Data.Common.DbParameter.Value"/> 时使用的 <see cref="System.Data.DataRowVersion"/>。</param>
        /// <returns>与当前 <see cref="DbProviderFactory"/> 关联的 <see cref="DbDataAdapter"/> 对象。</returns>
        public DbParameter CreateParameter(string parameterName, object value, DbType dbType, int size, ParameterDirection direction, bool isNullable, string sourceColumn, bool sourceColumnNullMapping, DataRowVersion sourceVersion)
        {
            return DatabaseExtensions.CreateParameter(this.PrimitiveDatabase, parameterName, value, dbType, size, direction, isNullable, sourceColumn, sourceColumnNullMapping, sourceVersion);
        }

    }
}
