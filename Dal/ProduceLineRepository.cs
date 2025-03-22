using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ProduceLineRepository : DatabaseManager, IProduceLineRepository
    {
        public IEnumerable<ProduceLine> GetAllProduceLineByRecipeID(int? recipeID)
        {
            List<ProduceLine> list = new List<ProduceLine>();
            _connectionString.Open();

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
                Convert.ToInt32(reader["ProduceID"]),
                Convert.ToInt32(reader["Amount"]));

                list.Add(recipe);
            }
            _connectionString.Close();

            return list;
        }

        public void AddProduceLines(List<Produce> produces, int recipeID)
        {
            foreach (var produce in produces)
            {
                string createProduceLine = "INSERT INTO [ProduceLine] (RecipeID, ProduceID, Amount) " +
                                      "OUTPUT INSERTED.ProduceLineID " +
                                      "VALUES (@RecipeID, @ProduceID, @Amount)";

                var command = new SqlCommand(createProduceLine, _connectionString);

                command.Parameters.AddWithValue("@RecipeID", recipeID);
                command.Parameters.AddWithValue("@ProduceID", produce.ProduceID);
                command.Parameters.AddWithValue("@Amount", produce.RecipeAmount);
                int produceLineID = DatabaseManager.ExecuteScalar(command);
            }
        }
    }
}
