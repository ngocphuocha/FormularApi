using System;

namespace FormularApi.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public Grade Grade { get; set; }
    }
}
