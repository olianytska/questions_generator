using PL.DTOs;
using PL.EF;
using PL.Interfaces;

namespace PL.Repositories
{
    public class QuestionTypeManager : IRepository<QuestionType>
    {
        private readonly QuestionsDbContext context;
        public QuestionTypeManager(QuestionsDbContext context)
        {
            this.context = context;
        }
        public void Create(QuestionType item)
        {
            context.QuestionTypes.Add(item);
        }

        public void Delete(QuestionType item)
        {
            if (context.QuestionTypes.Find(item) != null)
                context.QuestionTypes.Remove(item);
        }

        public IEnumerable<QuestionType> GetAllItems()
        {
            return context.QuestionTypes;
        }

        public void Update(QuestionType item)
        {
            var i = context.QuestionTypes.Find(item);
            context.Entry(i).CurrentValues.SetValues(item);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
