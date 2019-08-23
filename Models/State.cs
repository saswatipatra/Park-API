using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parks.Models
{
    [Table("states")]
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string Country { get; set; }
        public string StateName { get; set; }
        public string City { get; set; }
        public double AvgRating { get; set; }
        
        public ICollection<NationalPark> NationalParks { get; set; }

        public void GetAvgRating()
        {
            Console.WriteLine("Getting average rating");
            double sum = 0;
            foreach (NationalPark nationalPark in NationalParks)
            {
                sum += nationalPark.Rating;
                Console.WriteLine("Sum = " + sum);
                Console.WriteLine("NationalParks list: " + NationalParks.Count);
            }
            AvgRating = sum / NationalParks.Count;
        }

        public State()
        {
            this.NationalParks = new HashSet<NationalPark>();
        }
    }
}