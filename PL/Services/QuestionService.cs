using PL.DTOs;
using PL.Interfaces;

namespace PL.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork unitOfWork;
        public QuestionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task AddQuestion(Question question)
        {
            unitOfWork.QuestionManager.Create(question);
            await unitOfWork.SaveAsync();
        }

        public async Task AddQuestionType(QuestionType type)
        {
            unitOfWork.QuestionTypeManager.Create(type);
            await unitOfWork.SaveAsync();
        }

        public async Task<Question> GenerateQuestion()
        {
            Random random = new Random();
            int randomId = random.Next(unitOfWork.QuestionManager.GetAllItems().Min(q => q.QuestionId), unitOfWork.QuestionManager.GetAllItems().Max(q => q.QuestionId));
            return unitOfWork.QuestionManager.GetAllItems().First(q => q.QuestionId == randomId);
        }

        public async Task<IEnumerable<Question>> GetAllQuestions()
        {
            return unitOfWork.QuestionManager.GetAllItems();
        }

        public async Task<IEnumerable<Question>> GetQuestionsByType(QuestionType type)
        {
            return unitOfWork.QuestionManager.GetAllItems().Where(q => q.QuestionType == type);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    unitOfWork.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
