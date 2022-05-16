using System;
using System.Collections.Generic;
using VeloMax.Models;
using MySql.Data.MySqlClient;


namespace VeloMax.Services
{
    public class Database
    {
        private string StringConnection = "database=VeloMax;server=localhost;uid=root;pwd=;";
        private MySqlConnection Connection;

        public Database()
        {
            if (!DbConnection())
            {
                System.Environment.Exit(0);
            }
        }
        public Boolean DbConnection()
        {
            Connection = new MySqlConnection(StringConnection);
            try
            {

                Connection.Open();
                Console.WriteLine("Connected");
                return true;

            }
            catch (MySqlException e)
            {
                Console.WriteLine("ERROR : Connection failed" + e.ToString());
                return false;
            }
        }

        public Boolean CloseConnection()
        {
            try
            {
                Connection.Close();
                Console.WriteLine("ERROR : Connection closed");
                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine("ERROR : Closing connection failed" + e.ToString());
                return false;
            }
        }

        public MySqlDataReader Query(MySqlConnection connection, String StringQuery)
        {
            
            MySqlCommand Command = connection.CreateCommand();
            Command.CommandText = StringQuery;
            MySqlDataReader Reader = Command.ExecuteReader();
            return Reader;

        }

        public List<Client> GetClients()
        {
            List<Client> Clients = new List<Client>();

            if (this.DbConnection())
            {
                string StringQuery = "SELECT * FROM Clients";
                MySqlDataReader Reader = Query(Connection, StringQuery);

                string Type, Street, City, PostalCode, Province, Phone, Mail;
                string? CompanyName, LastName, FirstName;
                int FidelityProgram, OrderCount;
                Boolean Member;

                while (Reader.Read())
                {
                    Type = Reader.GetString(1);
                    CompanyName = Reader.GetString(2);
                    LastName = Reader.GetString(3);
                    FirstName = Reader.GetString(4);
                    Street = Reader.GetString(5);
                    City = Reader.GetString(6);
                    PostalCode = Reader.GetString(7);
                    Province = Reader.GetString(8);
                    Phone = Reader.GetString(9);
                    Mail = Reader.GetString(10);
                    FidelityProgram = Reader.GetInt32(11);
                    Member = Reader.GetBoolean(12);
                    OrderCount = Reader.GetInt32(13);
                    Clients.Add(new Client(Type, CompanyName, LastName, FirstName, Street, City, PostalCode, Province, Phone, Mail, FidelityProgram, Member, OrderCount));
                }
                Reader.Close();
                Connection.Close();
            }

            return Clients;
        }


        public List<Part> GetParts()
        {
            List<Part> Parts = new List<Part>();

            if (this.DbConnection())
            {
                string StringQuery = "SELECT * FROM Parts";
                MySqlDataReader Reader = Query(Connection, StringQuery);

                string description, type;
                double unit_price;
                int procurement_delay, quantity;
                DateTime discontinuation_date, introduction_date;

                while (Reader.Read())
                {
                    description = Reader.GetString(1);
                    unit_price = Reader.GetDouble(2);
                    introduction_date = Reader.GetDateTime(3);
                    discontinuation_date = Reader.GetDateTime(4);
                    procurement_delay = Reader.GetInt32(5);
                    quantity = Reader.GetInt32(6);
                    type = Reader.GetString(7);

                    if (description is null || type is null)
                    {
                        System.Environment.Exit(0);
                    }
                    Parts.Add(new Part(description, unit_price, introduction_date, discontinuation_date, procurement_delay, quantity, type));
                }
                Reader.Close();
                Connection.Close();
            }

            return Parts;
        }

        public List<Bike> GetBikes()
        {
            List<Bike> Bikes = new List<Bike>();

            if (this.DbConnection())
            {
                string StringQuery = "SELECT * FROM Bikes";
                MySqlDataReader Reader = Query(Connection, StringQuery);

                string name, target, type;
                double unit_price;
                DateTime discontinuation_date, introduction_date;

                while (Reader.Read())
                {
                    name = Reader.GetString(1);
                    target = Reader.GetString(2);
                    unit_price = Reader.GetDouble(3);
                    type = Reader.GetString(4);
                    introduction_date = Reader.GetDateTime(5);
                    discontinuation_date = Reader.GetDateTime(6);
                    Bikes.Add(new Bike(name, target, unit_price, type, introduction_date, discontinuation_date));
                }
                Reader.Close();
                Connection.Close();
            }

            return Bikes;
        }
    }
}