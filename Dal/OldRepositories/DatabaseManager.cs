using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL.OldRepositories
{
    public abstract class DatabaseManager
    {
        protected string _ConnectionString;

		protected SqlConnection _connectionString = new SqlConnection(_ConnectionString);


        /// <summary>
        /// Opens, Execute and Close, NonQueries. Returns the number of rows affected by this SQL
        /// </summary>
        /// <param name="command"></param>
        protected int ExecuteNonQuery(SqlCommand command)
        {
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
        protected int ExecuteScalar(SqlCommand command)
        {
            int id = 0;
            _connectionString.Open();
            id = (int)command.ExecuteScalar();
            _connectionString.Close();
            return id;
        }
    }
}
