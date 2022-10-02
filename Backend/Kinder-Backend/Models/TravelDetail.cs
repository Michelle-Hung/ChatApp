using System;

namespace Kinder_Backend.Models
{
    public class TravelDetail
    {
        public int Id { get; set; }
        public string Attraction { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Context { get; set; }
        public string PictureName { get; set; }
    }
}