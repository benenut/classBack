using WebApplication1.CourseDbContext;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class SubjectRepository
    {
        public readonly CourseContext _context;

        public SubjectRepository(CourseContext context)
        {
            _context = context;
        }

        public List<Subject> GetSubjects()
        {
            return _context.Subjects.ToList();
        }

        public void CreateSubject(SubjectCreateDTO subject)
        {
            Subject s = new Subject
            {
                Name = subject.Name,
            };

            _context.Subjects.Add(s);
            _context.SaveChanges();
        }

        public void UpdateSubject(SubjectUpdateDTO subject, int subjectId)
        {
            Subject s = _context.Subjects.Find(subjectId);

            if (s == null)
                throw new BadHttpRequestException("Le sujet n'existe pas");

            s.Name = subject.Name;

            _context.Subjects.Update(s);
            _context.SaveChanges();
        }
    }
}
