using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace Parks.Models
{
    [Table("nationalPark")]
    public class NationalPark
    {
        [Key]
        public int NationalParkId { get; set; }
        public int StateId { get; set; }
        public string ParkName { get; set; }
       
        public double AvgRating { get; set; }
        public ICollection<Review> Reviews { get; set; }

        public void GetAvgRating()
        {
            Console.WriteLine("Getting average rating");
            double sum = 0;
            foreach (Review review in Reviews)
            {
                sum += review.Rating;
                Console.WriteLine("Sum = " + sum);
                Console.WriteLine("Reviews list: " + Reviews.Count);
            }
            AvgRating = sum / Reviews.Count;
        }

        public NationalPark()
        {
            this.Reviews = new HashSet<Review>();
        }

        
    }
}