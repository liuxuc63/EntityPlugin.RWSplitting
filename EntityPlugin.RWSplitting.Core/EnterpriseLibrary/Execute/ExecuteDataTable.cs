﻿using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Globalization;

namespace EntityPlugin.RWSplitting.EnterpriseLibrary
{
	public static partial class DatabaseExtensions
    {
        /// <summary>
        /// 执行 <paramref name="command"/> 命令并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="database">表示一个 <see cref="Microsoft.Practices.EnterpriseLibrary.Data.Database"/> 对象。</param>
        /// <param name="command">要被执行的 <see cref="DbCommand"/> 命令。</param>
        /// <returns>表示 <paramref name="command"/> 执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public static DataTable ExecuteDataTable(this Database database, DbCommand command)
        {
            DataTable dataTable = new DataTable();
            dataTable.Locale = CultureInfo.InvariantCulture;
            LoadDataTable(database, dataTable, command);
            return dataTable;
        }

        /// <summary>
        /// 执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="database">表示一个 <see cref="Microsoft.Practices.EnterpriseLibrary.Data.Database"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public static DataTable ExecuteDataTable(this Database database, string commandText)
        {
            return ExecuteDataTable(database, commandText, CommandType.Text);
        }

        /// <summary>
        /// 以指定的脚本参数执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="database">表示一个 <see cref="Microsoft.Practices.EnterpriseLibrary.Data.Database"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public static DataTable ExecuteDataTable(this Database database, string commandText, params DbParameter[] parameterValues)
        {
            return ExecuteDataTable(database, commandText, CommandType.Text, parameterValues);
        }

        /// <summary>
        /// 以指定的脚本参数执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="database">表示一个 <see cref="Microsoft.Practices.EnterpriseLibrary.Data.Database"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public static DataTable ExecuteDataTable(this Database database, string commandText, params object[] parameterValues)
        {
            return ExecuteDataTable(database, commandText, CommandType.Text, parameterValues);
        }

        /// <summary>
        /// 以指定的脚本类型执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="database">表示一个 <see cref="Microsoft.Practices.EnterpriseLibrary.Data.Database"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public static DataTable ExecuteDataTable(this Database database, string commandText, CommandType commandType)
        {
            using (DbCommand command = CreateCommand(database, commandText, commandType))
            {
                return ExecuteDataTable(database, command);
            }
        }

        /// <summary>
        /// 以指定的脚本类型和参数执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="database">表示一个 <see cref="Microsoft.Practices.EnterpriseLibrary.Data.Database"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public static DataTable ExecuteDataTable(this Database database, string commandText, CommandType commandType, params DbParameter[] parameterValues)
        {
            using (DbCommand command = CreateCommand(database, commandText, commandType, parameterValues))
            {
                return ExecuteDataTable(database, command);
            }
        }

        /// <summary>
        /// 以指定的脚本类型和参数执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="database">表示一个 <see cref="Microsoft.Practices.EnterpriseLibrary.Data.Database"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public static DataTable ExecuteDataTable(this Database database, string commandText, CommandType commandType, params object[] parameterValues)
        {
            using (DbCommand command = CreateCommand(database, commandText, commandType, parameterValues))
            {
                return ExecuteDataTable(database, command);
            }
        }


        /// <summary>
        /// 作为事务处理的一部分以指定的脚本类型和参数执行 <paramref name="command"/> 命令并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="database">表示一个 <see cref="Microsoft.Practices.EnterpriseLibrary.Data.Database"/> 对象。</param>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="command">要被执行的 <see cref="DbCommand"/> 命令。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public static DataTable ExecuteDataTable(this Database database, DbTransaction transaction, DbCommand command)
        {
            DataTable dataTable = new DataTable();
            dataTable.Locale = CultureInfo.InvariantCulture;
            LoadDataTable(database, dataTable, transaction, command);
            return dataTable;
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本类型执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="database">表示一个 <see cref="Microsoft.Practices.EnterpriseLibrary.Data.Database"/> 对象。</param>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public static DataTable ExecuteDataTable(this Database database, DbTransaction transaction, string commandText)
        {
            return ExecuteDataTable(database, transaction, commandText, CommandType.Text);
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本参数执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="database">表示一个 <see cref="Microsoft.Practices.EnterpriseLibrary.Data.Database"/> 对象。</param>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public static DataTable ExecuteDataTable(this Database database, DbTransaction transaction, string commandText, params DbParameter[] parameterValues)
        {
            return ExecuteDataTable(database, transaction, commandText, CommandType.Text, parameterValues);
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本参数执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="database">表示一个 <see cref="Microsoft.Practices.EnterpriseLibrary.Data.Database"/> 对象。</param>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public static DataTable ExecuteDataTable(this Database database, DbTransaction transaction, string commandText, params object[] parameterValues)
        {
            return ExecuteDataTable(database, transaction, commandText, CommandType.Text, parameterValues);
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本类型执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="database">表示一个 <see cref="Microsoft.Practices.EnterpriseLibrary.Data.Database"/> 对象。</param>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public static DataTable ExecuteDataTable(this Database database, DbTransaction transaction, string commandText, CommandType commandType)
        {
            using (DbCommand command = CreateCommand(database, commandText, commandType))
            {
                return ExecuteDataTable(database, transaction, command);
            }
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本类型和参数执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="database">表示一个 <see cref="Microsoft.Practices.EnterpriseLibrary.Data.Database"/> 对象。</param>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public static DataTable ExecuteDataTable(this Database database, DbTransaction transaction, string commandText, CommandType commandType, params DbParameter[] parameterValues)
        {
            using (DbCommand command = CreateCommand(database, commandText, commandType, parameterValues))
            {
                return ExecuteDataTable(database, transaction, command);
            }
        }

        /// <summary>
        /// 作为事务处理的一部分以指定的脚本类型和参数执行一个 SQL 脚本并根据执行结果返回一个新创建的 <see cref="DataTable"/> 对象。
        /// </summary>
        /// <param name="database">表示一个 <see cref="Microsoft.Practices.EnterpriseLibrary.Data.Database"/> 对象。</param>
        /// <param name="transaction">用于包含脚本命令的 <see cref="DbTransaction"/> 对象。</param>
        /// <param name="commandText">表示要执行的 SQL 脚本文本内容。</param>
        /// <param name="commandType">表示一个 <see cref="CommandType"/> 值用于指示 <paramref name="commandText"/> 的类型。</param>
        /// <param name="parameterValues">表示用于执行 <paramref name="commandText"/> 命令的参数列表。</param>
        /// <returns>表示脚本命令执行的结果的一个 <see cref="DataTable"/> 对象。</returns>
        public static DataTable ExecuteDataTable(this Database database, DbTransaction transaction, string commandText, CommandType commandType, params object[] parameterValues)
        {
            using (DbCommand command = CreateCommand(database, commandText, commandType, parameterValues))
            {
                return ExecuteDataTable(database, transaction, command);
            }
        }

    }
}
