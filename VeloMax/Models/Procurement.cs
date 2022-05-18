using System;

namespace VeloMax.Models
{

    public class Procurement
    {
        public int Id { get; set; }
        public int PartId { get; set; }
        public int SupplierId { get; set; }

        public Procurement(int id, int parts_id, int suppliers_id)
        {
            this.Id = id;
            this.PartId = parts_id;
            this.SupplierId = suppliers_id;
        }

        public static string[] Attributs()
        {
            string[] attributs = new string[7];
            attributs[0] = "Id";
            attributs[1] = "parts_id";
            attributs[2] = "suppliers_id";

            return attributs;
        }

        public string At(int i)
        {
            return i switch
            {
                0 => this.Id.ToString(),
                1 => this.PartId.ToString(),
                2 => this.SupplierId.ToString(),
                _ => "",
            };
        }

        public static string TypeC()
        {
            return "procurement";
        }

    }
}