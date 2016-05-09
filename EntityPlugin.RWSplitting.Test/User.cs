using System;
using System.Collections.Generic;

namespace EntityPlugin.RWSplitting.Test
{
	public class User
	{
		public int Id { get; set; }

		public string UserName { get; set; }

		public string RealName { get; set; }

		public int Age { get; set; }

		public DateTime CreationTime { get; set; }

		public virtual List<Order> Orders { get; set; }
	}
}