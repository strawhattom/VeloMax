using System;

namespace VeloMax.Models
{
    public class OrderedBikes
    {
        public int OrdersId { get; set; }
        public int BikesId { get; set; }
        public int Quantity { get; set; }

        public OrderedBikes(int orders_id, int parts_id, int quantity)
        {
            this.OrdersId = orders_id;
            this.BikesId = parts_id;
            this.Quantity = quantity;
        }
    }
}