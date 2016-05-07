﻿using EntityPlugin.RWSplitting.EnterpriseLibrary;
using System.Data;
using System.Data.Common;

namespace EntityPlugin.RWSplitting.Common
{
	public abstract partial class Database
    {
        /// <summary>
        /// 执行 <paramref name="command"/> 命令并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="command">要被执行的 <see cref="DbCommand"/> 命令。</param>
        /// <returns>表示 <paramref name="command"/> 执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public virtual DataTable ExecuteDataTable(DbCommand command)
        {
            return DatabaseExtensions.ExecuteDataTable(this.PrimitiveDatabase, command);
        }

        /// <summary>
        /// 执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public DataTable ExecuteDataTable(string commandText)
        {
            return DatabaseExtensions.ExecuteDataTable(this.PrimitiveDatabase, commandText);
        }

        /// <summary>
        /// 以指定的脚本参数执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public DataTable ExecuteDataTable(string commandText, params DbParameter[] parameterValues)
        {
            return DatabaseExtensions.ExecuteDataTable(this.PrimitiveDatabase, commandText, parameterValues);
        }

        /// <summary>
        /// 以指定的脚本参数执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public DataTable ExecuteDataTable(string commandText, params object[] parameterValues)
        {
            return DatabaseExtensions.ExecuteDataTable(this.PrimitiveDatabase, commandText, parameterValues);
        }

        /// <summary>
        /// 以指定的脚本类型执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public DataTable ExecuteDataTable(string commandText, CommandType commandType)
        {
            return DatabaseExtensions.ExecuteDataTable(this.PrimitiveDatabase, commandText, commandType);
        }

        /// <summary>
        /// 以指定的脚本类型和参数执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public DataTable ExecuteDataTable(string commandText, CommandType commandType, params DbParameter[] parameterValues)
        {
            return DatabaseExtensions.ExecuteDataTable(this.PrimitiveDatabase, commandText, commandType, parameterValues);
        }

        /// <summary>
        /// 以指定的脚本类型和参数执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public DataTable ExecuteDataTable(string commandText, CommandType commandType, params object[] parameterValues)
        {
            return DatabaseExtensions.ExecuteDataTable(this.PrimitiveDatabase, commandText, commandType, parameterValues);
        }


        /// <summary>
        /// 作为事务处理的一部分以指定的脚本类型和参数执行 <paramref name="command"/> 命令并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="command">要被执行的 <see cref="DbCommand"/> 命令。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public virtual DataTable ExecuteDataTable(DbTransaction transaction, DbCommand command)
        {
            return DatabaseExtensions.ExecuteDataTable(this.PrimitiveDatabase, transaction, command);
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本类型执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public DataTable ExecuteDataTable(DbTransaction transaction, string commandText)
        {
            return DatabaseExtensions.ExecuteDataTable(this.PrimitiveDatabase, transaction, commandText);
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本参数执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public DataTable ExecuteDataTable(DbTransaction transaction, string commandText, params DbParameter[] parameterValues)
        {
            return DatabaseExtensions.ExecuteDataTable(this.PrimitiveDatabase, transaction, commandText, parameterValues);
        }
        /// <summary>
        /// 作为事务处理的一部分以指定的脚本参数执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>

        public DataTable ExecuteDataTable(DbTransaction transaction, string commandText, params object[] parameterValues)
        {
            return DatabaseExtensions.ExecuteDataTable(this.PrimitiveDatabase, transaction, commandText, parameterValues);
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本类型执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public DataTable ExecuteDataTable(DbTransaction transaction, string commandText, CommandType commandType)
        {
            return DatabaseExtensions.ExecuteDataTable(this.PrimitiveDatabase, transaction, commandText, commandType);
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本类型和参数执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public DataTable ExecuteDataTable(DbTransaction transaction, string commandText, CommandType commandType, params DbParameter[] parameterValues)
        {
            return DatabaseExtensions.ExecuteDataTable(this.PrimitiveDatabase, transaction, commandText, commandType, parameterValues);
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本类型和参数执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public DataTable ExecuteDataTable(DbTransaction transaction, string commandText, CommandType commandType, params object[] parameterValues)
        {
            return DatabaseExtensions.ExecuteDataTable(this.PrimitiveDatabase, transaction, commandText, commandType, parameterValues);
        }

    }
}
