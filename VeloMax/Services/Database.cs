using System;
using System.Collections.Generic;
using VeloMax.Models;
using MySql.Data.MySqlClient;


namespace VeloMax.Services
{
    public class Database
    {
        private string StringConnection = "database=Velomax;server=Localhost;uid=root;pwd=toor";
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
                int FidelityProgram, OrderCount, Id;
                Boolean Member;

                while (Reader.Read())
                {
                    Id = Reader.GetInt32(0);
                    Type = Reader.GetString(1);
                    CompanyName = Reader.GetValue(2).ToString();
                    LastName = Reader.GetValue(3).ToString();
                    FirstName = Reader.GetValue(4).ToString();
                    Street = Reader.GetString(5);
                    City = Reader.GetString(6);
                    PostalCode = Reader.GetString(7);
                    Province = Reader.GetString(8);
                    Phone = Reader.GetString(9);
                    Mail = Reader.GetString(10);
                    FidelityProgram = Reader.GetInt32(11);
                    Member = Reader.GetBoolean(12);
                    OrderCount = Reader.GetInt32(13);
                    Clients.Add(new Client(Id,Type, CompanyName, LastName, FirstName, Street, City, PostalCode, Province, Phone, Mail, FidelityProgram, Member, OrderCount));
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
                    Parts.Add(new Part(Id,description, unit_price, introduction_date, discontinuation_date, procurement_delay, quantity, type));
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
                    Bikes.Add(new Bike(id, name, target, unit_price, type, introduction_date, discontinuation_date));
                }
                Reader.Close();
                Connection.Close();
            }

            return Bikes;
        }

        public List<Order> GetOrders()
        {
            List<Order> Orders = new List<Order>();

            if (this.DbConnection())
            {
                string StringQuery = "SELECT * FROM Orders";
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

                    Orders.Add(new Order(id, order_date, shipping_adresse, shipping_date, quantity));
                }
                Reader.Close();
                Connection.Close();
            }

           return Orders; 
        }

        public List<Supplier> GetSuppliers()
        {
            List<Supplier> Suppliers = new List<Supplier>();

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
 
                    Suppliers.Add(new Supplier(id, siret, name, contact, location, label));
                }
                Reader.Close();
                Connection.Close();
            }

           return Suppliers; 
        }

        
        public List<FidelityProgram> GetFidelityPrograms()
        {
            List<FidelityProgram> fidelityPrograms = new List<FidelityProgram>();

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


                    fidelityPrograms.Add(new FidelityProgram(id, label, cost ,duration, discount));
                }
                Reader.Close();
                Connection.Close();
            }

           return fidelityPrograms; 
        }

        public List<OrderedPart> GetOrderParts()
        {
            List<OrderedPart> orderedParts = new List<OrderedPart>();

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

                    orderedParts.Add(new OrderedPart(id, orders_id, parts_id, quantity));
                }
                Reader.Close();
                Connection.Close();
            }

           return orderedParts; 
        }

        public List<OrderedBike> GetOrderBikes()
        {
            List<OrderedBike> orderedBikes = new List<OrderedBike>();

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

                    orderedBikes.Add(new OrderedBike(id, bikes_id, parts_id, quantity));
                }
                Reader.Close();
                Connection.Close();
            }

           return orderedBikes; 
        }

        public List<BikePart> GetBikesParts()
        {
            List<BikePart> bikeParts = new List<BikePart>();

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

                    bikeParts.Add(new BikePart(id, parts_id, bikes_id));
                }
                Reader.Close();
                Connection.Close();
            }

           return bikeParts; 
        }

        
        public List<Procurement> GetProcurement()
        {
            List<Procurement> procurements = new List<Procurement>();

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

                    procurements.Add(new Procurement(id, parts_id, suppliers_id));
                }
                Reader.Close();
                Connection.Close();
            }

           return procurements; 
        }

        
    }
}