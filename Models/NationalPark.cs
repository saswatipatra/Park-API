using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parks.Models
{
    [Table("nationalPark")]
    public class NationalPark
    {
        [Key]
        public int NationalParkId { get; set; }
        public int StateId { get; set; }
        public string ParkName { get; set; }
        public int Rating { get; set; }
        public string NationalParkNotes { get; set; }
        
    }
}