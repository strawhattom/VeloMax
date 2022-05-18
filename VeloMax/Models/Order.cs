using System;

namespace VeloMax.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set;}
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

        public string[] attributs()
        {
            string[] attributs = new string[5];
            attributs[0]="Id";
            attributs[1]="order_date";
            attributs[2]="shipping_address";
            attributs[3]="shipping_date";
            attributs[4]="quantity";

            return attributs;
        }

        public string at(int i)
        {
            switch(i)
            {
                case 0:
                    return this.Id.ToString();
                case 1:
                    return "'"+this.OrderDate.ToString("yyyy-MM-dd")+"'";
                case 2:
                    return "'"+this.ShippingAdress+"'";
                case 3:
                    return "'"+this.ShippinDate.ToString("yyyy-MM-dd")+"'";
                case 4:
                    return this.Quantity.ToString();
                default:
                    return "";
            }    
        }

        public string typeC()
        {
            return "orders";
        }
    }
    
}