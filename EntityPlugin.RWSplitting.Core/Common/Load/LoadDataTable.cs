﻿using EntityPlugin.RWSplitting.EnterpriseLibrary;
using System.Data;
using System.Data.Common;

namespace EntityPlugin.RWSplitting.Common
{
	public abstract partial class Database
    {
        /// <summary>
        /// 执行 <paramref name="command"/> 命令并将返回结果数据填充至 <paramref name="dataTable"/> 中。
        /// </summary>
        /// <param name="dataTable">用于填充脚本命令返回结果数据的 <see cref="DataTable"/> 对象。</param>
        /// <param name="command"></param>
        public virtual void LoadDataTable(DataTable dataTable, DbCommand command)
        {
            DatabaseExtensions.LoadDataTable(this.PrimitiveDatabase, dataTable, command);
        }

        /// <summary>
        /// 执行一个 SQL 脚本并将返回结果数据填充至 <paramref name="dataTable"/> 中。
        /// </summary>
        /// <param name="dataTable">用于填充脚本命令返回结果数据的 <see cref="DataTable"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        public void LoadDataTable(DataTable dataTable, string commandText)
        {
            DatabaseExtensions.LoadDataTable(this.PrimitiveDatabase, dataTable, commandText);
        }

        /// <summary>
        /// 以指定的脚本参数执行一个 SQL 脚本并将返回结果数据填充至 <paramref name="dataTable"/> 中。
        /// </summary>
        /// <param name="dataTable">用于填充脚本命令返回结果数据的 <see cref="DataTable"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        public void LoadDataTable(DataTable dataTable, string commandText, params DbParameter[] parameterValues)
        {
            DatabaseExtensions.LoadDataTable(this.PrimitiveDatabase, dataTable, commandText, parameterValues);
        }

        /// <summary>
        /// 以指定的脚本参数执行一个 SQL 脚本并将返回结果数据填充至 <paramref name="dataTable"/> 中。
        /// </summary>
        /// <param name="dataTable">用于填充脚本命令返回结果数据的 <see cref="DataTable"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        public void LoadDataTable(DataTable dataTable, string commandText, params object[] parameterValues)
        {
            DatabaseExtensions.LoadDataTable(this.PrimitiveDatabase, dataTable, commandText, parameterValues);
        }

        /// <summary>
        /// 以指定的脚本类型执行一个 SQL 脚本并将返回结果数据填充至 <paramref name="dataTable"/> 中。
        /// </summary>
        /// <param name="dataTable">用于填充脚本命令返回结果数据的 <see cref="DataTable"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        public void LoadDataTable(DataTable dataTable, string commandText, CommandType commandType)
        {
            DatabaseExtensions.LoadDataTable(this.PrimitiveDatabase, dataTable, commandText, commandType);
        }

        /// <summary>
        /// 以指定的脚本类型和参数执行一个 SQL 脚本并将返回结果数据填充至 <paramref name="dataTable"/> 中。
        /// </summary>
        /// <param name="dataTable">用于填充脚本命令返回结果数据的 <see cref="DataTable"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        public void LoadDataTable(DataTable dataTable, string commandText, CommandType commandType, params DbParameter[] parameterValues)
        {
            DatabaseExtensions.LoadDataTable(this.PrimitiveDatabase, dataTable, commandText, commandType, parameterValues);
        }

        /// <summary>
        /// 以指定的脚本类型和参数执行一个 SQL 脚本并将返回结果数据填充至 <paramref name="dataTable"/> 中。
        /// </summary>
        /// <param name="dataTable">用于填充脚本命令返回结果数据的 <see cref="DataTable"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        public void LoadDataTable(DataTable dataTable, string commandText, CommandType commandType, params object[] parameterValues)
        {
            DatabaseExtensions.LoadDataTable(this.PrimitiveDatabase, dataTable, commandText, commandType, parameterValues);
        }



        /// <summary>
        /// 作为事务处理的一部分执行 <paramref name="command"/> 命令并将返回结果数据填充至 <paramref name="dataTable"/> 中。
        /// </summary>
        /// <param name="dataTable">用于填充脚本命令返回结果数据的 <see cref="DataTable"/> 对象。</param>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="command"></param>
        public virtual void LoadDataTable(DataTable dataTable, DbTransaction transaction, DbCommand command)
        {
            DatabaseExtensions.LoadDataTable(this.PrimitiveDatabase, dataTable, transaction, command);
        }

        /// <summary>
        /// 作为事务处理的一部分执行一个 SQL 脚本并将返回结果数据填充至 <paramref name="dataTable"/> 中。
        /// </summary>
        /// <param name="dataTable">用于填充脚本命令返回结果数据的 <see cref="DataTable"/> 对象。</param>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        public void LoadDataTable(DataTable dataTable, DbTransaction transaction, string commandText)
        {
            DatabaseExtensions.LoadDataTable(this.PrimitiveDatabase, dataTable, transaction, commandText);
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本参数执行一个 SQL 脚本并将返回结果数据填充至 <paramref name="dataTable"/> 中。
        /// </summary>
        /// <param name="dataTable">用于填充脚本命令返回结果数据的 <see cref="DataTable"/> 对象。</param>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        public void LoadDataTable(DataTable dataTable, DbTransaction transaction, string commandText, params DbParameter[] parameterValues)
        {
            DatabaseExtensions.LoadDataTable(this.PrimitiveDatabase, dataTable, transaction, commandText, parameterValues);
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本参数执行一个 SQL 脚本并将返回结果数据填充至 <paramref name="dataTable"/> 中。
        /// </summary>
        /// <param name="dataTable">用于填充脚本命令返回结果数据的 <see cref="DataTable"/> 对象。</param>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        public void LoadDataTable(DataTable dataTable, DbTransaction transaction, string commandText, params object[] parameterValues)
        {
            DatabaseExtensions.LoadDataTable(this.PrimitiveDatabase, dataTable, transaction, commandText, parameterValues);
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本类型执行一个 SQL 脚本并将返回结果数据填充至 <paramref name="dataTable"/> 中。
        /// </summary>
        /// <param name="dataTable">用于填充脚本命令返回结果数据的 <see cref="DataTable"/> 对象。</param>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        public void LoadDataTable(DataTable dataTable, DbTransaction transaction, string commandText, CommandType commandType)
        {
            DatabaseExtensions.LoadDataTable(this.PrimitiveDatabase, dataTable, transaction, commandText, commandType);
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本类型和参数执行一个 SQL 脚本并将返回结果数据填充至 <paramref name="dataTable"/> 中。
        /// </summary>
        /// <param name="dataTable">用于填充脚本命令返回结果数据的 <see cref="DataTable"/> 对象。</param>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        public void LoadDataTable(DataTable dataTable, DbTransaction transaction, string commandText, CommandType commandType, params DbParameter[] parameterValues)
        {
            DatabaseExtensions.LoadDataTable(this.PrimitiveDatabase, dataTable, transaction, commandText, commandType, parameterValues);
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本类型和参数执行一个 SQL 脚本并将返回结果数据填充至 <paramref name="dataTable"/> 中。
        /// </summary>
        /// <param name="dataTable">用于填充脚本命令返回结果数据的 <see cref="DataTable"/> 对象。</param>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        public void LoadDataTable(DataTable dataTable, DbTransaction transaction, string commandText, CommandType commandType, params object[] parameterValues)
        {
            DatabaseExtensions.LoadDataTable(this.PrimitiveDatabase, dataTable, transaction, commandText, commandType, parameterValues);
        }

    }
}
