using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.EF
{
    public class QuestionsDbContext : DbContext
    {
        public QuestionsDbContext(DbContextOptions<QuestionsDbContext> options)
        : base(options)
        {
        }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
    }

    public class QuestionsDbContextFactory : IDesignTimeDbContextFactory<QuestionsDbContext>
    {
        public QuestionsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<QuestionsDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Interview_questions;Username=postgres;Password=Qwerty123;");

            return new QuestionsDbContext(optionsBuilder.Options);
        }
    }
}
