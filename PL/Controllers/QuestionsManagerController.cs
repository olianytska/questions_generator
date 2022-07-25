using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.DTOs;
using PL.EF;
using PL.Interfaces;

namespace PL.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionsManagerController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsManagerController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetAllQuestion()
        {
            IEnumerable<Question> questions = await _questionService.GetAllQuestions();
            return questions == null ? NotFound() : questions.ToList();
        }
        [HttpGet("question")]
        public async Task<ActionResult<Question>> GetQuestion()
        {
            Question question = await _questionService.GenerateQuestion();
            return question == null ? NotFound() : question;
        }
        [HttpPost]
        public async Task<ActionResult<Question>> CreateQuestion(Question question)
        {
            await _questionService.AddQuestion(question);
            return CreatedAtAction(nameof(GetQuestion), question);
        }
    }
}
