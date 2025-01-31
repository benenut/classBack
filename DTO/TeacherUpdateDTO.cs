using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class TeacherUpdateDTO
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
