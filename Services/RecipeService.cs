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

		public IEnumerable<Recipe> FindRecipes()
		{
			IEnumerable<Recipe> recipes = GetAllRecipesFromDatabase();
			List<Recipe> matchedRecipes = new List<Recipe>();

			foreach (Recipe recipe in recipes)
			{
				bool AllRecipeMatches = true;

				if (recipe.ProduceLines == null)
					continue;

				foreach (ProduceLine produceLine in recipe.ProduceLines)
				{
					if (produceLine._Produce.Name == null)
						continue;

					if (_userProduceService.UserProduceList.Contains(produceLine._Produce.Name) == false)
					{
						AllRecipeMatches = false;
						break;
					}
				}

				if (AllRecipeMatches == true)
				{
					matchedRecipes.Add(recipe);
				}
			}

			return matchedRecipes;
		}
	}
}
