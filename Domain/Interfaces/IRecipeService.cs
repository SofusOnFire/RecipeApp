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
        /// <returns>A list of recipes</returns>
        public IEnumerable<Recipe> GetAllRecipesFromDatabase();

        /// <summary>
        /// Gets all recipe producelines from the database based on recipeID.
        /// </summary>
        /// <param name="recipeID"></param>
        /// <returns>A list of producelines</returns>
        public IEnumerable<ProduceLine> GetAllRecipeProduceLinesByRecipeID(int recipeID);

        /// <summary>
        /// Gets all recipes based on the users producelist.
        /// </summary>
        /// <param name="produceList"></param>
        /// <returns>A list with matching recipes</returns>
        public IEnumerable<Recipe> GetAllByProduce(IUserProduce produceList);

        /// <summary>
        /// Sets the producelines to the recipe and connects produces to recipe.
        /// </summary>
        /// <param name="produceLines"></param>
        public void SetProduceLineList(IEnumerable<ProduceLine> produceLines);

        /// <summary>
        /// Takes all recipes and find matches based on userProduce.
        /// </summary>
        /// <param name="userProduce"></param>
        /// <param name="recipes"></param>
        /// <returns>A list of found matches</returns>
        public IEnumerable<Recipe> FindRecipes(IEnumerable<string> userProduce, IEnumerable<Recipe> recipes);
    }
}
