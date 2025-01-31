using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class CourseUpdateDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IdTeacher { get; set; }
        public int IdSubject { get; set; }
    }
}
