using System;
using System.Collections.Generic;
using VeloMax.Models;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace VeloMax.Services
{
    public class Database
    {
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

        public void SetValue(MySqlConnection connection, string modify)
        {
            
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = modify;
            command.ExecuteNonQuery();
             
        }

        public Boolean ModifyBike(Bike bike)
        {
            if(this.DbConnection())
            {
                string[] tab = bike.attributs();

                string modify = "UPDATE Bike SET";
                for(int i = 0; i < tab.Length; i++)
                {
                    modify+=tab[i] + "=" + bike.at(i);
                }
                    
                modify += "WHERE id = " + bike.at(0);

                SetValue(Connection, modify);
                return true;   
            }
            return false;
        }

        public Boolean CreateBike(Bike bike)
        {
            string[] tab = bike.attributs();

            string create = "Insert into `velomax`.`Bike` (";
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += tab[i] + ',';
            }
            create+=tab[tab.Length-1] + ") Value (" ;
            
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += bike.at(i) + ',';
            }
            create+=bike.at(tab.Length-1) + ')';

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
                string[] tab = order.attributs();

                string modify = "UPDATE Bike SET";
                for(int i = 0; i < tab.Length; i++)
                {
                    modify+=tab[i] + "=" + order.at(i);
                }
                    
                modify += "WHERE id = " + order.at(0);

                SetValue(Connection, modify);
                return true;   
            }
            return false;
        }

        public Boolean CreateOrder(Order order)
        {
            string[] tab = order.attributs();

            string create = "Insert into `velomax`.`Bike` (";
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += tab[i] + ',';
            }
            create+=tab[tab.Length-1] + ") Value (" ;
            
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += order.at(i) + ',';
            }
            create+= order.at(tab.Length-1) + ')';

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
                string[] tab = part.attributs();

                string modify = "UPDATE Bike SET";
                for(int i = 0; i < tab.Length; i++)
                {
                    modify+=tab[i] + "=" + part.at(i);
                }
                    
                modify += "WHERE id = " + part.at(0);

                SetValue(Connection, modify);
                return true;   
            }
            return false;
        }

        public Boolean CreatePart(Part part)
        {
            string[] tab = part.attributs();

            string create = "Insert into `velomax`.`Bike` (";
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += tab[i] + ',';
            }
            create+=tab[tab.Length-1] + ") Value (" ;
            
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += part.at(i) + ',';
            }
            create+= part.at(tab.Length-1) + ')';

            if(this.DbConnection())
            {
                SetValue(Connection,create);
                return true;
            }
            return false;
        }

        public Boolean ModifySupplier(Supplier supplier)
        {
            if(this.DbConnection())
            {
                string[] tab = supplier.attributs();

                string modify = "UPDATE Bike SET ";
                for(int i = 0; i < tab.Length; i++)
                {
                    modify+=tab[i] + "=" + supplier.at(i);
                }
                    
                modify += "WHERE id = " + supplier.at(0);

                SetValue(Connection, modify);
                return true;   
            }
            return false;
        }

        public Boolean CreateSupplier(Supplier supplier)
        {
            string[] tab = supplier.attributs();

            string create = "Insert into `velomax`.`Bike` (";
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += tab[i] + ',';
            }
            create+=tab[tab.Length-1] + ") Value (" ;
            
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += supplier.at(i) + ',';
            }
            create+= supplier.at(tab.Length-1) + ')';

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
                string[] tab = fidelity.attributs();

                string modify = "UPDATE Bike SET";
                for(int i = 0; i < tab.Length; i++)
                {
                    modify+=tab[i] + "=" + fidelity.at(i);
                }
                    
                modify += "WHERE id = " + fidelity.at(0);

                SetValue(Connection, modify);
                return true;   
            }
            return false;
        }

        public Boolean CreateFidelityProgram(FidelityProgram fidelity)
        {
            string[] tab = fidelity.attributs();

            string create = "Insert into `velomax`.`Bike` (";
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += tab[i] + ',';
            }
            create+=tab[tab.Length-1] + ") Value (" ;
            
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += fidelity.at(i) + ',';
            }
            create+= fidelity.at(tab.Length-1) + ')';

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
                string[] tab = orderedBike.attributs();

                string modify = "UPDATE Bike SET";
                for(int i = 0; i < tab.Length; i++)
                {
                    modify+=tab[i] + "=" + orderedBike.at(i);
                }
                    
                modify += "WHERE id = " + orderedBike.at(0);

                SetValue(Connection, modify);
                return true;   
            }
            return false;
        }

        public Boolean CreateOrderBikes(OrderedBike orderedBike)
        {
            string[] tab = orderedBike.attributs();

            string create = "Insert into `velomax`.`Bike` (";
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += tab[i] + ',';
            }
            create+=tab[tab.Length-1] + ") Value (" ;
            
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += orderedBike.at(i) + ',';
            }
            create+= orderedBike.at(tab.Length-1) + ')';

            if(this.DbConnection())
            {
                SetValue(Connection,create);
                return true;
            }
            return false;
        }

        public Boolean ModifyOrderParts(OrderedPart orderedPart)
        {
            if(this.DbConnection())
            {
                string[] tab = orderedPart.attributs();

                string modify = "UPDATE Bike SET";
                for(int i = 0; i < tab.Length; i++)
                {
                    modify+=tab[i] + "=" + orderedPart.at(i);
                }
                    
                modify += "WHERE id = " + orderedPart.at(0);

                SetValue(Connection, modify);
                return true;   
            }
            return false;
        }

        public Boolean CreateOrderParts(OrderedPart orderedPart)
        {
            string[] tab = orderedPart.attributs();

            string create = "Insert into `velomax`.`Bike` (";
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += tab[i] + ',';
            }
            create+=tab[tab.Length-1] + ") Value (" ;
            
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += orderedPart.at(i) + ',';
            }
            create+= orderedPart.at(tab.Length-1) + ')';

            if(this.DbConnection())
            {
                SetValue(Connection,create);
                return true;
            }
            return false;
        }

        public Boolean ModifyBikeParts(BikePart bikePart)
        {
            if(this.DbConnection())
            {
                string[] tab = bikePart.attributs();

                string modify = "UPDATE Bike SET";
                for(int i = 0; i < tab.Length; i++)
                {
                    modify+=tab[i] + "=" + bikePart.at(i);
                }
                    
                modify += "WHERE id = " + bikePart.at(0);

                SetValue(Connection, modify);
                return true;   
            }
            return false;
        }

        public Boolean CreateBikeParts(BikePart bikePart)
        {
            string[] tab = bikePart.attributs();

            string create = "Insert into `velomax`.`Bike` (";
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += tab[i] + ',';
            }
            create+=tab[tab.Length-1] + ") Value (" ;
            
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += bikePart.at(i) + ',';
            }
            create+= bikePart.at(tab.Length-1) + ')';

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
                string[] tab = procurement.attributs();

                string modify = "UPDATE Bike SET";
                for(int i = 0; i < tab.Length; i++)
                {
                    modify+=tab[i] + "=" + procurement.at(i);
                }
                    
                modify += "WHERE id = " + procurement.at(0);

                SetValue(Connection, modify);
                return true;   
            }
            return false;
        }

        public Boolean CreateProcurment(Procurement procurement)
        {
            string[] tab = procurement.attributs();

            string create = "Insert into `velomax`.`Bike` (";
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += tab[i] + ',';
            }
            create+=tab[tab.Length-1] + ") Value (" ;
            
            for(int i = 0; i< tab.Length-1;i++)
            {
                create += procurement.at(i) + ',';
            }
            create+= procurement.at(tab.Length-1) + ')';

            if(this.DbConnection())
            {
                SetValue(Connection,create);
                return true;
            }
            return false;
        }

        public List<string> BestPart()
        {
            string[] date = DateTime.Now.ToString().Split('/');
            string mois = date[0];
            string year = date[2].Split(' ')[0];
            string best = "SELECT P.description , sum(OP.quantity), sum(OP.quantity)*P.unit_price, avg(OP.Quantity) "+
                        "FROM ordered_parts OP JOIN parts P ON OP.parts_id=P.id JOIN orders O ON OP.orders_id = O.id "+
                        "WHERE O.shipping_date>'" + year + "-" + mois + "-01' "+
                        "GROUP BY P.id" +
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
            return bestlist;
        }
        public List<string> BestBike()
        {
            string[] date = DateTime.Now.ToString().Split('/');
            string mois = date[0];
            string year = date[2].Split(' ')[0];
            string best = "SELECT B.name , sum(OB.quantity), sum(OB.quantity)*B.unit_price, avg(OB.Quantity) "+
                        "FROM ordered_bikes OB JOIN bikes B ON OB.bikes_id=B.id JOIN orders O ON OB.orders_id = O.id "+
                        "WHERE O.shipping_date>'" + year + "-" + mois + "-01' "+
                        "GROUP BY B.id " +
                        "HAVING sum(OB.quantity)>= all(SELECT sum(quantity) FROM ordered_bikes GROUP BY bikes_id)";
            
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
        

        public List<List<string>> ClientsFidelity()
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

                    int j=0;
                    while (Reader.Read())
                        {
                            if(Reader.GetInt32(0)==5)
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


        public List<List<string>> ClientExpirationDate()
        {
            string best = "SELECT id, last_name, first_name, expiration_date FROM individuals;";
            
            List<List<string>>expiration = new List<List<string>>();

            if (this.DbConnection())
                {
                    MySqlDataReader Reader = Query(Connection, best);

                    int j=0;
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


        public List<List<string>> BestClients()
        {
            
            List<List<string>> bestclients = new List<List<string>>();

            if (this.DbConnection())
            {
                string best = "Select C.company_name ,sum(O.quantity) "+
                    "FROM orders O JOIN professionals C ON C.id = O.id_client "+
                    "group by C.id "+
                    "GROUP BY B.id " +
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
        
        public List<int> Average()
        {
            string best = "Select avg(Bp.quantity*B.unit_price + Pp.quantity * P.unit_price), avg(Bp.quantity), avg(Pp.quantity)"+
                        "From orders O JOIN ordered_bikes Bp ON O.id=Bp.orders_id"+
                        "Join bikes B on B.id = Bp.bikes_id"+
                        "join ordered_parts Pp on Pp.orders_id = O.id" +
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
    }
}
