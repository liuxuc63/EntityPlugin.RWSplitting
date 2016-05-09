using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityPlugin.RWSplitting.MasterSlaves;
using System.Collections.Generic;

namespace EntityPlugin.RWSplitting.Test
{
	[TestClass]
	public class RWSplittingTest
	{
		TestDbContext DbContext;

		[TestInitialize]
		public void Init()
		{
			EFMasterSlaveConfig.Register(typeof(TestDbContext));
			DbContext = new TestDbContext();
		}

		[TestMethod]
		public void Test_Insert_Update_Query_Delete_Success()
		{
			User userA = new User
			{
				UserName = "userNameA",
				RealName = "RealNameA",
				Age = 18,
				CreationTime = DateTime.Now
			};

			List<Order> orders = new List<Order>();
			orders.Add(new Order
			{
				Name = "order1",
				Content = "content1",
				Price = 11.11f,
				CreationTime = DateTime.Now,
				User = userA
			});

			orders.Add(new Order
			{
				Name = "order2",
				Content = "content2",
				Price = 12.12f,
				CreationTime = DateTime.Now,
				User = userA
			});

			userA.Orders = orders;

			DbContext.User.Add(userA);
			DbContext.SaveChanges();

			var userResult = (from item in DbContext.User
							  select item).FirstOrDefault();

			Assert.IsNotNull(userResult);
			Assert.AreEqual(userResult.UserName, userA.UserName);
			Assert.AreEqual(userResult.RealName, userA.RealName);
			Assert.AreEqual(userResult.Age, userA.Age);
			Assert.AreEqual(userResult.CreationTime, userA.CreationTime);

			Assert.AreEqual(userResult.Orders.Count, 2);

			userResult.UserName = "changeUserName";
			userResult.RealName = "changeRealName";

			DbContext.User.Attach(userResult);
			DbContext.Entry(userResult).State = System.Data.Entity.EntityState.Modified;
			DbContext.SaveChanges();

			var changeUser = (from item in DbContext.User
						  select item).FirstOrDefault();

			Assert.IsNotNull(changeUser);
			Assert.AreEqual(changeUser.UserName, userA.UserName);
			Assert.AreEqual(changeUser.RealName, userA.RealName);
			Assert.AreEqual(changeUser.Age, userA.Age);
			Assert.AreEqual(changeUser.CreationTime, userA.CreationTime);

			DbContext.User.Remove(changeUser);
			DbContext.SaveChanges();
		}
	}
}
