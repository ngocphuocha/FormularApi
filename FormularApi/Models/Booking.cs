using System.ComponentModel.DataAnnotations;

namespace FormularApi.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string CurrentAddress { get; set; }
        public string Address { get; set; }
        public string TargetAddress {get; set;}
    }
}
