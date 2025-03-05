using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Services
{
	public class RecipeService : IRecipeService
	{
		private readonly IUserProduceService _userProduceService; // DI for FindRecipe method.
		private readonly IProduceLineService _produceLineService; // DI for GetAllRecipeProduceLinesByRecipeID
		private readonly IRecipeRepository _recipeRepository; // DI for GetAllRecipeFromDataBase

		public RecipeService(IUserProduceService userProduceService, IProduceLineService produceLineService, IRecipeRepository recipeRepository)
		{
			_userProduceService = userProduceService;
			_produceLineService = produceLineService;
			_recipeRepository = recipeRepository;
		}

		public IEnumerable<Recipe> GetAllRecipesFromDatabase()
		{
			IEnumerable<Recipe> recipes = _recipeRepository.GetAllRecipesFromDatabase();

			foreach (Recipe recipe in recipes)
			{
				IEnumerable<ProduceLine> produceLines = _produceLineService.GetAllRecipeProduceLinesByRecipeID(recipe.RecipeID);

				recipe.SetProduceLineList(produceLines);
			}

			return recipes;
		}
	}
}
