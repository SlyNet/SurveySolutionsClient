using System;

namespace SurveySolutionsClient.Models
{
    public record GeoPosition
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Accuracy { get; set; }
        public double Altitude { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}