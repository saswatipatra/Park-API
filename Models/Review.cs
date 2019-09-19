using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parks.Models
{
    [Table("reviews")]
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int NationalParkId{get;set;}
        public string UserName { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        
    }
}