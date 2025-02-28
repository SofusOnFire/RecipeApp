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
        public IEnumerable<Produce> GetProduceByID(int produceID)
        {
			List<Produce> list = new List<Produce>();

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
				var produce = new Produce(
				Convert.ToInt32(reader["ProduceLineID"]),
				Convert.ToString(reader["Name"]));

				list.Add(produce);
			}

			_connectionString.Close();

			return list;
		}
    }
}
