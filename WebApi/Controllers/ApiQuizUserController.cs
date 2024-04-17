using ApplicationCore.Exceptions;
using BackendLab01;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/users/quizzes")]
    public class ApiQuizUserController : ControllerBase
    {
        private IQuizUserService _service;

        public ApiQuizUserController(IQuizUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<QuizDTO> FindQuizById(int id) 
        {
            var quiz = _service.FindQuizById(id);
            return quiz is null ? NotFound() : QuizDTO.Of(quiz);
        }

        [HttpPost]
        [Route("{quizId}/items/{itemId}/answers")]
        public ActionResult SaveAnswer(int quizId, int itemId, AnswerDTO dto)
        {
            try
            {
                _service.SaveUserAnswerForQuiz(quizId, userId: 1, itemId, dto.Answer);
                return Ok();
            }
            catch (DuplicateAnswerException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("{quizId}/answers")]
        public ActionResult<object> ReturnFeedback(int quizId)
        {
            int correct = _service.CountCorrectAnswersForQuizFilledByUser(quizId, 1);
            return new
            {
                CorrectAnswers = correct,
                QuizId = quizId,
                UserId = 1
            };                
        }

    }
}
