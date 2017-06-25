using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CustomLight.Domain.Entities;

namespace CustomLight.Domain.Context
{
	class AppContext : DbContext
	{
		public AppContext() : base("DbConnection")
		{

		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Image> Images { get; set; }
	}
}
