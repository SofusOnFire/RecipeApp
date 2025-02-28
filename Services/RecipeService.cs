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
		private readonly IUserProduce _userProduce; // DI for FindRecipe method.

		public RecipeService(IUserProduce userProduce)
		{
			_userProduce = userProduce;
		}

		public IEnumerable<Recipe> FindRecipes(IEnumerable<string> userProduce, IEnumerable<Recipe> recipes)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Recipe> GetAllByProduce(IUserProduce produceList)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ProduceLine> GetAllRecipeProduceLinesByRecipeID(int recipeID)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Recipe> GetAllRecipesFromDatabase()
		{
			throw new NotImplementedException();
		}

		public void SetProduceLineList(IEnumerable<ProduceLine> produceLines)
		{
			throw new NotImplementedException();
		}
	}
}
