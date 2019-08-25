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
        
        public ICollection<NationalPark> NationalParks { get; set; } 
        public ICollection<Review> Reviews { get; set; }

        
        public State()
        {
            this.NationalParks = new HashSet<NationalPark>();
            this.Reviews = new HashSet<Review>();
        }
    }
}