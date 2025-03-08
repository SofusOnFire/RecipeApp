using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRecipeService
    {
		/// <summary>
		/// Gets all recipes from database.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Recipe> GetAllRecipesFromDatabase();

		/// <summary>
		/// Gets all recipes matched by UserProduce
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Recipe> FindRecipes();

		/// <summary>
		/// Sorts the recipes by produce in stock by the user
		/// </summary>
		/// <param name="listOfMatchedRecipes"></param>
		/// <returns></returns>
		public List<Recipe> SortUserRecipesByProduceInStock(List<Recipe> listOfMatchedRecipes);

	}
}
