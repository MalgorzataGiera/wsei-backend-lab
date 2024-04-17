using BackendLab01;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;

namespace WebApi.Controllers
{
    public class QuizController : ControllerBase
    {
        private IQuizUserService _service;

        public QuizController(IQuizUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Policy = "Bearer")]
        [Route("{quizId}/items/{itemId}/answers")]
        public ActionResult SaveAnswer([FromBody] QuizItemAnswerDto dto, int quizId, int itemId)
        {
            try
            {
                var answer = _service.SaveUserAnswerForQuiz(quizId, itemId, dto.UserId, dto.UserAnswer);
                return Created("", answer);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
