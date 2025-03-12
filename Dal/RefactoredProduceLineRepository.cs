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

            _connectionString.Open();
            string query =
                "SELECT PL.ProduceLineID, PL.RecipeID, PL.ProduceID, P.ProduceName from [ProduceLine] PL " +
                "JOIN [Produce] P on PL.ProduceID = P.ProduceID " +
                "WHERE PL.RecipeID = @RecipeID";

            var command = new SqlCommand(query, _connectionString);

            // Replaces @ReipceID in the query with recipeID arguemnt, to ensure for SQL Injection
            command.Parameters.AddWithValue("@RecipeID", recipeID);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                //var produceLine = new ProduceLine(
                //Convert.ToInt32(reader["ProduceLineID"]),
                //Convert.ToInt32(reader["RecipeID"]),

                ////Adds the produce directly into the contructor via a join
                //new Produce(
                //    Convert.ToInt32(reader["ProduceID"]),
                //    Convert.ToString(reader["ProduceName"])));

                //list.Add(produceLine);
            }
            _connectionString.Close();

            return list;
        }
    }
}
