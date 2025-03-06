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

		public string getRecipeProduceLines(Recipe recipe);

    }
}
