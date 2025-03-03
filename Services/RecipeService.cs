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

		public IEnumerable<Recipe> FindRecipes(List<string> userProduce)
		{
			var recipes = GetAllRecipeFromDatabase(); // Gets all recipes

			List<Recipe> matchingRecipes = new List<Recipe>(); // Creates new list to contain possible matching recipes

			bool userContainsAllRecipeProduce = true; // Bool which represents succes or failure of checking matches

			foreach (Recipe recipe in recipes)
			{
				foreach (ProduceLine produceLine in recipe.ProduceLines)
				{
					if (!userProduce.Contains(produceLine.Produce.Name)) // If the user doesn't have the produce the operation breaks and continue with the next recipe
					{
						userContainsAllRecipeProduce = false;
						break;
					}
				}

				if (userContainsAllRecipeProduce)
				{
					matchingRecipes.Add(recipe);
				}
			}

			return recipes;
		}

		public IEnumerable<Recipe> GetAllRecipeFromDatabase()
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
