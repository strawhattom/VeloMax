using System;

namespace VeloMax.Models
{
    public class Order
    {
        public DateTime OrderDate { get; set;}
        public string ShippingAdress { get; set; }
        public string ShippinDate { get; set; }
        public int Quantity { get; set; }
        public int Id {get; set;}

        public Order(int id, DateTime orderDate, string shippingAdress, string shippingDate, int quantity)
        {
            if (shippingAdress is null || shippingDate is null)
            {
                System.Environment.Exit(0);
            }
            this.Id = id;
            this.OrderDate = orderDate;
            this.ShippingAdress = shippingAdress;
            this.ShippinDate = shippingDate;
            this.Quantity = quantity;
        }
    }
}