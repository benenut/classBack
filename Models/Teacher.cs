using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Teacher
    {
        [Key]
        public int IdProf {  get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

