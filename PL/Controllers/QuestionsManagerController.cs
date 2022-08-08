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
        private readonly ILogger<QuestionsManagerController> _logger;

        public QuestionsManagerController(IQuestionService questionService, ILogger<QuestionsManagerController> logger)
        {
            _questionService = questionService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetAllQuestion()
        {
            IEnumerable<Question> questions = await _questionService.GetAllQuestions();
            if(questions == null)
            {
                throw new Exception("There are no questions");
                return NoContent();
            }
            return questions.ToList();
        }
        [HttpGet("question")]
        public async Task<ActionResult<Question>> GetQuestion()
        {
            Question question = await _questionService.GenerateQuestion();
            if (question == null)
            {
                throw new Exception("There are no question");
                return NotFound();
            }
            return question;
        }
        [HttpPost]
        public async Task<ActionResult<Question>> CreateQuestion(Question question)
        {
            try
            {
                await _questionService.AddQuestion(question);
                return CreatedAtAction(nameof(GetQuestion), question);
            }
            catch(Exception e)
            {
                throw new Exception($"Something went wrong: {e.Message}");
            }
            
        }
    }
}
