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
	public class UnitRepository : DatabaseManager, IUnitRepositry
	{
		public Unit GetUnitByUnitID(int unitID)
		{
			Unit? unit = null;

			_connectionString.Open();

			string query =
				"SELECT * FROM [Unit] " +
				"WHERE UnitID = @UnitID";

			var command = new SqlCommand(query, _connectionString);

			// Replaces @UnitID in the query with unitID arguemnt, to ensure for SQL Injection
			command.Parameters.AddWithValue("@UnitID", unitID);

			SqlDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				unit = new Unit(
				Convert.ToInt32(reader["UnitID"]),
				Convert.ToString(reader["UnitName"]));
			}

			_connectionString.Close();

			if (unit == null) throw new NullReferenceException();
			return unit;
		}
	}
}
