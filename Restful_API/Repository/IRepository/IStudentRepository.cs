using Restful_API.Models.Entities;

namespace Restful_API.Repository.IRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task Update(Student student);
    }
}
