using System;

namespace velomax_class{

    class Procurement
    {
        public int PartsId{get; set;}
        public int SuppliersId{get; set;}

        public Procurement(int parts_id, int suppliers_id){
            this.PartsId=parts_id;
            this.SuppliersId=suppliers_id;
        }
    }
}