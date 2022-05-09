using System;

namespace VeloMax.Models
{
    public class OrderedParts
    {
        public int OrdersId { get; set; }
        public int PartsId { get; set; }
        public int Quantity { get; set; }

        public OrderedParts(int orders_id, int parts_id, int quantity)
        {
            this.OrdersId = orders_id;
            this.PartsId = parts_id;
            this.Quantity = quantity;
        }
    }
}