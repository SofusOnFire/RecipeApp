using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DAL
{
	public class DbcontextEntityFramework : DbContext
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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Produce>().ToTable("Produce");
			modelBuilder.Entity<Recipe>().ToTable("Recipe");
			modelBuilder.Entity<ProduceLine>().ToTable("ProduceLine");

			// ProduceLine - Produce Relationship
			modelBuilder.Entity<ProduceLine>()
				.HasOne(pl => pl.Produce)
				.WithMany()
				.HasForeignKey(pl => pl.ProduceID)
				.OnDelete(DeleteBehavior.Restrict);

			// ProduceLine - Recipe Relationship
			modelBuilder.Entity<ProduceLine>()
				.HasOne(pl => pl.Recipe)
				.WithMany(r => r.ProduceLines)
				.HasForeignKey(pl => pl.RecipeID)
				.OnDelete(DeleteBehavior.Cascade);

			// Primary Keys
			modelBuilder.Entity<Produce>().HasKey(p => p.ProduceID);
			modelBuilder.Entity<Recipe>().HasKey(r => r.RecipeID);
			modelBuilder.Entity<ProduceLine>().HasKey(pl => pl.ProduceLineID);
		}
	}
}
