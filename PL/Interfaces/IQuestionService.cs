using PL.DTOs;

namespace PL.Interfaces
{
    public interface IQuestionService : IDisposable
    {
        Task<IEnumerable<Question>> GetAllQuestions();
        Task<IEnumerable<Question>> GetQuestionsByType(QuestionType type);
        Task<Question> GenerateQuestion();
        Task AddQuestion(Question question);
        Task AddQuestionType(QuestionType type);
    }
}
