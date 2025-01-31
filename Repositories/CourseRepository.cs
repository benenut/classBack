using WebApplication1.CourseDbContext;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class CourseRepository
    {
        public readonly CourseContext _context;

        public CourseRepository(CourseContext context)
        {
            _context = context;
        }

        public List<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }

        public void CreateCourse(CourseCreateDTO course)
        {
            Course c = new Course
            {
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                IdTeacher = course.IdTeacher,
                IdSubject = course.IdSubject,
            };

            _context.Courses.Add(c);
            _context.SaveChanges();
        }

        public void UpdateCourse(CourseUpdateDTO course, int courseId)
        {
            Course c = _context.Courses.Find(courseId);

            if (c == null)
                throw new BadHttpRequestException("La course n'existe pas");

            c.StartDate = course.StartDate;
            c.EndDate = course.EndDate;
            c.IdTeacher = course.IdTeacher;
            c.IdSubject = course.IdSubject;

            _context.Courses.Update(c);
            _context.SaveChanges();
        }
    }
}
