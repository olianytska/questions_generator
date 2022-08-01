using PL.DTOs;
using PL.EF;
using PL.Interfaces;

namespace PL.Repositories
{
    public class QuestionManager : IRepository<Question>
    {
        private readonly QuestionsDbContext context;
        public QuestionManager(QuestionsDbContext context)
        {
            this.context = context;
        }
        public void Create(Question item)
        {
            context.Questions.Add(item);
        }

        public void Delete(Question item)
        {
            if (context.Questions.Find(item) != null)
                context.Questions.Remove(item);
        }

        public IEnumerable<Question> GetAllItems()
        {
            return context.Questions;
        }

        public void Update(Question item)
        {
            var i = context.Questions.Find(item);
            context.Entry(i).CurrentValues.SetValues(item);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
