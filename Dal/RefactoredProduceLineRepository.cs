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
    public class RefactoredProduceLineRepository : DatabaseManager, IProduceLineRepository
    {
        private readonly IProduceRepository _produceRepository;

        public RefactoredProduceLineRepository(IProduceRepository produceRepository)
        {
            _produceRepository = produceRepository;
        }

        public IEnumerable<ProduceLine> GetAllProduceLineByRecipeID(int? recipeID)
        {
            List<ProduceLine> list = new List<ProduceLine>();

            //Does not need a Open and Close Statement, since it haven't been closed from its call IRecipeRepository
            string query =
                "SELECT * FROM [ProduceLine] " +
                "WHERE RecipeID = @RecipeID";

            var command = new SqlCommand(query, _connectionString);

            // Replaces @ReipceID in the query with recipeID arguemnt, to ensure for SQL Injection
            command.Parameters.AddWithValue("@RecipeID", recipeID);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var recipe = new ProduceLine(
                Convert.ToInt32(reader["ProduceLineID"]),
                Convert.ToInt32(reader["RecipeID"]),
                _produceRepository.GetProduceByID(Convert.ToInt32(reader["ProduceID"]))); //Gets the produce from ProduceRepository

                list.Add(recipe);
            }

            return list;
        }
    }
}
