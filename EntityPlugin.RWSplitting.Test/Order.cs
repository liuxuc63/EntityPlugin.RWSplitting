using System;

namespace EntityPlugin.RWSplitting.Test
{
	public class Order
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Content { get; set; }

		public float Price { get; set; }

		public DateTime CreationTime { get; set; }

		public int UserId { get; set; }

		public virtual User User { get; set; }
	}
}