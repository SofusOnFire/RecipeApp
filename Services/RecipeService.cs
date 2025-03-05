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

			// Iterates through all recipes in the database
			foreach (Recipe recipe in recipes) 
			{
				bool AllRecipeMatches = true; // Assumes the user have all needed produce

				if (recipe.ProduceLines == null) // If the recipe doesn't have any produce, get the next recipe
					continue;

				// Iterates through all producelines in the current recipe
				foreach (ProduceLine produceLine in recipe.ProduceLines)
				{
					if (produceLine._Produce.Name == null) // Checks that the produce isn't null
						continue;

					// If the user doesn't have a produce, break and mark the recipe as non-fulfilled
					if (_userProduceService.UserProduceList.Contains(produceLine._Produce.Name) == false)
					{
						AllRecipeMatches = false;
						break;
					}
				}

				if (AllRecipeMatches == true) // Adds the recipe to the succesful matched list, if every produce is available
				{
					matchedRecipes.Add(recipe);
				}
			}

			return matchedRecipes;
		}
	}
}
