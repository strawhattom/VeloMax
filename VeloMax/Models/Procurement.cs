using System;

namespace VeloMax.Models{

    public class Procurement
    {
        public int Id { get; set; }
        public int PartId { get; set; }
        public int SupplierId { get; set; }

        public Procurement(int id, int parts_id, int suppliers_id){
            this.Id = id;
            this.PartId = parts_id;
            this.SupplierId = suppliers_id;
        }

        public string[] attributs()
        {
            string[] attributs = new string[7];
            attributs[0]="Id";
            attributs[1]="parts_id";
            attributs[2]="suppliers_id";

            return attributs;
        }

        public string at(int i)
        {
            switch(i)
            {
                case 0:
                    return this.Id.ToString();
                case 1:
                    return this.PartId.ToString();
                case 2:
                    return this.SupplierId.ToString();

                default:
                    return null;
            }    
        }
    }
}