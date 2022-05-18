using System;

namespace VeloMax.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShippingAdress { get; set; }
        public DateTime ShippinDate { get; set; }
        public int Quantity { get; set; }

        public Order(int id, DateTime orderDate, string shippingAdress, DateTime shippingDate, int quantity)
        {
            if (shippingAdress is null)
            {
                System.Environment.Exit(0);
            }
            this.Id = id;
            this.OrderDate = orderDate;
            this.ShippingAdress = shippingAdress;
            this.ShippinDate = shippingDate;
            this.Quantity = quantity;
        }

        public string[] Attributs()
        {
            string[] attributs = new string[5];
            attributs[0] = "Id";
            attributs[1] = "order_date";
            attributs[2] = "shipping_address";
            attributs[3] = "shipping_date";
            attributs[4] = "quantity";

            return attributs;
        }

        public string At(int i)
        {
            return i switch
            {
                0 => this.Id.ToString(),
                1 => "'" + this.OrderDate.ToString("yyyy-MM-dd") + "'",
                2 => "'" + this.ShippingAdress + "'",
                3 => "'" + this.ShippinDate.ToString("yyyy-MM-dd") + "'",
                4 => this.Quantity.ToString(),
                _ => "",
            };
        }

        public static string TypeC()
        {
            return "orders";
        }
    }

}