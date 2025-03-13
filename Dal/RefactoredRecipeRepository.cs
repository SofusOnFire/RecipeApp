using DAL.OldRepositories;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RefactoredRecipeRepository : DatabaseManager, IRecipeRepository
    {
        private readonly IProduceLineRepository _produceLineRepository;

        public RefactoredRecipeRepository(IProduceLineRepository produceLineRepository)
        {
            _produceLineRepository = produceLineRepository;
        }

        public IEnumerable<Recipe> GetAllRecipesFromDatabase()
        {
            List<Recipe> listOfRecipes = new List<Recipe>();

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

                listOfRecipes.Add(recipe);
            }
            _connectionString.Close();

            //If the Recipe count is 0 throw exeption, så vi know what is wrong
            if (listOfRecipes.Count == 0) throw new Exception("There we no recipes to be found in database");

            // Adds produceLines to each recipe via IProduceLineRepository
            foreach (var recipe in listOfRecipes)
            {
                recipe.AddProduceLine(_produceLineRepository.GetAllProduceLineByRecipeID(recipe.RecipeID));
            }

            return listOfRecipes;
        }
    }
}
