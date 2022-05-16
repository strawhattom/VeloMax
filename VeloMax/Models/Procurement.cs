using System;

namespace VeloMax.Models{

    public class Procurement
    {
        public int PartId { get; set; }
        public int SupplierId { get; set; }
        public int Id {get; set;}

        public Procurement(int id, int parts_id, int suppliers_id){
            this.Id = id;
            this.PartId = parts_id;
            this.SupplierId = suppliers_id;
        }
    }
}