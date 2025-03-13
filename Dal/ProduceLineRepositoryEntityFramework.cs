using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class ProduceLineRepositoryEntityFramework : IProduceLineRepository
	{
		private readonly DbcontextEntityFramework _dbcontext = new DbcontextEntityFramework();

		public IEnumerable<ProduceLine> GetAllProduceLineByRecipeID(int? recipeID)
		{
			return _dbcontext.ProduceLines
				.Include(pl => pl.Recipe)
				.Include(pl => pl.Produce)
				.Where(pl => pl.RecipeID == recipeID)
				.ToList();
		}
	}
}
