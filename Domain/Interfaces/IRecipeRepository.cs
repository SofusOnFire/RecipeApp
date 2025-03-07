using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRecipeRepository
    {
        /// <summary>
        /// Returns all Recipes with all relevant producelines (Which contains the relevant produce)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Recipe> GetAllRecipesFromDatabase();
    }
}
