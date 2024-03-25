using Restful_API.Data;
using Restful_API.Models.Entities.Master;
using Restful_API.Repository.IRepository;

namespace Restful_API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IStudentRepository Student { get; set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Student = new StudentRepository(_db);
        }

        public async Task Save()
        {
           await _db.SaveChangesAsync();
        }
    }
}
