using Restful_API.Data;
using Restful_API.Models.Entities;
using Restful_API.Repository.IRepository;

namespace Restful_API.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _db;
        public StudentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public Task Update(Student student)
        {
            _db.Update(student);
            return Task.CompletedTask;
        }
    }
}
