using System;
using System.Collections.Generic;
using VeloMax.Models;
using MySql.Data.MySqlClient;


namespace VeloMax.Services
{
    public class Database
    {
        private string StringConnection = "database=Velomax;server=Localhost;uid=root;pwd=";
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
            List<Client> List = new List<Client>();

            if (this.DbConnection())
            {
                string StringQuery = "SELECT * FROM clients";
                MySqlDataReader Reader = Query(Connection, StringQuery);

                string Street, City, PostalCode, Province, Phone, Mail;
                int Id;

                while (Reader.Read())
                {
                    Id = Reader.GetInt32(0);
                    Street = Reader.GetString(1);
                    City = Reader.GetString(2);
                    PostalCode = Reader.GetString(3);
                    Province = Reader.GetString(4);
                    Phone = Reader.GetString(5);
                    Mail = Reader.GetString(6);
                    List.Add(new Client(Id,Street, City, PostalCode, Province, Phone, Mail));
                }
                Reader.Close();
                Connection.Close();
            }

            return List;
        }

        public List<Individual> GetIndividuals()
        {
            List<Individual> List = new List<Individual>();

            if (this.DbConnection())
            {
                string StringQuery = "SELECT * FROM clients NATURAL JOIN individuals";
                MySqlDataReader Reader = Query(Connection, StringQuery);

                int Id;
                string Street, City, PostalCode, Province, Phone, Mail;
                string FirstName, LastName;
                int FidelityId;
                

                while (Reader.Read())
                {
                    Id = Reader.GetInt32(0);
                    Street = Reader.GetString(1);
                    City = Reader.GetString(2);
                    PostalCode = Reader.GetString(3);
                    Province = Reader.GetString(4);
                    Phone = Reader.GetString(5);
                    Mail = Reader.GetString(6);
                    FirstName = Reader.GetString(7);
                    LastName = Reader.GetString(8);
                    FidelityId = Reader.GetInt32(9);
                    List.Add(new Individual(Id, FirstName, LastName, Street, City, PostalCode, Province, Phone, Mail, FidelityId));
                }
                Reader.Close();
                Connection.Close();
            }

            return List;
        }

        public List<Professional> GetProfessionals()
        {
            List<Professional> List = new List<Professional>();

            if (this.DbConnection())
            {
                string StringQuery = "SELECT * FROM clients NATURAL JOIN professionals";
                MySqlDataReader Reader = Query(Connection, StringQuery);

                string Street, City, PostalCode, Province, Phone, Mail;
                int Id;
                string CompanyName, ContactName;
                int OrderCount;


                while (Reader.Read())
                {
                    Id = Reader.GetInt32(0);
                    Street = Reader.GetString(1);
                    City = Reader.GetString(2);
                    PostalCode = Reader.GetString(3);
                    Province = Reader.GetString(4);
                    Phone = Reader.GetString(5);
                    Mail = Reader.GetString(6);
                    CompanyName = Reader.GetString(7);
                    ContactName = Reader.GetString(8);
                    OrderCount = Reader.GetInt32(9);
                    List.Add(new Professional(Id, CompanyName, ContactName, Street, City, PostalCode, Province, Phone, Mail, OrderCount));
                }
                Reader.Close();
                Connection.Close();
            }

            return List;
        }


        public List<Part> GetParts()
        {
            List<Part> List = new List<Part>();

            if (this.DbConnection())
            {
                string StringQuery = "SELECT * FROM parts";
                MySqlDataReader Reader = Query(Connection, StringQuery);

                string description, type;
                double unit_price;
                int procurement_delay, quantity, Id;
                DateTime discontinuation_date, introduction_date;

                while (Reader.Read())
                {
                    Id = Reader.GetInt32(0);
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
                    List.Add(new Part(Id,description, unit_price, introduction_date, discontinuation_date, procurement_delay, quantity, type));
                }
                Reader.Close();
                Connection.Close();
            }

            return List;
        }

        public List<Bike> GetBikes()
        {
            List<Bike> List = new List<Bike>();

            if (this.DbConnection())
            {
                string StringQuery = "SELECT * FROM bikes";
                MySqlDataReader Reader = Query(Connection, StringQuery);

                string name, target, type;
                double unit_price;
                int id;
                DateTime discontinuation_date, introduction_date;

                while (Reader.Read())
                {
                    id = Reader.GetInt32(0);
                    name = Reader.GetString(1);
                    target = Reader.GetString(2);
                    unit_price = Reader.GetDouble(3);
                    type = Reader.GetString(4);
                    introduction_date = Reader.GetDateTime(5);
                    discontinuation_date = Reader.GetDateTime(6);
                    List.Add(new Bike(id, name, target, unit_price, type, introduction_date, discontinuation_date));
                }
                Reader.Close();
                Connection.Close();
            }

            return List;
        }

        public List<Order> GetOrders()
        {
            List<Order> List = new List<Order>();

            if (this.DbConnection())
            {
                string StringQuery = "SELECT * FROM orders";
                MySqlDataReader Reader = Query(Connection, StringQuery);

                int id, quantity;
                DateTime order_date, shipping_date;
                string shipping_adresse;


                while (Reader.Read())
                {
                    id = Reader.GetInt32(0);
                    order_date = Reader.GetDateTime(1);
                    shipping_adresse = Reader.GetString(2);
                    shipping_date = Reader.GetDateTime(3);
                    quantity = Reader.GetInt32(4);

                    List.Add(new Order(id, order_date, shipping_adresse, shipping_date, quantity));
                }
                Reader.Close();
                Connection.Close();
            }

           return List; 
        }

        public List<Supplier> GetSuppliers()
        {
            List<Supplier> List = new List<Supplier>();

            if (this.DbConnection())
            {
                string StringQuery = "SELECT * FROM suppliers";
                MySqlDataReader Reader = Query(Connection, StringQuery);

                int id;
                string siret, name, contact, location, label;


                while (Reader.Read())
                {
                    id = Reader.GetInt32(0);
                    siret = Reader.GetString(1);
                    name = Reader.GetString(2);
                    contact = Reader.GetString(3);
                    location = Reader.GetString(4);
                    label = Reader.GetString(5);

                    List.Add(new Supplier(id, siret, name, contact, location, label));
                }
                Reader.Close();
                Connection.Close();
            }

           return List; 
        }

        
        public List<FidelityProgram> GetFidelityPrograms()
        {
            List<FidelityProgram> List = new List<FidelityProgram>();

            if (this.DbConnection())
            {
                string StringQuery = "SELECT * FROM fidelity_programs";
                MySqlDataReader Reader = Query(Connection, StringQuery);

                int id, cost, duration, discount;
                string label;


                while (Reader.Read())
                {
                    id = Reader.GetInt32(0);
                    label = Reader.GetString(1);
                    cost = Reader.GetInt32(2);
                    duration = Reader.GetInt32(3);
                    discount = Reader.GetInt32(4);


                    List.Add(new FidelityProgram(id, label, cost ,duration, discount));
                }
                Reader.Close();
                Connection.Close();
            }

           return List; 
        }

        public List<OrderedPart> GetOrderParts()
        {
            List<OrderedPart> List = new List<OrderedPart>();

            if (this.DbConnection())
            {
                string StringQuery = "SELECT * FROM ordered_parts";
                MySqlDataReader Reader = Query(Connection, StringQuery);

                int id, quantity, orders_id, parts_id;

                while (Reader.Read())
                {
                    id = Reader.GetInt32(0);
                    orders_id = Reader.GetInt32(1);
                    parts_id = Reader.GetInt32(2);
                    quantity = Reader.GetInt32(3);

                    List.Add(new OrderedPart(id, orders_id, parts_id, quantity));
                }
                Reader.Close();
                Connection.Close();
            }

           return List; 
        }

        public List<OrderedBike> GetOrderBikes()
        {
            List<OrderedBike> List = new List<OrderedBike>();

            if (this.DbConnection())
            {
                string StringQuery = "SELECT * FROM ordered_bikes";
                MySqlDataReader Reader = Query(Connection, StringQuery);

                int id, quantity, bikes_id, parts_id;

                while (Reader.Read())
                {
                    id = Reader.GetInt32(0);
                    bikes_id = Reader.GetInt32(1);
                    parts_id = Reader.GetInt32(2);
                    quantity = Reader.GetInt32(3);

                    List.Add(new OrderedBike(id, bikes_id, parts_id, quantity));
                }
                Reader.Close();
                Connection.Close();
            }

           return List; 
        }

        public List<BikePart> GetBikesParts()
        {
            List<BikePart> List = new List<BikePart>();

            if (this.DbConnection())
            {
                string StringQuery = "SELECT * FROM bike_parts";
                MySqlDataReader Reader = Query(Connection, StringQuery);

                int id, bikes_id, parts_id;

                while (Reader.Read())
                {
                    id = Reader.GetInt32(0);
                    parts_id = Reader.GetInt32(1);
                    bikes_id = Reader.GetInt32(2);

                    List.Add(new BikePart(id, parts_id, bikes_id));
                }
                Reader.Close();
                Connection.Close();
            }

           return List; 
        }

        
        public List<Procurement> GetProcurement()
        {
            List<Procurement> List = new List<Procurement>();

            if (this.DbConnection())
            {
                string StringQuery = "SELECT * FROM procurement";
                MySqlDataReader Reader = Query(Connection, StringQuery);

                int id, parts_id, suppliers_id;

                while (Reader.Read())
                {
                    id = Reader.GetInt32(0);
                    parts_id = Reader.GetInt32(2);
                    suppliers_id = Reader.GetInt32(3);

                    List.Add(new Procurement(id, parts_id, suppliers_id));
                }
                Reader.Close();
                Connection.Close();
            }

           return List; 
        }

        
    }
}