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
		public IEnumerable<Recipe> GetAllRecipeFromDatabase();

		/// <summary>
		/// Matches the users produce to the available recipes
		/// </summary>
		/// <param name="UserProduce"></param>
		/// <param name="recipes"></param>
		/// <returns></returns>
		public IEnumerable<Recipe> FindRecipes(List<string> UserProduce);
	}
}
