using System;
using System.Collections.Generic;
using VeloMax.Models;
using MySql.Data.MySqlClient;


namespace VeloMax.Services
{
    public class Database
    {
        private string StringConnection = "database=VeloMax;server=localhost;uid=root;pwd=toor;";
        private MySqlConnection Connection;

        public Database()
        {
            if (!DbConnection())
            {
                Connection = null;
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
                Console.WriteLine("Connexion Failed" + e.ToString());
                return false;
            }
        }

        public Boolean CloseConnection()
        {
            try
            {
                Connection.Close();
                Console.WriteLine("Connexion closed");
                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Closing Connexion failed" + e.ToString());
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

                string Type, CompanyName, LastName, FirstName, Street, City, PostalCode, Province, Phone, Mail;
                int FidelityProgram, OrderCount;
                Boolean Member;

                while (Reader.Read())
                {
                    for (int i = 0; i < Reader.FieldCount; i++)
                    {
                        Type = Reader.GetValue(0).ToString();
                        CompanyName = Reader.GetValue(1).ToString();
                        LastName = Reader.GetValue(2).ToString();
                        FirstName = Reader.GetValue(3).ToString();
                        Street = Reader.GetValue(4).ToString();
                        City = Reader.GetValue(5).ToString();
                        PostalCode = Reader.GetValue(6).ToString();
                        Province = Reader.GetValue(7).ToString();
                        Phone = Reader.GetValue(8).ToString();
                        Mail = Reader.GetValue(9).ToString();
                        FidelityProgram = Int32.Parse(Reader.GetValue(10).ToString());
                        OrderCount = Int32.Parse(Reader.GetValue(11).ToString());
                        Member = Boolean.Parse(Reader.GetValue(12).ToString());
                        Clients.Add(new Client(Type, CompanyName, LastName, FirstName, Street, City, PostalCode, Province, Phone, Mail, FidelityProgram, Member, OrderCount));
                    }
                }
                Reader.Close();
                Connection.Close();
            }

            return Clients;
        }
    }
}