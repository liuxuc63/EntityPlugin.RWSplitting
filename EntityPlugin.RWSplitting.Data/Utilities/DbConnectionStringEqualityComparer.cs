using System;
using System.Collections.Generic;
using System.Data.Common;

namespace EntityPlugin.RWSplitting.Utilities
{
	/// <summary>
	/// 用于比较两个数据库连接字符串是否表示等效的数据库连接。
	/// </summary>
	public class DbConnectionStringEqualityComparer : EqualityComparer<string>
	{
		private static readonly Dictionary<DbProviderFactory, DbConnectionStringEqualityComparer> _dictionary = new Dictionary<DbProviderFactory, DbConnectionStringEqualityComparer>();
		private static object _locker = new object();

		/// <summary>
		/// 以指定的 <see cref="DbProviderFactory"/> 作为 <see cref="ProviderFactory"/> 属性值
		/// 初始化类型 <see cref="DbConnectionStringEqualityComparer"/> 的新实例。
		/// </summary>
		private DbConnectionStringEqualityComparer(DbProviderFactory factory)
		{
			if (factory == null)
				throw new ArgumentNullException(nameof(factory));

			ProviderFactory = factory;
		}

		/// <summary>
		/// 获取当前 <see cref="DbConnectionStringEqualityComparer"/> 对象所使用的 <see cref="DbProviderFactory"/> 对象。
		/// </summary>
		public DbProviderFactory ProviderFactory
		{
			get;
			private set;
		}

		/// <summary>
		/// 确认 <paramref name="x"/> 所表示的数据库连接字符串与 <paramref name="y"/> 所表示的数据库连接字符串是否表示同一个数据库连接。
		/// </summary>
		public override bool Equals(string x, string y)
		{
			if (string.IsNullOrEmpty(x))
				throw new ArgumentNullException(nameof(x));
			if (string.IsNullOrEmpty(y))
				throw new ArgumentNullException(nameof(y));

			x = x.Trim();
			y = y.Trim();

			DbConnectionStringBuilder a = this.ProviderFactory.CreateConnectionStringBuilder();
			a.ConnectionString = x;

			DbConnectionStringBuilder b = this.ProviderFactory.CreateConnectionStringBuilder();
			b.ConnectionString = y;

			if (this.ProviderFactory is System.Data.SqlClient.SqlClientFactory)
			{
				var m = a as System.Data.SqlClient.SqlConnectionStringBuilder;
				var n = b as System.Data.SqlClient.SqlConnectionStringBuilder;
				if (m != null && n != null)
				{
					return string.Equals(m.DataSource, n.DataSource, StringComparison.OrdinalIgnoreCase)
						&& string.Equals(m.InitialCatalog, n.InitialCatalog, StringComparison.OrdinalIgnoreCase);
				}
			}

			return a.EquivalentTo(b);
		}

		/// <summary>
		/// 用作特定类型的哈希函数，返回表示数据库连接字符串文本的哈希码。
		/// </summary>
		public override int GetHashCode(string connectionString)
		{
			if (string.IsNullOrEmpty(connectionString))
				throw new ArgumentNullException(nameof(connectionString));

			connectionString = connectionString.Trim();
			DbConnectionStringBuilder builder = ProviderFactory.CreateConnectionStringBuilder();
			builder.ConnectionString = connectionString;
			return builder.ToString().GetHashCode();
		}

		/// <summary>
		/// 根据指定的 <see cref="DbProviderFactory"/> 获取其对应的数据库连接字符串等效性比较程序 <see cref="DbConnectionStringEqualityComparer"/> 对象。
		/// </summary>
		public static DbConnectionStringEqualityComparer GetConnectionStringEqualityComparer(DbProviderFactory factory)
		{
			if (factory == null)
				throw new ArgumentNullException(nameof(factory));

			lock (_locker)
			{
				DbConnectionStringEqualityComparer comparer = null;
				if (!_dictionary.TryGetValue(factory, out comparer))
				{
					comparer = new DbConnectionStringEqualityComparer(factory);
					_dictionary.Add(factory, comparer);
				}
				return comparer;
			}
		}

		/// <summary>
		/// 根据指定的 ADO.NET 提供程序固定名称 获取其对应的数据库连接字符串等效性比较程序 <see cref="DbConnectionStringEqualityComparer"/> 对象。
		/// </summary>
		/// <param name="providerInvariantName"></param>
		/// <returns></returns>
		public static DbConnectionStringEqualityComparer GetConnectionStringEqualityComparer(string providerInvariantName)
		{
			if (string.IsNullOrEmpty(providerInvariantName))
				throw new ArgumentNullException(nameof(providerInvariantName));

			providerInvariantName = providerInvariantName.Trim();
			DbProviderFactory factory = DbProviderFactories.GetFactory(providerInvariantName);
			return GetConnectionStringEqualityComparer(factory);
		}
	}
}