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

        public string[] attributs()
        {
            string[] attributs = new string[7];
            attributs[0]="Id";
            attributs[1]="orders_id";
            attributs[2]="parts_id";
            attributs[3]="quantity";
           
            

            return attributs;
        }

        public string at(int i)
        {
            switch(i)
            {
                case 0:
                    return this.Id.ToString();
                case 1:
                    return this.OrdersId.ToString();
                case 2:
                    return this.PartsId.ToString();
                case 3:
                    return this.Quantity.ToString();

                default:
                    return "";
            }    
        }

        public string typeC()
        {
            return "ordered_parts";
        }
    
    }
}