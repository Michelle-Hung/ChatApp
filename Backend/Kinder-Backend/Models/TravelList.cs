using System;

namespace Kinder_Backend.Models
{
    public class TravelList
    {
        public int Id { get; set; }
        public string Attraction { get; set; }
        public DateTime StartDate { get;  set; }
        public string PictureName {get; set;}
    }
}