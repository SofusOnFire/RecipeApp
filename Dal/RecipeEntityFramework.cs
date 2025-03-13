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
	public class RecipeEntityFramework : IRecipeRepository
	{
		private readonly DbcontextEntityFramework _dbcontext = new DbcontextEntityFramework();

		public IEnumerable<Recipe> GetAllRecipesFromDatabase()
		{
			return _dbcontext.Recipes.Include(p1 => p1.ProduceLines).ThenInclude(P => P.Produce).ToList();
		}
	}
}
