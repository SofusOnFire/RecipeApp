using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Services
{
	class RecipeService : IRecipeService
	{
		private readonly IUserProduceService _userProduceService; // DI for FindRecipe method.

		public IEnumerable<Recipe> FindRecipes(IEnumerable<string> userProduce, IEnumerable<Recipe> recipes)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Recipe> GetAllByProduce(IUserProduceService produceList)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ProduceLine> GetAllRecipeProduceLines(int recipeID)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Recipe> GetAllRecipesFromDatabase()
		{
			throw new NotImplementedException();
		}

		public void SetProduce(IEnumerable<ProduceLine> produceLines)
		{
			throw new NotImplementedException();
		}
	}
}
