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
			_connectionString.Open();

			string query =
				"SELECT * FROM [Produce] " +
				"WHERE ProduceID = @ProduceID";

			var command = new SqlCommand(query, _connectionString);

			// Replaces @ProduceID in the query with produceID arguemnt, to ensure for SQL Injection
			command.Parameters.AddWithValue("@ProduceID", produceID);

			SqlDataReader reader = command.ExecuteReader();

			var produce = new Produce(
			Convert.ToInt32(reader["ProduceLineID"]),
			Convert.ToString(reader["Name"]));

			_connectionString.Close();

			return produce;
		}
    }
}
