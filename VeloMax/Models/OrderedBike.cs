using System;

namespace VeloMax.Models
{
    public class OrderedBike
    {
        public int OrdersId { get; set; }
        public int BikesId { get; set; }
        public int Quantity { get; set; }
        public int Id {get; set;}

        public OrderedBike(int id, int orders_id, int parts_id, int quantity)
        {
            this.Id = id;
            this.OrdersId = orders_id;
            this.BikesId = parts_id;
            this.Quantity = quantity;
        }
    }
}