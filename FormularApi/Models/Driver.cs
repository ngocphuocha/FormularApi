using System.ComponentModel.DataAnnotations;

namespace FormularApi.Models
{
    public class Driver
    {
        public int Id { get; set; }
        //[StringLength(8, ErrorMessage = "Name length can't be more than 8.")]
        public string? Name { get; set; }  
        public string? Team { get; set; }
        //[Required]
        public int DriverNumber { get; set; }
    }
}
