using System;

namespace VeloMax.Models
{
    public class OrderedPart
    {
        public int Id { get; set; }
        public int OrdersId { get; set; }
        public int PartsId { get; set; }
        public int Quantity { get; set; }

        public OrderedPart(int id, int orders_id, int parts_id, int quantity)
        {
            this.Id = id;
            this.OrdersId = orders_id;
            this.PartsId = parts_id;
            this.Quantity = quantity;
        }

        public static string[] Attributs()
        {
            string[] attributs = new string[7];
            attributs[0] = "Id";
            attributs[1] = "orders_id";
            attributs[2] = "parts_id";
            attributs[3] = "quantity";
            return attributs;
        }

        public string At(int i)
        {
            return i switch
            {
                0 => this.Id.ToString(),
                1 => this.OrdersId.ToString(),
                2 => this.PartsId.ToString(),
                3 => this.Quantity.ToString(),
                _ => "",
            };
        }

        public static string TypeC()
        {
            return "ordered_parts";
        }

    }
}