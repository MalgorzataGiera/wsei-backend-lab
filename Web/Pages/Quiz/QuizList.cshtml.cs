using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendLab01.Pages;

public class QuizListModel : PageModel
{

    public List<BackendLab01.Quiz> Quizzes { get; set; }
    private readonly IQuizUserService QuizUserService;
    public QuizListModel(IQuizUserService quizUserService)
    {
        QuizUserService = quizUserService;
    }


    public void OnGet()
    {
        Quizzes =  QuizUserService.GetAll();
    }

}