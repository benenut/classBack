using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.CourseDbContext
{
    public class CourseContext : IdentityDbContext<Users, Role, string>
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options) 
        {
            
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Users> Users { get; set; } 
    }
}


