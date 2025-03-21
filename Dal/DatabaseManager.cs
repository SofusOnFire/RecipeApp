using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class DatabaseManager
    {
        protected const string _ConnectionString = "Data Source=localhost;Initial Catalog='RecipeDB';Integrated Security=SSPI;TrustServerCertificate=true";
        
        //Aske Server:
        //"Server=Djamo;Database=RecipeDB;Integrated Security=True;Encrypt=False";
        
        protected static SqlConnection _connectionString = new SqlConnection(_ConnectionString);


        /// <summary>
        /// Opens, Execute and Close, NonQueries. Returns the number of rows affected by this SQL
        /// </summary>
        /// <param name="command"></param>
        protected static int ExecuteNonQuery(SqlCommand command)
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
        protected static int ExecuteScalar(SqlCommand command)
        {
            int id = 0;
            _connectionString.Open();
            id = (int)command.ExecuteScalar();
            _connectionString.Close();
            return id;
        }
    }
}
