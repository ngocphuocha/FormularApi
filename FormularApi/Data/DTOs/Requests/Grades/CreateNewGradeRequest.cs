using System;
using FormularApi.Models;
using System.ComponentModel.DataAnnotations;

namespace FormularApi.Data.DTOs.Requests.Grades
{
    public class CreateNewGradeRequest
    {
        [Required]
        public string GradeName { get; set; }
        [Required]
        public string Section { get; set; }
    }
}
