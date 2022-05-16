using System;

namespace VeloMax.Models
{
    public class OrderedPart
    {
        public int OrdersId { get; set; }
        public int PartsId { get; set; }
        public int Quantity { get; set; }
        public int Id {get; set;}

        public OrderedPart(int id, int orders_id, int parts_id, int quantity)
        {
            this.Id = id;
            this.OrdersId = orders_id;
            this.PartsId = parts_id;
            this.Quantity = quantity;
        }
    }
}