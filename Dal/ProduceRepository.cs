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
    public class ProduceRepository : DatabaseManager, IProduceRepository
    {
        public Produce GetProduceByID(int produceID)
        {
			Produce produce = new Produce(0, "Ingrediens ikke fundet");
			
			_connectionString.Open();

			string query =
				"SELECT * FROM [Produce] " +
				"WHERE ProduceID = @ProduceID";

			var command = new SqlCommand(query, _connectionString);

			// Replaces @ProduceID in the query with produceID arguemnt, to ensure for SQL Injection
			command.Parameters.AddWithValue("@ProduceID", produceID);

			SqlDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				produce = new Produce(
				Convert.ToInt32(reader["ProduceID"]),
				Convert.ToString(reader["ProduceName"]));
			}

			_connectionString.Close();

			return produce;
		}
		public List<Produce> GetAllProduce()
		{
			List<Produce> list = new List<Produce>();
            _connectionString.Open();

			string query =
				"SELECT * FROM [Produce]";
            
			var command = new SqlCommand(query, _connectionString);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var produce = new Produce(
                Convert.ToInt32(reader["ProduceID"]),
                Convert.ToString(reader["ProduceName"]));

				list.Add(produce);
            }

            _connectionString.Close();

            return list;
        }

		public bool CreateProduce(string produceName)
		{
			_connectionString.Open();

			// Query to check if the produce already is in DB
			string queryCheck =
				"SELECT * FROM [Produce] " +
				"WHERE ProduceName = @Check";

			var checkCommand = new SqlCommand(queryCheck, _connectionString);

			checkCommand.Parameters.AddWithValue("@Check", produceName);

			// Fallback value is 0 if returned (ExecuteScalar) value is null
			int existingCount = (int)(checkCommand.ExecuteScalar() ?? 0);

			if (existingCount > 0) // If hit return and dont add it to DB
			{
				_connectionString.Close();

				return true;
			}
			else
			{
				// Add to DB
				string insertQuery =
					"INSERT INTO [Produce] (ProduceName) " +
					"VALUES (@Input)";

				var insertCommand = new SqlCommand(insertQuery, _connectionString);

				insertCommand.Parameters.AddWithValue("@Input", produceName);

				insertCommand.ExecuteScalar();

				_connectionString.Close();

				return false;
			}
		}
	}
}
