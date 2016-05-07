﻿using EntityPlugin.RWSplitting.EnterpriseLibrary;
using System.Data;
using System.Data.Common;

namespace EntityPlugin.RWSplitting.Common
{
	public abstract partial class Database
    {
        /// <summary>
        /// 执行 <paramref name="command"/> 命令。
        /// </summary>
        /// <param name="command">要被执行的 <see cref="DbCommand"/> 命令。</param>
        public virtual void ExecuteNone(DbCommand command)
        {
            DatabaseExtensions.ExecuteNone(this.PrimitiveDatabase, command);
        }

        /// <summary>
        /// 执行一个 SQL 脚本。
        /// </summary>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        public void ExecuteNone(string commandText)
        {
            DatabaseExtensions.ExecuteNone(this.PrimitiveDatabase, commandText);
        }

        /// <summary>
        /// 以指定的脚本参数执行一个 SQL 脚本。
        /// </summary>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        public void ExecuteNone(string commandText, params DbParameter[] parameterValues)
        {
            DatabaseExtensions.ExecuteNone(this.PrimitiveDatabase, commandText, parameterValues);
        }

        /// <summary>
        /// 以指定的脚本参数执行一个 SQL 脚本。
        /// </summary>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        public void ExecuteNone(string commandText, params object[] parameterValues)
        {
            DatabaseExtensions.ExecuteNone(this.PrimitiveDatabase, commandText, parameterValues);
        }

        /// <summary>
        /// 以指定的脚本类型执行一个 SQL 脚本。
        /// </summary>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        public void ExecuteNone(string commandText, CommandType commandType)
        {
            DatabaseExtensions.ExecuteNone(this.PrimitiveDatabase, commandText, commandType);
        }

        /// <summary>
        /// 以指定的脚本类型和参数执行一个 SQL 脚本。
        /// </summary>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        public void ExecuteNone(string commandText, CommandType commandType, params DbParameter[] parameterValues)
        {
            DatabaseExtensions.ExecuteNone(this.PrimitiveDatabase, commandText, commandType, parameterValues);
        }

        /// <summary>
        /// 以指定的脚本类型和参数执行一个 SQL 脚本。
        /// </summary>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        public void ExecuteNone(string commandText, CommandType commandType, params object[] parameterValues)
        {
            DatabaseExtensions.ExecuteNone(this.PrimitiveDatabase, commandText, commandType, parameterValues);
        }


        /// <summary>
        /// 作为事务处理的一部分以指定的脚本类型和参数执行 <paramref name="command"/> 命令。
        /// </summary>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="command">要被执行的 <see cref="DbCommand"/> 命令。</param>
        public virtual void ExecuteNone(DbTransaction transaction, DbCommand command)
        {
            DatabaseExtensions.ExecuteNone(this.PrimitiveDatabase, transaction, command);
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本类型执行一个 SQL 脚本。
        /// </summary>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        public void ExecuteNone(DbTransaction transaction, string commandText)
        {
            DatabaseExtensions.ExecuteNone(this.PrimitiveDatabase, transaction, commandText);
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本参数执行一个 SQL 脚本。
        /// </summary>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        public void ExecuteNone(DbTransaction transaction, string commandText, params DbParameter[] parameterValues)
        {
            DatabaseExtensions.ExecuteNone(this.PrimitiveDatabase, transaction, commandText, parameterValues);
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本参数执行一个 SQL 脚本。
        /// </summary>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        public void ExecuteNone(DbTransaction transaction, string commandText, params object[] parameterValues)
        {
            DatabaseExtensions.ExecuteNone(this.PrimitiveDatabase, transaction, commandText, parameterValues);
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本类型执行一个 SQL 脚本。
        /// </summary>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        public void ExecuteNone(DbTransaction transaction, string commandText, CommandType commandType)
        {
            DatabaseExtensions.ExecuteNone(this.PrimitiveDatabase, transaction, commandText, commandType);
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本类型和参数执行一个 SQL 脚本。
        /// </summary>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        public void ExecuteNone(DbTransaction transaction, string commandText, CommandType commandType, params DbParameter[] parameterValues)
        {
            DatabaseExtensions.ExecuteNone(this.PrimitiveDatabase, transaction, commandText, commandType, parameterValues);
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本类型和参数执行一个 SQL 脚本。
        /// </summary>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        public void ExecuteNone(DbTransaction transaction, string commandText, CommandType commandType, params object[] parameterValues)
        {
            DatabaseExtensions.ExecuteNone(this.PrimitiveDatabase, transaction, commandText, commandType, parameterValues);
        }

    }
}
