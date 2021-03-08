using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PersonasConsoleRegister
{
    public class ConnecntionHandler
    {
        private string connectionString;
        private MySqlConnection connection;

        private void Connect()
        {
            try
            {
                //connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
                connectionString = "server=localhost;port=5000;user=root;password=root;database=PersonasDatabase";
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (MySqlException)
            {
                throw;
            }
        }

        public MySqlConnection OpenConnection()
        {
            try
            {
                Connect();
            }
            catch (MySqlException)
            {
                throw;
            }

            return connection;
        }

        public void CloseConnection()
        {
            if (connection != null)
            {
                try
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
                catch (MySqlException)
                {
                    throw;
                }
            }
        }
    }
}