using System;
using System.Collections.Generic;
using System.ComponentModel;
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
			List<Recipe> userRecipes = new List<Recipe>();

			// Iterates through all recipes in the database
			foreach (Recipe recipe in recipes)
			{
				if (recipe.ProduceLines == null) // If the recipe doesn't have any produce, get the next recipe
					continue;

				// Iterates through all producelines in the current recipe
				foreach (ProduceLine produceLine in recipe.ProduceLines)
				{
					if (produceLine._Produce.Name == null) // Checks that the produce isn't null
						continue;

					for (int i = 0; i < _userProduceService.UserProduceList.Count; i++)
					{
						// If the user have the produce, break and mark the produce as found
						if (_userProduceService.UserProduceList[i].Name == produceLine._Produce.Name)
						{
							produceLine._Produce.SetStockToTrue();
							break;
						}
					}
				}

				userRecipes.Add(recipe);
			}

			return userRecipes;
		}

		public List<Recipe> SortUserRecipesByProduceInStock(List<Recipe> listOfMatchedRecipes)
		{
			// Sorts the produce by produce in stock, from InStock to notInStock
			// Iterates through all the recieved recipes
			foreach (var recipe in listOfMatchedRecipes)
			{
				// List to store produce the user doesn't have in stock
				List<ProduceLine> notInStockProduces = new List<ProduceLine>();

				if (recipe.ProduceLines == null) // If the recipe doesn't have any produce, get the next recipe
					continue;

				// Iterates through all of the lines of the current recipe
				for (int i = 0; i < recipe.ProduceLines.Count; i++)
				{
					// If the user doesn't have the produce, adds to notInStock and remove from current list
					if (recipe.ProduceLines[i]._Produce.InStockStatus == "red")
					{
						notInStockProduces.Add(recipe.ProduceLines[i]);
						recipe.ProduceLines.RemoveAt(i);
						i--; // Stays at same iteration for the next loop
					}
				}

				recipe.ProduceLines.AddRange(notInStockProduces); // Append notInStock to the listOfMatchedRecipes
			}

			return listOfMatchedRecipes;
		}
	}
}
