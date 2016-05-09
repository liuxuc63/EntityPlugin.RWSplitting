using System.Data.Entity;

namespace EntityPlugin.RWSplitting.Test
{
	public class TestDbContext : DbContext
	{
		public virtual DbSet<User> User { get; set; }

		public virtual DbSet<Order> Order { get; set; }
	}
}