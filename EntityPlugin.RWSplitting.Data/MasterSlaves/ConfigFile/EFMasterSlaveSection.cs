using System;
using System.Configuration;

namespace EntityPlugin.RWSplitting.MasterSlaves
{
	/// <summary>
	/// 表示 EF 读写分离服务配置文件信息中的配置根节点。
	/// </summary>
	public class EFMasterSlaveSection : ConfigurationSection
	{
		private static readonly ConfigurationProperty _applyItems = new ConfigurationProperty("", typeof(ApplyItemCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);

		/// <summary>
		/// 初始化类型 <see cref="EFMasterSlaveSection"/> 的新实例。
		/// </summary>
		public EFMasterSlaveSection() { }

		/// <summary>
		/// 获取配置集合中为特定的 EF 数据库上下文类型 <paramref name="dbContextType"/> 定义的 <see cref="ApplyItemCollection"/> 对象。
		/// </summary>
		public ApplyItemElement this[Type dbContextType]
		{
			get { return ApplyItems[dbContextType]; }
		}

		/// <summary>
		/// 获取配置集合中为特定的 EF 数据库上下文对象 <paramref name="context"/> 定义的 <see cref="ApplyItemCollection"/> 对象。
		/// </summary>
		public ApplyItemElement this[System.Data.Entity.DbContext context]
		{
			get { return ApplyItems[context]; }
		}

		/// <summary>
		/// 获取 <see cref="EFMasterSlaveSection"/> 对象的 <see cref="ApplyItemCollection"/> 集合。
		/// </summary>
		[ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
		public ApplyItemCollection ApplyItems
		{
			get { return base[_applyItems] as ApplyItemCollection; }
		}
	}
}