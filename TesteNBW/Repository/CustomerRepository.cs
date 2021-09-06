using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TesteNBW.Models;

namespace TesteNBW.Repository
{
    public class CustomerRepository
    {
        CountryRepository CountryRepository = new CountryRepository();
        
        static MySqlConnection connection = new MySqlConnection(DataBaseConnection.connString);
        MySqlCommand command = connection.CreateCommand();


        public List<Customer> Get() {
            try
            {
                connection.Open();
                command.CommandText = "Select * from Customer";
                MySqlDataReader reader = command.ExecuteReader();
                List<Customer> Customers = new List<Customer>();
                while (reader.Read())
                {
                    Customers.Add(Parser(reader));
                }
                return Customers;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public Customer Get(int Id)
        {
            try
            {
                connection.Open();
                command.CommandText = $"Select * from Customer Where id = {Id}";
                MySqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    return Parser(reader);
                }
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public void Insert(String Name, String Operation, String CNPJ, int Employee_Amont, String Billing, String Phone_Number, String Mobile_Number,String Address, String District, String City, String Zip_Code, Country country) {
            try
            {
                connection.Open();
                command.CommandText = $"INSERT INTO `customer` (`Name`,`Operation`,`CNPJ`,`Employee_Amont`,`Phone_Number`,`Mobile_Number`,`Address`,`District`,`City`,`Country`,`Zip_Code`,`Billing`)VALUES(\"{Name}\",\"{Operation}\",'{CNPJ}','{Employee_Amont}','{Phone_Number}','{Mobile_Number}','{ Address}','{District}','{City}',{country.Id},'{Zip_Code}',\"{Billing.ToString()}\")";
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }



        public void Update(int Id, String Name, String Operation, String CNPJ, int Employee_Amont, String Billing, String Phone_Number, String Mobile_Number, String Address, String District, String City, String Zip_Code, Country country)
        {
            try
            {
                connection.Open();
                command.CommandText = $"UPDATE customer SET Name = \"{Name}\", Operation = '{Operation}', CNPJ = '{CNPJ}', Employee_Amont = {Employee_Amont}, Billing = {Billing}, Phone_Number = '{Phone_Number}', Mobile_Number = '{Mobile_Number}', Address = '{Address}', District = '{District}', City = '{City}', Country = {country.Id}, Zip_Code = '{Zip_Code}' WHERE Id = {Id}";
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public void Delete(int id){

            try
            {
                connection.Open();
                command.CommandText = $"Delete from Customer where id = {id}";
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }


        public Customer Parser(MySqlDataReader reader) {
            Customer c = new Customer();
            c.Id = (int)reader["id"];
            c.Name = (string)reader["Name"];
            c.Operation = (string)reader["Operation"];
            c.CNPJ = (string)reader["CNPJ"];
            c.EmployeeAmont = (int)reader["Employee_Amont"];
            c.Billing = (Decimal)reader["Billing"];
            c.PhoneNumber = (string)reader["Phone_Number"];
            c.MobileNumber = (string)reader["Mobile_Number"];
            c.Address = (string)reader["Address"];
            c.District = (string)reader["District"];
            c.City = (string)reader["City"];
            c.ZipCode = (string)reader["Zip_Code"];
            c.Country = CountryRepository.Get((int)reader["Country"]);
            return c;
        }
    }
}
