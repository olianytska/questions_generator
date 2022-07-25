using Microsoft.EntityFrameworkCore;
using PL.DTOs;
using PL.EF;
using PL.Interfaces;

namespace PL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private QuestionsDbContext context;

        private IRepository<Question> questionManager;
        private IRepository<QuestionType> questionTypeManager;

        public UnitOfWork(DbContextOptions<QuestionsDbContext> options)
        {
            context = new QuestionsDbContext(options);
            questionManager = new QuestionManager(context);
            questionTypeManager = new QuestionTypeManager(context);
        }

        public IRepository<Question> QuestionManager => questionManager;

        public IRepository<QuestionType> QuestionTypeManager => questionTypeManager;

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    questionManager.Dispose();
                    questionTypeManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
