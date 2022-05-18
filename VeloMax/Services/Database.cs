using System;
using System.Collections.Generic;
using VeloMax.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Globalization;

namespace VeloMax.Services
{
    public class Database
    {
        #region Basic
        private string StringConnection = Config.Connection;
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

        public int GetMaxID(string table)
        {
            string requete = "SELECT max(id) FROM "+table;
            int max=-1;
            if(this.DbConnection())
            {
                MySqlDataReader Reader = Query(Connection, requete);
                int j=0;
                
                while(Reader.Read() && j<1)
                {
                    max=Reader.GetInt32(0);  
                }
            }
            return max+1;
        }

        public void SetValue(MySqlConnection connection, string modify)
        {
            Debug.WriteLine("QUERY :");
            Debug.WriteLine(modify);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = modify;
            command.ExecuteNonQuery();
             
        }
        #endregion

        #region Get
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
                DateTime expirationDate;
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

                    try
                    {
                        expirationDate = Reader.GetDateTime(10);
                    } catch (System.Data.SqlTypes.SqlNullValueException)
                    {
                        expirationDate = new DateTime(0001, 1, 1);
                    }
                    
                    List.Add(new Individual(Id, FirstName, LastName, Street, City, PostalCode, Province, Phone, Mail, FidelityId, expirationDate));
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


        public List<Part> GetPartsMinQty(int qty)
        {
            List<Part> List = new List<Part>();

            if (this.DbConnection())
            {
                string StringQuery = "SELECT * FROM parts WHERE quantity < " + qty;
                MySqlDataReader Reader = Query(Connection, StringQuery);

                string Description, type;
                double unit_price;
                int procurement_delay, quantity, Id;
                DateTime discontinuation_date, introduction_date;

                while (Reader.Read())
                {
                    Id = Reader.GetInt32(0);
                    Description = Reader.GetString(1);
                    unit_price = Reader.GetDouble(2);
                    introduction_date = Reader.GetDateTime(3);
                    discontinuation_date = Reader.GetDateTime(4);
                    procurement_delay = Reader.GetInt32(5);
                    quantity = Reader.GetInt32(6);
                    type = Reader.GetString(7);

                    if (Description is null || type is null)
                    {
                        System.Environment.Exit(0);
                    }
                    List.Add(new Part(Id,Description, unit_price, introduction_date, discontinuation_date, procurement_delay, quantity, type));
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

                string Description, type;
                double unit_price;
                int procurement_delay, quantity, Id;
                DateTime discontinuation_date, introduction_date;

                while (Reader.Read())
                {
                    Id = Reader.GetInt32(0);
                    Description = Reader.GetString(1);
                    unit_price = Reader.GetDouble(2);
                    introduction_date = Reader.GetDateTime(3);
                    discontinuation_date = Reader.GetDateTime(4);
                    procurement_delay = Reader.GetInt32(5);
                    quantity = Reader.GetInt32(6);
                    type = Reader.GetString(7);

                    if (Description is null || type is null)
                    {
                        System.Environment.Exit(0);
                    }
                    List.Add(new Part(Id,Description, unit_price, introduction_date, discontinuation_date, procurement_delay, quantity, type));
                }
                Reader.Close();
                Connection.Close();
            }

            return List;
        }
        
        public List<Bike> GetBikes(string search)
        {
            List<Bike> List = new List<Bike>();

            if (this.DbConnection())
            {
                string StringQuery = "SELECT * "+
                                     "FROM bikes "+
                                     "WHERE name LIKE '"+search+"%' OR target LIKE '" + search + "%' OR type LIKE '" + search + "%';";
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

        #endregion

        #region Modify/Create

        public Boolean CreateClient(Client client)
        {
            if(this.DbConnection())
            {
                string[] tab = client.Attributs();

                string create = "Insert into `velomax`.`clients` (";
                for(int i = 0; i< 6;i++)
                {
                    create += tab[i] + ',';
                }
                create+=tab[6] + ") Value (" ;
                
                for(int i = 0; i< 6;i++)
                {
                    create += client.At(i) + ',';
                }
                create+= client.At(6) + ')';

                if(this.DbConnection())
                {
                    SetValue(Connection,create);
                }

                create = "Insert into `velomax`.`" + client.TypeC() + "` (id,";
                for(int i = 7; i< tab.Length-1;i++)
                {
                    create += tab[i] + ',';
                }
                create+=tab[tab.Length - 1] + ") Value ("+client.Id +", ";
                
                for(int i = 7; i< tab.Length-1;i++)
                {
                    create += client.At(i) + ',';
                }
                create+= client.At(tab.Length - 1) + ')';

                if(this.DbConnection())
                {
                    SetValue(Connection,create);
                }
            }
            return false;
        }

        public Boolean ModifyClient(Client client)
        {
            if(this.DbConnection())
            {
                string[] tab = client.Attributs();

                string modify = "UPDATE clients SET ";
                for(int i = 0; i < 6; i++)
                {
                    modify+=tab[i] + " = " + client.At(i) + ", \n";
                }
                modify += tab[6] + " = " + client.At(6) +" ";
                modify += " WHERE id = " + client.At(0);

                    SetValue(Connection, modify);

                    modify = "UPDATE " + client.TypeC() + " SET ";
                for(int i = 7; i < tab.Length-1; i++)
                {
                    modify+=tab[i] + " = " + client.At(i)+", \n";
                }
                modify += tab[tab.Length-1] + " = " + client.At(tab.Length-1) +" ";
                modify += "WHERE id = " + client.At(0);

                SetValue(Connection, modify);
            }
            return false;
        }
        public Boolean ModifyBike(Bike bike)
        {
            if(this.DbConnection())
            {
                string[] tab = Bike.Attributs();

                string modify = "UPDATE bikes SET ";
                for(int i = 0; i < tab.Length-1; i++)
                {
                    modify+=tab[i] + " = " + bike.At(i) +", ";
                }
                modify += tab[tab.Length-1] + " = " + bike.At(tab.Length - 1);
                modify += " WHERE id = " + bike.At(0);

                SetValue(Connection, modify);
                return true;   
            }
            return false;
        }

        public Boolean CreateBike(Bike bike)
        {
            string[] tab = Bike.Attributs();

            string create = "Insert into `velomax`.`bikes` (";
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += tab[i] + ',';
            }
            create+=tab[tab.Length-1] + ") Value (" ;
            
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += bike.At(i) + ',';
            }
            create+=bike.At(tab.Length-1) + ')';

            if(this.DbConnection())
            {
                SetValue(Connection,create);
                return true;
            }
            return false;
        }

        public Boolean ModifyOrder(Order order)
        {
            if(this.DbConnection())
            {
                string[] tab = Order.Attributs();

                string modify = "UPDATE orders SET";
                for(int i = 0; i < tab.Length; i++)
                {
                    modify+=tab[i] + " = " + order.At(i) +", ";

                }
                    
                modify += tab[tab.Length-1] + " = " + order.At(tab.Length - 1);
                modify += "WHERE id = " + order.At(0);

                SetValue(Connection, modify);
                return true;   
            }
            return false;
        }

        public Boolean CreateOrder(Order order)
        {
            string[] tab = Order.Attributs();

            string create = "Insert into `velomax`.`orders` (";
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += tab[i] + ',';
            }
            create+=tab[tab.Length-1] + ") Value (" ;
            
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += order.At(i) + ',';
            }
            create+= order.At(tab.Length-1) + ')';

            if(this.DbConnection())
            {
                SetValue(Connection,create);
                return true;
            }
            return false;
        }

        public Boolean ModifyParts(Part part)
        {
            if(this.DbConnection())
            {
                string[] tab = Part.Attributs();

                string modify = "UPDATE parts SET ";
                for(int i = 0; i < tab.Length-1 ; i++)
                {
                    modify+=tab[i] + " = " + part.At(i) +", ";

                }
                
                modify += tab[tab.Length-1] + " = " + part.At(tab.Length - 1);
                modify += "WHERE id = " + part.At(0);

                SetValue(Connection, modify);
                return true;   
            }
            return false;
        }

        public Boolean CreatePart(Part part)
        {
            string[] tab = Part.Attributs();

            string create = "Insert into `velomax`.`parts` (";
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += tab[i] + ',';
            }
            Debug.WriteLine("Column name OK");
            create +=tab[tab.Length-1] + ") Value (" ;
            Debug.WriteLine("Last column name OK");

            for (int i = 0; i< tab.Length-1;i++)
            {
                create += part.At(i) + ',';
            }

            create+= part.At(tab.Length-1) + ')';
            Debug.WriteLine("Values OK");
            if (this.DbConnection())
            {
                Debug.WriteLine("Part created");
                SetValue(Connection,create);
                return true;
            }
            Debug.WriteLine("Part not created");
            return false;
        }

        public Boolean ModifySupplier(Supplier supplier)
        {
            if(this.DbConnection())
            {
                string[] tab = Supplier.Attributs();

                string modify = "UPDATE suppliers SET ";
                for(int i = 0; i < tab.Length - 1; i++)
                {
                    modify+=tab[i] + " = " + supplier.At(i) +", ";

                }
                modify += tab[tab.Length-1] + " = " + supplier.At(tab.Length - 1);
                modify += "WHERE id = " + supplier.At(0);

                SetValue(Connection, modify);
                return true;   
            }
            return false;
        }

        public Boolean CreateSupplier(Supplier supplier)
        {
            string[] tab = Supplier.Attributs();

            string create = "Insert into `velomax`.`supliers` (";
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += tab[i] + ',';
            }
            create+=tab[tab.Length-1] + ") Value (" ;
            
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += supplier.At(i) + ',';
            }
            create+= supplier.At(tab.Length-1) + ')';

            if(this.DbConnection())
            {
                SetValue(Connection,create);
                return true;
            }
            return false;
        }

        public Boolean ModifyFildelityProgram(FidelityProgram fidelity)
        {
            if(this.DbConnection())
            {
                string[] tab = FidelityProgram.Attributs();

                string modify = "UPDATE fidelity_programs SET ";
                for(int i = 0; i < tab.Length - 1; i++)
                {
                    modify+=tab[i] + " = " + fidelity.At(i) +", ";
                }
                
                modify += tab[tab.Length-1] + " = " + fidelity.At(tab.Length - 1);

                modify += "WHERE id = " + fidelity.At(0);

                SetValue(Connection, modify);
                return true;   
            }
            return false;
        }

        public Boolean CreateFidelityProgram(FidelityProgram fidelity)
        {
            string[] tab = FidelityProgram.Attributs();

            string create = "Insert into `velomax`.`fidelity_programs` (";
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += tab[i] + ',';
            }
            create+=tab[tab.Length-1] + ") Value (" ;
            
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += fidelity.At(i) + ',';
            }
            create+= fidelity.At(tab.Length-1) + ')';

            if(this.DbConnection())
            {
                SetValue(Connection,create);
                return true;
            }
            return false;
        }

        public Boolean ModifyOrderBikes(OrderedBike orderedBike)
        {
            if(this.DbConnection())
            {
                string[] tab = OrderedBike.Attributs();

                string modify = "UPDATE ordered_bikes SET ";
                for(int i = 0; i < tab.Length - 1; i++)
                {
                    modify+=tab[i] + " = " + orderedBike.At(i) +", ";

                }
                
                modify += tab[tab.Length-1] + " = " + orderedBike.At(tab.Length - 1);

                modify += "WHERE id = " + orderedBike.At(0);

                SetValue(Connection, modify);
                return true;   
            }
            return false;
        }

        public Boolean CreateOrderBikes(OrderedBike orderedBike)
        {
            if(CheckInStock(orderedBike.BikesId, orderedBike.TypeC(), orderedBike.Quantity)==false){
                return false;
            }
            string[] tab = OrderedBike.Attributs();

            string create = "Insert into `velomax`.`ordered_bikes` (";
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += tab[i] + ',';
            }
            create+=tab[tab.Length-1] + ") Value (" ;
            
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += orderedBike.At(i) + ',';
            }
            create+= orderedBike.At(tab.Length-1) + ')';

            if(this.DbConnection())
            {
                SetValue(Connection,create);
                
            }
            else
            {
                return false;
            }
            ModifyStock(orderedBike.BikesId, orderedBike.TypeC(), orderedBike.Quantity);
            return true;
        }

        public Boolean ModifyOrderParts(OrderedPart orderedPart)
        {
            
            if(this.DbConnection())
            {
                string[] tab = OrderedPart.Attributs();

                string modify = "UPDATE ordered_parts SET ";
                for(int i = 0; i < tab.Length - 1; i++)
                {
                    modify+=tab[i] + " = " + orderedPart.At(i) +", ";
                }
                modify += tab[tab.Length-1] + " = " + orderedPart.At(tab.Length - 1);

                modify += " WHERE id = " + orderedPart.At(0);

                SetValue(Connection, modify);
                return true;   
            }
            return false;
        }

        public Boolean CreateOrderParts(OrderedPart orderedPart)
        {
            if(CheckInStock(orderedPart.PartsId, OrderedPart.TypeC(),orderedPart.Quantity) == false)
            {
                return false;
            }
            string[] tab = OrderedPart.Attributs();

            string create = "Insert into `velomax`.`ordered_parts` (";
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += tab[i] + ',';
            }
            create+=tab[tab.Length-1] + ") Value (" ;
            
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += orderedPart.At(i) + ',';
            }
            create+= orderedPart.At(tab.Length-1) + ')';

            if(this.DbConnection())
            {
                SetValue(Connection,create);
            }
            else
            {
                return false;
            }
            ModifyStock(orderedPart.PartsId, OrderedPart.TypeC(),orderedPart.Quantity);

            return true;
        }

        public Boolean ModifyBikeParts(BikePart bikePart)
        {
            if(this.DbConnection())
            {
                string[] tab = BikePart.Attributs();

                string modify = "UPDATE bike_parts SET ";
                for(int i = 0; i < tab.Length - 1; i++)
                {
                    modify+=tab[i] + " = " + bikePart.At(i) +", ";
                }
                modify += tab[tab.Length-1] + " = " + bikePart.At(tab.Length - 1);
                modify += "WHERE id = " + bikePart.At(0);

                SetValue(Connection, modify);
                return true;   
            }
            return false;
        }

        public Boolean CreateBikeParts(BikePart bikePart)
        {
            string[] tab = BikePart.Attributs();

            string create = "Insert into `velomax`.`bike_parts` (";
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += tab[i] + ',';
            }
            create+=tab[tab.Length-1] + ") Value (" ;
            
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += bikePart.At(i) + ',';
            }
            create+= bikePart.At(tab.Length-1) + ')';

            if(this.DbConnection())
            {
                SetValue(Connection,create);
                return true;
            }
            return false;
        }

        public Boolean ModifyProcurment(Procurement procurement)
        {
            if(this.DbConnection())
            {
                string[] tab = Procurement.Attributs();

                string modify = "UPDATE procurement SET ";
                for(int i = 0; i < tab.Length - 1; i++)
                {
                    modify+=tab[i] + " = " + procurement.At(i) +", ";
                }
                modify += tab[tab.Length-1] + " = " + procurement.At(tab.Length - 1);   
                modify += "WHERE id = " + procurement.At(0);

                SetValue(Connection, modify);
                return true;   
            }
            return false;
        }

        public Boolean CreateProcurment(Procurement procurement)
        {
            string[] tab = Procurement.Attributs();

            string create = "Insert into `velomax`.`procurement` (";
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += tab[i] + ',';
            }
            create+=tab[tab.Length-1] + ") Value (" ;
            
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += procurement.At(i) + ',';
            }
            create+= procurement.At(tab.Length-1) + ')';

            if(this.DbConnection())
            {
                SetValue(Connection,create);
                return true;
            }
            return false;
        }

        #endregion
        
        #region Statistics
        public List<string> BestPart() //les meilleur parts au sense quantite de vente sur le mois
        {
            string[] date = DateTime.Now.ToString().Split('/');
            string mois = date[1];
            string year = date[2].Split(' ')[0];
            string best = "SELECT P.description , sum(OP.quantity), sum(OP.quantity)*P.unit_price, avg(OP.Quantity) "+
                        "FROM ordered_parts OP JOIN parts P ON OP.parts_id=P.id JOIN orders O ON OP.orders_id = O.id "+
                        "WHERE O.shipping_date>'" + year + "-" + mois + "-01' "+
                        "GROUP BY P.id " +
                        "HAVING sum(OP.quantity)>= all(SELECT sum(quantity) FROM ordered_parts GROUP BY parts_id); ";

            List<string> bestlist = new List<string>();

            if (this.DbConnection())
                {
                    MySqlDataReader Reader = Query(Connection, best);

                    int j=0;
                    while (Reader.Read() & j<1)
                        {
                            for (int i = 0; i < Reader.FieldCount; i++)
                            {
                                {
                                    bestlist.Add(Reader.GetString(i));
                                }
                            }
                            j++;
                        }
                    Reader.Close();
                    Connection.Close();
            }
            foreach (var s in bestlist)
            {
                Debug.WriteLine(s);
            }
            return bestlist;
        }

        public List<string> BestBike()// meilleurs velo au sens quantite sur le mois
        {
            string[] date = DateTime.Now.ToString().Split('/');
            string mois = date[1];
            string year = date[2].Split(' ')[0];
            string best = "SELECT DISTINCT B.name , sum(OB.quantity), sum(OB.quantity)*B.unit_price, avg(OB.Quantity) "+
                        "FROM ordered_bikes OB JOIN bikes B ON OB.bikes_id=B.id JOIN orders O ON OB.orders_id = O.id "+
                        "WHERE O.shipping_date > '" + year + "-" + mois + "-01' "+
                        "GROUP BY B.id " +
                        "HAVING sum(OB.quantity)>= all(SELECT sum(quantity) FROM ordered_bikes GROUP BY bikes_id);";
            
            List<string> bestlist = new List<string>();

            if (this.DbConnection())
                {
                    MySqlDataReader Reader = Query(Connection, best);
                    int j=0;
                    while (Reader.Read() & j<1)
                        {
                            for (int i = 0; i < Reader.FieldCount; i++)
                            {
                                {
                                    bestlist.Add(Reader.GetString(i));
                                }
                            }
                            j++;
                        }
                    Reader.Close();
                    Connection.Close();
            }
            return bestlist;
        }
        

        public List<List<string>> ClientsFidelity() // List des clients et de leurs abonnement de fidelity
        {
            string best = "SELECT F.id, F.label, I.first_name, I.last_name "+
                        "FROM fidelity_programs F JOIN individuals I ON F.id = I.id_fidelity;";
            
            List<List<string>>clients = new List<List<string>>();

            if (this.DbConnection())
                {
                    MySqlDataReader Reader = Query(Connection, best);

                    List<string> fidelity0 = new List<string>();
                    List<string> fidelity1 = new List<string>();
                    List<string> fidelity2 = new List<string>();
                    List<string> fidelity3 = new List<string>();
                    List<string> fidelity4 = new List<string>();

                    while (Reader.Read())
                        {
                            if(Reader.GetInt32(0)==0)
                            {
                                fidelity0.Add(Reader.GetString(2)+' '+Reader.GetString(3));
                            }
                            if(Reader.GetInt32(0)==1)
                            {
                                fidelity1.Add(Reader.GetString(2)+' '+Reader.GetString(3));
                            }
                            if(Reader.GetInt32(0)==2)
                            {
                                fidelity2.Add(Reader.GetString(2)+' '+Reader.GetString(3));
                            }
                            if(Reader.GetInt32(0)==3)
                            {
                                fidelity3.Add(Reader.GetString(2)+' '+Reader.GetString(3));
                            }
                            if(Reader.GetInt32(0)==4)
                            {
                                fidelity4.Add(Reader.GetString(2)+' '+Reader.GetString(3));
                            }
                        }   
                    
                    Reader.Close();
                    Connection.Close();
                    clients.Add(fidelity0);
                    clients.Add(fidelity1);
                    clients.Add(fidelity2);
                    clients.Add(fidelity3);
                    clients.Add(fidelity4);
            }
            return clients;
        }


        public List<List<string>> ClientExpirationDate() //la date d expiration des cartes de fidelité des clients
        {
            string best = "SELECT id, last_name, first_name, expiration_date FROM individuals;";
            
            List<List<string>>expiration = new List<List<string>>();

            if (this.DbConnection())
                {
                    MySqlDataReader Reader = Query(Connection, best);

                    while (Reader.Read())
                        {
                            List<string>  clients = new List<string>();
                            clients.Add(Reader.GetInt32(0).ToString());
                            clients.Add(Reader.GetString(1));
                            clients.Add(Reader.GetString(2));
                            clients.Add(Reader.GetDateTime(3).ToString());
                            expiration.Add(clients);
                        }   
                    
                    Reader.Close();
                    Connection.Close();
                    
            }
            return expiration;
        }


        public List<List<string>> BestClients() // les clients qui ont le plus achete (souvent des professionnels)
        {
            
            List<List<string>> bestclients = new List<List<string>>();

            if (this.DbConnection())
            {
                string best = "Select C.company_name ,sum(O.quantity) "+
                    "FROM orders O JOIN professionals C ON C.id = O.id_client "+
                    "group by C.id "+ 
                    "Having sum(O.quantity) >= all(Select sum(O.quantity) FROM orders O group by id_client);";

                MySqlDataReader Reader = Query(Connection, best);

                while (Reader.Read())
                    {
                        List<string>  clients = new List<string>();
                        clients.Add(Reader.GetString(0));
                        clients.Add(Reader.GetInt32(1).ToString());
                        bestclients.Add(clients);
                    }   
                
                Reader.Close();

                best = "Select C.first_name, C.last_name, sum(O.quantity) "+
                    "FROM orders O JOIN individuals C ON C.id = O.id_client "+
                    "group by C.id "+
                    "Having sum(O.quantity) >= all(Select sum(O.quantity) FROM orders O group by id_client);";

                Reader = Query(Connection, best);

                while (Reader.Read())
                {
                    List<string>  clients = new List<string>();
                    clients.Add(Reader.GetString(0)+' '+Reader.GetString(1));
                    clients.Add(Reader.GetInt32(2).ToString());
                    bestclients.Add(clients);
                }
                Reader.Close();
                Connection.Close(); 
            }
            return bestclients;
        }
        
        public List<int> Average() //Le prix moyen par commande, la quantite moyenne de piece vendu, la quantite moyenne de velo vendus
        {
            string best = "Select avg(Bp.quantity*B.unit_price + Pp.quantity * P.unit_price), avg(Bp.quantity), avg(Pp.quantity) "+
                        "From orders O JOIN ordered_bikes Bp ON O.id=Bp.orders_id "+
                        "Join bikes B on B.id = Bp.bikes_id "+
                        "join ordered_parts Pp on Pp.orders_id = O.id " +
                        "join parts P on P.id = Pp.parts_id;";
            
            List<int> average = new List<int>();

            if (this.DbConnection())
                {
                    MySqlDataReader Reader = Query(Connection, best);

                    while (Reader.Read())
                        {
                            for (int i = 0; i < Reader.FieldCount; i++)
                            {
                                {
                                    average.Add(Reader.GetInt32(i));
                                }
                            }
                            
                        }
                    Reader.Close();
                    Connection.Close();
            }
            return average;
        
        }

        public List<List<List<string>>> StockPartsByBikes(string type="name") // range selon l argument donné (argument appartient a table bikes) 
                                                                            //et le place en premier argument de la grande liste
        {
            string best = "SELECT B."+type+", P.description, P.Quantity "+
                        "FROM bikes B JOIN bike_parts Br ON B.id=Br.bikes_id " +
                        "JOIN parts P ON P.id=Br.parts_id "+
                        "ORDER BY B."+type+";"; 
            
            List<List<List<string>>> Parts = new List<List<List<string>>>();
            List<List<string>> Velo = new List<List<string>>();

            if (this.DbConnection())
                {
                    MySqlDataReader Reader = Query(Connection, best);
                    string tmp="";
                    while (Reader.Read())
                        {
                            string nombike = Reader.GetString(0);
                    if(nombike==tmp)
                    {
                        List<string> piece = new List<string>();
                        piece.Add(Reader.GetString(1));
                        piece.Add(Reader.GetInt32(2).ToString());

                        Velo.Add(piece);
                    }
                    else
                    {
                        tmp = Reader.GetString(0);
                        Parts.Add(Velo);
                        List<string> nom = new List<string>();
                        nom.Add(tmp);
                        Velo = new List<List<string>>();
                        Velo.Add(nom);
                        List<string> piece = new List<string>();
                        piece.Add(Reader.GetString(1));
                        piece.Add(Reader.GetInt32(2).ToString());
                        Velo.Add(piece);

                    }
                    Reader.Close();
                    Connection.Close();
                }
            }
            return Parts;
        }

        public List<string> StockParts() //Donne les stocks de chaque parts
        {
            string best = "SELECT P.description, P.quantity FROM parts P";
            
            List<string> Parts = new List<string>();

            if (this.DbConnection())
            {
                MySqlDataReader Reader = Query(Connection, best);

                while (Reader.Read())
                    {
                        for (int i = 0; i < Reader.FieldCount; i++)
                        {
                            {
                                Parts.Add(Reader.GetValue(i).ToString());
                            }
                        }
                        
                    }
                Reader.Close();
                Connection.Close();
            }
            return Parts;
        }

        public List<List<List<string>>> StockPartsBySuppliers() // la quantite en stock range par suppliers (supplier premier terme de la grande liste)
        {
            string best = "SELECT S.name, P.description, P.Quantity "+
                        "FROM suppliers S JOIN procurement Pr ON S.id=Pr.suppliers_id " +
                        "JOIN parts P ON P.id=Pr.parts_id "+
                        "ORDER BY S.name;"; 
            
            List<List<List<string>>> Parts = new List<List<List<string>>>();
            List<List<string>> Velo = new List<List<string>>();

            if (this.DbConnection())
                {
                    MySqlDataReader Reader = Query(Connection, best);
                    string tmp="";
                    while (Reader.Read())
                        {
                            string nombike = Reader.GetString(0);
                    if(nombike==tmp)
                    {
                        List<string> piece = new List<string>();
                        piece.Add(Reader.GetString(1));
                        piece.Add(Reader.GetInt32(2).ToString());

                        Velo.Add(piece);
                    }
                    else
                    {
                        tmp = Reader.GetString(0);
                        Parts.Add(Velo);
                        List<string> nom = new List<string>();
                        nom.Add(tmp);
                        Velo = new List<List<string>>();
                        Velo.Add(nom);
                        List<string> piece = new List<string>();
                        piece.Add(Reader.GetString(1));
                        piece.Add(Reader.GetInt32(2).ToString());
                        Velo.Add(piece);

                    }
                    Reader.Close();
                    Connection.Close();
                }
            }
            return Parts;
        }

        public List<List<string>> StockNull() //savoir quelles pieces sont a commander
        {
            string best = "SELECT P.id, P.description FROM parts P WHERE P.quantity = 0;";
            
            List<List<string>> Stock = new List<List<string>>();

            if (this.DbConnection())
                {
                    MySqlDataReader Reader = Query(Connection, best);

                    while (Reader.Read())
                        {
                            List<string>  clients = new List<string>();
                            clients.Add(Reader.GetString(0));
                            clients.Add(Reader.GetString(1));
                            Stock.Add(clients);
                        }   
                    
                    Reader.Close();
                    Connection.Close();
                    
            }
            return Stock;
        }

        public List<string> WorstSuppliers()
        {
            string worst = "SELECT DISTINCT S.name "+
                        "FROM suppliers S JOIN procurement Pr ON Pr.suppliers_id = S.id "+
                        "JOIN parts P ON P.id = Pr.parts_id "+
                        "WHERE S.label <= all(SELECT label FROM suppliers);";

            List<string> worstSuppliers = new List<string>();

            if(this.DbConnection())
            {
                MySqlDataReader reader = Query(Connection, worst);
                while(reader.Read())
                {   
                    worstSuppliers.Add(reader.GetString(0));
                }
            }

            return worstSuppliers;
        }

            

        #endregion
        
        #region Delete
        public void DeleteBikes(Bike bike)
        {
            int id = bike.Id;
            string delete = "DELETE FROM bikes WHERE id="+id.ToString();
            if(this.DbConnection())
            {
                SetValue(Connection,delete);
            }
        }

        public Boolean DeleteParts(Part part)
        {
            if(CheckIfDeleteAvailable(part.Id))
            {
                Console.WriteLine("Parts is used by a bike");
                return false;
            }
            int id = part.Id;
            string delete = "DELETE FROM parts WHERE id="+id.ToString();
            if(this.DbConnection())
            {
                SetValue(Connection,delete);
            }
            return true;
        }

        public void DeleteClient(Client client)
        {
            int id = client.Id;
            string delete = "DELETE FROM clients WHERE id="+id.ToString();
            string delete_fille = "DELETE FROM"+ client.TypeC() +"WHERE id="+id.ToString();
            if(this.DbConnection())
            {
                SetValue(Connection,delete_fille);
                SetValue(Connection,delete);
                
            }
        }

        public void DeleteOrder(Order order)
        {
            int id = order.Id;
            string delete = "DELETE FROM orders WHERE id="+id.ToString();
            if(this.DbConnection())
            {
                SetValue(Connection,delete);
            }
        }

        public void DeleteSuppliers(Supplier supplier)
        {
            int id = supplier.Id;
            string delete = "DELETE FROM suppliers WHERE id="+id.ToString();
            if(this.DbConnection())
            {
                SetValue(Connection,delete);
            }
        }

        #endregion

        #region setTable
        public void SetBikes(Bike bike)
        {
            string id = bike.Id.ToString();
            bool exist=true;

            if(this.DbConnection())
            {
                string check = "SELECT count(*) FROM bikes WHERE id = "+id;
                MySqlDataReader Reader = Query(Connection, check);
                int j=0;
                
                while(Reader.Read() && j<1)
                {
                    if(Reader.GetInt32(0)==0)
                    {
                        exist=false;
                    }
                    j++;
                }
                Reader.Close();
                Connection.Close();
            }

            if(exist)
            {
                ModifyBike(bike);
            }
            else
            {
                CreateBike(bike);
            }
            
        }

         public void SetBikeParts(BikePart bike)
        {
            string id = bike.Id.ToString();
            bool exist=true;

            if(this.DbConnection())
            {
                string check = "SELECT count(*) FROM bike_parts WHERE id = "+id;
                MySqlDataReader Reader = Query(Connection, check);
                int j=0;
                
                while(Reader.Read() && j<1)
                {
                    if(Reader.GetInt32(0)==0)
                    {
                        exist=false;
                    }
                    j++;
                }
                Reader.Close();
                Connection.Close();
            }

            if(exist)
            {
                ModifyBikeParts(bike);
            }
            else
            {
                CreateBikeParts(bike);
            }
            
        }

         public void SetClients(Client objects)
        {
            string id = objects.Id.ToString();
            bool exist=true;

            if(this.DbConnection())
            {
                string check = "SELECT count(*) FROM "+ objects.TypeC() + "WHERE id = "+id;
                MySqlDataReader Reader = Query(Connection, check);
                int j=0;
                
                while(Reader.Read() && j<1)
                {
                    if(Reader.GetInt32(0)==0)
                    {
                        exist=false;
                    }
                    j++;
                }
                Reader.Close();
                Connection.Close();
            }

            if(exist)
            {
                ModifyClient(objects);
            }
            else
            {
                CreateClient(objects);
            }
            
        }

        public void SetFidelityProgram(FidelityProgram objects)
        {
            string id = objects.Id.ToString();
            bool exist=true;

            if(this.DbConnection())
            {
                string check = "SELECT count(*) FROM "+ FidelityProgram.TypeC() +" WHERE id = "+id;
                MySqlDataReader Reader = Query(Connection, check);
                int j=0;
                
                while(Reader.Read() && j<1)
                {
                    if(Reader.GetInt32(0)==0)
                    {
                        exist=false;
                    }
                    j++;
                }
                Reader.Close();
                Connection.Close();
            }

            if(exist)
            {
                ModifyFildelityProgram(objects);
            }
            else
            {
                CreateFidelityProgram(objects);
            }
            
        }

        public void SetOrderBikes(OrderedBike objects)
        {
            string id = objects.Id.ToString();
            bool exist=true;

            if(this.DbConnection())
            {
                string check = "SELECT count(*) FROM "+ objects.TypeC() +" WHERE id = "+id;
                MySqlDataReader Reader = Query(Connection, check);
                int j=0;
                
                while(Reader.Read() && j<1)
                {
                    if(Reader.GetInt32(0)==0)
                    {
                        exist=false;
                    }
                    j++;
                }
                Reader.Close();
                Connection.Close();
            }

            if(exist)
            {
                ModifyOrderBikes(objects);
            }
            else
            {
                CreateOrderBikes(objects);
            }
            
        }

        public void SetOrderParts(OrderedPart objects)
        {
            string id = objects.Id.ToString();
            bool exist=true;

            if(this.DbConnection())
            {
                string check = "SELECT count(*) FROM "+ OrderedPart.TypeC() +" WHERE id = "+id;
                MySqlDataReader Reader = Query(Connection, check);
                int j=0;
                
                while(Reader.Read() && j<1)
                {
                    if(Reader.GetInt32(0)==0)
                    {
                        exist=false;
                    }
                    j++;
                }
                Reader.Close();
                Connection.Close();
            }

            if(exist)
            {
                ModifyOrderParts(objects);
            }
            else
            {
                CreateOrderParts(objects);
            }
            
        }

        public void SetParts(Part objects)
        {
            string id = objects.Id.ToString();
            bool exist=true;

            if(this.DbConnection())
            {
                string check = "SELECT count(*) FROM "+ Part.TypeC() +" WHERE id = "+id;
                MySqlDataReader Reader = Query(Connection, check);
                int j=0;
                
                while(Reader.Read() && j<1)
                {
                    if(Reader.GetInt32(0)==0)
                    {
                        exist=false;
                    }
                    j++;
                }
                Reader.Close();
                Connection.Close();
            }

            if(exist)
            {
                ModifyParts(objects);
            }
            else
            {
                CreatePart(objects);
            }
            
        }
        

        public void SetProcurement(Procurement objects)
        {
            string id = objects.Id.ToString();
            bool exist=true;

            if(this.DbConnection())
            {
                string check = "SELECT count(*) FROM "+ Procurement.TypeC() +" WHERE id = "+id;
                MySqlDataReader Reader = Query(Connection, check);
                int j=0;
                
                while(Reader.Read() && j<1)
                {
                    if(Reader.GetInt32(0)==0)
                    {
                        exist=false;
                    }
                    j++;
                }
                Reader.Close();
                Connection.Close();
            }

            if(exist)
            {
                ModifyProcurment(objects);
            }
            else
            {
                CreateProcurment(objects);
            }
            
        }

        public void SetSuppliers(Supplier objects)
        {
            string id = objects.Id.ToString();
            bool exist=true;

            if(this.DbConnection())
            {
                string check = "SELECT count(*) FROM " + Supplier.TypeC() +" WHERE id = "+id;
                MySqlDataReader Reader = Query(Connection, check);
                int j=0;
                
                while(Reader.Read() && j<1)
                {
                    if(Reader.GetInt32(0)==0)
                    {
                        exist=false;
                    }
                    j++;
                }
                Reader.Close();
                Connection.Close();
            }

            if(exist)
            {
                ModifySupplier(objects);
            }
            else
            {
                CreateSupplier(objects);
            }
            
        }

        #endregion

        #region Gestion
        public Boolean CheckInStock(int idPiece, string table ,int order_quantity)
        {
            string check = "SELECT quantity FROM "+table +" WHERE id= "+idPiece.ToString();
            bool inStock = true;
            if(this.DbConnection())
            {
                MySqlDataReader Reader = Query(Connection, check);
                int j=0;
                int Stock=int.MinValue;
                while(Reader.Read() && j<0)
                {
                    Stock = Reader.GetInt32(0);
                    j++;
                }
                if(Stock < order_quantity)
                {
                    inStock = false;
                }

            }
            return inStock;
        }

        public void ModifyStock(int id, string table, int change)
        {
            string changes = "UPDATE"+ table +"SET quantity = (SELECT quantity FROM parts WHERE id ="+ id + ") - 1 WHERE id = "+ id + ";";
            if(this.DbConnection())
            {
                SetValue(Connection, changes);
            }
        }

        public bool CheckIfDeleteAvailable(int id)
        {
            string search = "SELECT count(*), group_concat(B.name) "+
                            "From bikes B JOIN bike_parts Bp ON Bp.bikes_id = B.id "+
                            "WHERE Bp.parts_id = "+id;
            bool present=false;

            if(this.DbConnection())
            {
                MySqlDataReader Reader = Query(Connection, search);
                
                int j = 0;
                while(Reader.Read() && j < 1)
                {
                    if(Reader.GetInt32(0)>0)
                    {
                        present = true;

                    }
                    j++;
                }
            }
            return present;
        }

        public List<Part> Search(string search)
        {
            string part = " SELECT * "+
                            "FROM parts "+
                            "WHERE description LIKE '"+search+"%' OR type LIKE '" + search + "%';";
            
            List<Part> List = new List<Part>();

            if (this.DbConnection())
            {
                MySqlDataReader Reader = Query(Connection, part);

                string Description, type;
                double unit_price;
                int procurement_delay, quantity, Id;
                DateTime discontinuation_date, introduction_date;

                while (Reader.Read())
                {
                    Id = Reader.GetInt32(0);
                    Description = Reader.GetString(1);
                    unit_price = Reader.GetDouble(2);
                    introduction_date = Reader.GetDateTime(3);
                    discontinuation_date = Reader.GetDateTime(4);
                    procurement_delay = Reader.GetInt32(5);
                    quantity = Reader.GetInt32(6);
                    type = Reader.GetString(7);

                    if (Description is null || type is null)
                    {
                        System.Environment.Exit(0);
                    }
                    List.Add(new Part(Id,Description, unit_price, introduction_date, discontinuation_date, procurement_delay, quantity, type));
                }
                Reader.Close();
                Connection.Close();
            }

            return List;
            
        }

        #endregion
    }
}
