using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TesteNBW.Models;

namespace TesteNBW.Repository
{


    public class CountryRepository
    {

        static String connString = "Server=localhost;Database=nbw;Uid=root;Pwd=admin";
        static MySqlConnection connection = new MySqlConnection(connString);
        MySqlCommand command = connection.CreateCommand();

        public List<Country> Get() {
            try
            {
                connection.Open();
                command.CommandText = "INSERT INTO customer (cd_customer) VALUES (6)";
                command.ExecuteNonQuery();
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        

    }
}
