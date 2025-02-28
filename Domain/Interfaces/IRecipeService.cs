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
        /// Gets all recipes from the database.
        /// </summary>
        /// <returns>Returns a list of recipes</returns>
        public IEnumerable<Recipe> GetAllRecipesFromDatabase();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        public IEnumerable<ProduceLine> GetAllRecipeProduceLines(int recipeID);

        /// <summary>
        /// Gets all recipes based on the users producelist.
        /// </summary>
        /// <param name="produceList"></param>
        /// <returns>Returns a list with matching recipes</returns>
        public IEnumerable<Recipe> GetAllByProduce(IUserProduce produceList);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="produceLines"></param>
        public void SetProduce(IEnumerable<ProduceLine> produceLines);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProduce"></param>
        /// <param name="recipes"></param>
        /// <returns></returns>
        public IEnumerable<Recipe> FindRecipes(IEnumerable<string> userProduce, IEnumerable<Recipe> recipes);
    }
}
