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
    }
}