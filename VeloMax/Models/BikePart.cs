using System;

namespace VeloMax.Models
{
    public class BikePart
    {
        public int PartId { get; set; }
        public int BikeId { get; set; }
        public int Id {get; set;}


        public BikePart(int id, int partId, int bikeId)
        {
            this.Id = id;
            this.PartId = partId;
            this.BikeId = bikeId;
        }

        public string[] attributs()
        {
            string[] attributs = new string[7];
            attributs[0]="Id";
            attributs[1]="parts_id";
            attributs[2]="bikes_id";

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
                    return this.BikeId.ToString();

                default:
                    return null;
            }    
        }
    }
}