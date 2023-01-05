using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

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
        [Required]
        public string Phone { get; set; }
        [Required]
        public string TargetAddress {get; set;}
    }
}
