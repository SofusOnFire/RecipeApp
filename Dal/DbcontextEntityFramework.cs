using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DAL
{
	internal class DbcontextEntityFramework : DbContext
	{
		public DbSet<Recipe> Recipes { get; set; }
		public DbSet<ProduceLine> ProduceLines { get; set; }
		public DbSet<Produce> Produces { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(GetConnectionString());
		}

		protected static string GetConnectionString()
		{
			string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			string fullName = Path.Combine(desktopPath, "RecipeAppConnectionString");
			return File.ReadAllText(fullName);
		}
	}
}
