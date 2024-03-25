namespace Restful_API.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IStudentRepository Student { get; }
        Task Save();
    }
}
