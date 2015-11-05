using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PeopleSearch.Models
{
	public class Person
	{
		[DisplayName("Person ID")]
		public int PersonID { get; set; }

		[DisplayName("First Name")]
		[Required(ErrorMessage = "First Name is required")]
		[StringLength(50)]
		public string FirstName { get; set; }

		[DisplayName("Last Name")]
		[Required(ErrorMessage = "Last Name is required")]
		[StringLength(50)]
		public string LastName { get; set; }

		[DisplayName("Address")]
		public string Address { get; set; }

		[DisplayName("Age")]
		public int Age { get; set; }

		[DisplayName("Interests")]
		public string Interests { get; set; }

		[DisplayName("Picture")]
		[StringLength(100)]
		public string Picture { get; set; }

		[DisplayName("Alternate Name")]
		[StringLength(100)]
		public string AlternateText { get; set; }
	}

	public class PeopleDBContext : DbContext
	{
		public DbSet<Person> People { get; set; }
	}
}