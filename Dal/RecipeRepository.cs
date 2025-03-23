using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class RecipeRepository : DatabaseManager, IRecipeRepository
    {

        /// <summary>
        /// Gets all columns from all Recipes from the database with no Where clause. Returns as a List
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Recipe> GetAllRecipesFromDatabase()
        {
            List<Recipe> list = new List<Recipe>();

            string query = "SELECT * FROM [Recipe]";
            var command = new SqlCommand(query, _connectionString);

            _connectionString.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var recipe = new Recipe(
                Convert.ToInt32(reader["RecipeID"]),
                Convert.ToString(reader["RecipeName"]),
                Convert.ToInt32(reader["CookTime"]),
                Convert.ToString(reader["URL"]));

                list.Add(recipe);
            }
            _connectionString.Close();

            return list;
        }
        /// <summary>
        /// Adds a new recipe to the DB and returns the RecipeID as an int.
        /// </summary>
        public int AdminAddRecipeToDB(string recipeName, int cookTime, string uRL)
        {
            string createRecipe = "INSERT INTO [Recipe] (RecipeName, CookTime, URL) " +
                                  "OUTPUT INSERTED.RecipeID " +
                                  "VALUES (@RecipeName, @CookTime, @URL)";

            var command = new SqlCommand(createRecipe, _connectionString);

            command.Parameters.AddWithValue("@RecipeName", recipeName);
            command.Parameters.AddWithValue("@CookTime", cookTime);
            command.Parameters.AddWithValue("@URL", uRL);

            int recipeID = DatabaseManager.ExecuteScalar(command);

            return recipeID;

        }
    }
}
