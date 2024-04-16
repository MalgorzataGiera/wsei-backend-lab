using AutoMapper;
using BackendLab01;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using WebApi.DTO;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/v1/admin/quizzes")]
    public class ApiQuizAdminController : ControllerBase
    {
        private IQuizAdminService _service;
        private IMapper _mapper;
        private IValidator _validator;

        public ApiQuizAdminController(IQuizAdminService service, IMapper mapper, IValidator validator)
        {
            _service = service;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpPost]
        public ActionResult<Quiz> CreateQuiz(LinkGenerator linker, NewQuizDto dto)
        {
            var quiz = _service.AddQuiz(new Quiz() { Title = dto.Title });
            return Created(
                linker.GetUriByAction(HttpContext, nameof(GetQuiz), null, new { quizId = quiz.Id }),
                quiz
            );
        }

        [HttpGet]
        [Route("{quizId}")]
        public ActionResult<Quiz> GetQuiz(int quizId)
        {
            var quiz = _service.FindAllQuizzes().FirstOrDefault(q => q.Id == quizId);
            return quiz is null ? NotFound() : quiz;
        }

        [HttpPatch]
        [Route("{quizId}")]
        [Consumes("application/json-patch+json")]
        public ActionResult<Quiz> AddQuizItem(int quizId, JsonPatchDocument<Quiz>? patchDoc)
        {
            var quiz = _service.FindAllQuizzes().FirstOrDefault(q => q.Id == quizId);
            if (quiz is null || patchDoc is null)
            {
                return NotFound(new
                {
                    error = $"Quiz width id {quizId} not found"
                });
            }
            int previousCount = quiz.Items.Count;
            patchDoc.ApplyTo(quiz, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (previousCount < quiz.Items.Count)
            {
                QuizItem item = quiz.Items[^1];
                quiz.Items.RemoveAt(quiz.Items.Count - 1);
                item.Id = quiz.Items.Count() + 1;
                _service.AddQuizItemToQuiz(quizId, item);
            }
            return Ok(_service.FindAllQuizzes().FirstOrDefault(q => q.Id == quizId));
        }

        [HttpPost]
        [Route("{quizId}")]
        [Consumes("application/json-patch+json")]
        public ActionResult<object> AddQuiz(LinkGenerator link, int quizId, NewQuizDto dto)
        {
            var quiz = _service.AddQuiz(_mapper.Map<Quiz>(dto));
            quiz.Id = quizId;
            string uri = link.GetPathByAction(HttpContext, nameof(GetQuiz), null, new { quizId = quiz.Id });

            return Created(uri, quiz);
        }
    }
}