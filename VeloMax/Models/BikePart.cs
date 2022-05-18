using System;

namespace VeloMax.Models
{
    public class BikePart
    {
        public int PartId { get; set; }
        public int BikeId { get; set; }
        public int Id { get; set; }


        public BikePart(int id, int partId, int bikeId)
        {
            this.Id = id;
            this.PartId = partId;
            this.BikeId = bikeId;
        }

        public static string[] Attributs()
        {
            string[] attributs = new string[7];
            attributs[0] = "Id";
            attributs[1] = "parts_id";
            attributs[2] = "bikes_id";

            return attributs;
        }

        public string At(int i)
        {
            return i switch
            {
                0 => this.Id.ToString(),
                1 => this.PartId.ToString(),
                2 => this.BikeId.ToString(),
                _ => "",
            };
        }

        public static string TypeC()
        {
            return "bike_parts";
        }
    }

}