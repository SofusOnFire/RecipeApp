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

            foreach (var recipe in list)
            {
                _produceLineRepository.GetAllProduceLineByRecipeID(recipe.RecipeID);
            }

            return list;
        }
    }
}
