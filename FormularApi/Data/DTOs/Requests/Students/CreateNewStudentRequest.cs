using System;
namespace FormularApi.Data.DTOs.Requests.Students
{
    public class CreateNewStudentRequest
    {
        public string Name { get; set; }
        public int GradeId { get; set; }
    }
}

