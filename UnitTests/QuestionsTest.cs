using log4net.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using PL.Controllers;
using PL.DTOs;
using PL.EF;
using PL.Interfaces;
using PL.Repositories;
using PL.Services;

namespace UnitTests
{
    public class Tests
    {
        private List<QuestionType> _questionTypes;
        private Mock<IRepository<Question>> _questionRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IQuestionService> _mockQuestionService;
        private List<Question> _questions;
        private QuestionsManagerController _questionController;

        [SetUp]
        public void Setup()
        {
            _questionTypes = new List<QuestionType>(){ new QuestionType{ QuestionTypeId = 1, Name = "ООП" }, new QuestionType { QuestionTypeId = 2, Name = "Angular" } };
            _questions = new List<Question>(){
                new Question { QuestionId = 1, Title = "Что такое ООП?", Answer = "ООП (объектно-ориентированное программирование)", QuestionTypeId = _questionTypes.ElementAt(0).QuestionTypeId, QuestionType = _questionTypes.ElementAt(0) },
                new Question { QuestionId = 2, Title= "Зачем использовать ООП?", Answer= "ООП обеспечивает ясность в программировании", QuestionTypeId = _questionTypes.ElementAt(0).QuestionTypeId, QuestionType = _questionTypes.ElementAt(0) },
                new Question { QuestionId = 3, Title = "Назовите основные принципы ООП", Answer= "Наследование, Инкапсуляция, Полиморфизм, Абстракция", QuestionTypeId = _questionTypes.ElementAt(0).QuestionTypeId, QuestionType = _questionTypes.ElementAt(0) } 
            };

            _questionRepository = new Mock<IRepository<Question>>();
            _questionRepository.Setup(x => x.GetAllItems()).Returns(_questions.AsQueryable());

            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(x => x.QuestionManager).Returns(_questionRepository.Object);

            _mockQuestionService = new Mock<IQuestionService>();
            _mockQuestionService.Setup(x => x.GetAllQuestions()).Returns(Task.FromResult(_questions.AsEnumerable()));

            var mockLogger = Mock.Of<ILogger<QuestionsManagerController>>();

            _questionController = new QuestionsManagerController(_mockQuestionService.Object, mockLogger);

        }

        [Test]
        public void GetAllQuestionsTest()
        {
            var expected = _questions.AsEnumerable();
            var actualRepo = _questionRepository.Object.GetAllItems().AsEnumerable();
            var actualService = _mockQuestionService.Object.GetAllQuestions().Result;
            var actualController = _questionController.GetAllQuestion().Result;

            Assert.AreEqual(expected, actualRepo);
            Assert.AreEqual(expected, actualService);
            Assert.AreEqual(expected, actualController.Value);
        }
    }
}