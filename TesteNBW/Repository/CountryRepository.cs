﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TesteNBW.Models;

namespace TesteNBW.Repository
{


    public class CountryRepository
    {
        static MySqlConnection connection = new MySqlConnection(DataBaseConnection.connString);
        MySqlCommand command = connection.CreateCommand();

        public List<Country> Get() {
            try
            {
                connection.Open();
                command.CommandText = "Select * from Country";
                MySqlDataReader reader = command.ExecuteReader();
                List<Country> countries = new List<Country>();
                while (reader.Read()){
                    countries.Add(Parser(reader));
                }
                return countries;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public List<Country> Get(int id)
        {
            try
            {
                connection.Open();
                command.CommandText = $"Select * from Country where Id = {id}";
                MySqlDataReader reader = command.ExecuteReader();
                List<Country> countries = new List<Country>();
                while (reader.Read())
                {
                    countries.Add(Parser(reader));
                }
                return countries;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public void Insert(String Acronym, String Descryption) {
            try
            {
                connection.Open();
                command.CommandText = $"Insert into Country(Acronym, Descryption) Values('{Acronym}', '{Descryption}')";
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public void Update(int id, String Acronym, String Descryption)
        {
            try
            {
                connection.Open();
                command.CommandText = $"Update country set Acronym = '{Acronym}', Descryption = '{Descryption}' where id = {id}";
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public void Delete(int id)
        {
            try
            {
                connection.Open();
                command.CommandText = $"Delete from country where id = {id}";
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        //Transforma um registro dentro de um reader para um objeto Country
        public static Country Parser(MySqlDataReader reader){
            Country c = new Country();
            c.Id = (int)reader["Id"];
            c.Acronym = (string)reader["Acronym"];
            c.Descryption = (string)reader["Descryption"];
            return c;
        }

    }
}
