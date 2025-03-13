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
        protected static string _ConnectionString;

        protected SqlConnection _connectionString = new SqlConnection(_ConnectionString);


        protected static string GetConnectionString()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullName = Path.Combine(desktopPath, "RecipeAppConnectionString");
            //return File.ReadAllText(fullName);
            File.WriteAllText(fullName, "Data Source = mssql4.unoeuro.com, 1433; Database = foxtrox_dk_db_recipeapp; Integrated Security = false; User ID = foxtrox_dk; Password = A4EHeFypwfnx5h93crmB");
            return File.ReadAllText(fullName);
        }



        /// <summary>
        /// Opens, Execute and Close, NonQueries. Returns the number of rows affected by this SQL
        /// </summary>
        /// <param name="command"></param>
        protected int ExecuteNonQuery(SqlCommand command)
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
        protected int ExecuteScalar(SqlCommand command)
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
