using PL.DTOs;

namespace PL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<QuestionType> QuestionTypeManager { get; }
        IRepository<Question> QuestionManager { get; }
        Task SaveAsync();
    }
}
