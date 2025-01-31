using WebApplication1.CourseDbContext;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class TeacherRepository
    {
        public readonly CourseContext _context;

        public TeacherRepository(CourseContext context)
        {
            _context = context;
        }

        public List<Teacher> GetTeachers()
        {
            return _context.Teachers.ToList();
        }

        public void CreateTeacher(TeacherCreateDTO teacher)
        {
            Teacher t = new Teacher {
                BirthDate = teacher.BirthDate,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
            };

            _context.Teachers.Add(t);
            _context.SaveChanges();
        }

        public void UpdateTeacher(TeacherUpdateDTO teacher, int teacherId)
        {
            Teacher t = _context.Teachers.Find(teacherId);

            if (t == null)
                throw new BadHttpRequestException("Le professeur n'existe pas");

            t.BirthDate = teacher.BirthDate;
            t.FirstName = teacher.FirstName;
            t.LastName = teacher.LastName;

            _context.Teachers.Update(t);
            _context.SaveChanges();
        }
    }
}
