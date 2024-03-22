using Microsoft.EntityFrameworkCore;
using Restful_API.Models.Entities;

namespace Restful_API.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) { }
        
        public DbSet<School> School { get; set; }
        public DbSet<Student> Student { get; set; }
    }
}
