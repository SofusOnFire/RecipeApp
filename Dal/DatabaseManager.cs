using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class DatabaseManager
    {
        protected static string _ConnectionString;

		protected static SqlConnection _connectionString = new SqlConnection(_ConnectionString);

        private static string GetConnectionString()
        {
			string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			string fullName = System.IO.Path.Combine(desktopPath, "RecipeAppConnectionString");
			using (StreamReader steamReader = new StreamReader(fullName))
			{
				return steamReader.ReadToEnd();
			}
		}



		/// <summary>
		/// Opens, Execute and Close, NonQueries. Returns the number of rows affected by this SQL
		/// </summary>
		/// <param name="command"></param>
		protected static int ExecuteNonQuery(SqlCommand command)
        {
            if (_ConnectionString == null) GetConnectionString();
        

            int numberOfRowsAffected = 0;
            _connectionString.Open();
            numberOfRowsAffected = command.ExecuteNonQuery();
            _connectionString.Close();
            return numberOfRowsAffected;
        }

        /// <summary>
        /// Opens, Execute and returns the ID from Database, and closes when out of scope
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        protected static int ExecuteScalar(SqlCommand command)
        {
			if (_ConnectionString == null) GetConnectionString();

			int id = 0;
            _connectionString.Open();
            id = (int)command.ExecuteScalar();
            _connectionString.Close();
            return id;
        }
    }
}
