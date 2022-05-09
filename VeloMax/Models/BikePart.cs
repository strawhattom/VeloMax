using System;

namespace VeloMax.Models
{
    public class BikePart
    {
        public int PartId { get; set; }
        public int BikeId { get; set; }

        public BikePart(int partId, int bikeId)
        {
            this.PartId = partId;
            this.BikeId = bikeId;
        }
    }
}