namespace PeopleSearch.Migrations
{
	using PeopleSearch.Models;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<PeopleSearch.Models.PeopleDBContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(PeopleSearch.Models.PeopleDBContext context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//
			context.People.AddOrUpdate(i => i.PersonID,
				new Person
				{
					PersonID = 1,
					FirstName = "Alex",
					LastName = "Luka",
					Address = "Berlin",
					Age = 16,
					Interests = "None",
					Picture = "~/Photos/JohnSmith.png",
					AlternateText = "John Smith Photo"
				},

				new Person
				{
					PersonID = 2,
					FirstName = "Bob",
					LastName = "Nelson",
					Address = "Texas",
					Age = 41,
					Interests = "Paragling",
					Picture = "~/Photos/BobNelson.png",
					AlternateText = "Bob Nelson Photo"
				},

				new Person
				{
					PersonID = 3,
					FirstName = "Cindy",
					LastName = "Crawford",
					Address = "Rio",
					Age = 86,
					Interests = "Drawing",
					Picture = "~/Photos/CindyCrawford.png",
					AlternateText = "Cindy Crawford Photo"
				}
			);
		}


	}
}
