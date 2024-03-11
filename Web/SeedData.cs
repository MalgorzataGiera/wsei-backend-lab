using ApplicationCore.Interfaces.Repository;
using BackendLab01;

namespace Infrastructure.Memory;
public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();
            AddSampleQuizzes(quizRepo, quizItemRepo);
        }
    }
    private static void AddSampleQuizzes(IGenericRepository<Quiz, int> quizRepo, IGenericRepository<QuizItem, int> quizItemRepo)
    {
        var quiz1Items = new List<QuizItem>
            {
                new QuizItem(1, "Pytanie 1", new List<string> {"Odpowiedź 1", "Odpowiedź 2", "Odpowiedź 3"}, "Odpowiedź poprawna"),
                new QuizItem(2, "Pytanie 2", new List<string> {"Odpowiedź 1", "Odpowiedź 2", "Odpowiedź 3"}, "Odpowiedź poprawna"),
                new QuizItem(3, "Pytanie 3", new List<string> {"Odpowiedź 1", "Odpowiedź 2", "Odpowiedź 3"}, "Odpowiedź poprawna")
            };
        var quiz1 = new Quiz(1, quiz1Items, "Quiz 1");
        quizRepo.Add(quiz1); 
        foreach (var item in quiz1Items)
        {
            quizItemRepo.Add(item); 
        }

        var quiz2Items = new List<QuizItem>
            {
                new QuizItem(1, "Pytanie 1", new List<string> {"Odpowiedź 1", "Odpowiedź 2", "Odpowiedź 3"}, "Odpowiedź poprawna"),
                new QuizItem(2, "Pytanie 2", new List<string> {"Odpowiedź 1", "Odpowiedź 2", "Odpowiedź 3"}, "Odpowiedź poprawna"),
                new QuizItem(3, "Pytanie 3", new List<string> {"Odpowiedź 1", "Odpowiedź 2", "Odpowiedź 3"}, "Odpowiedź poprawna")
            };
        var quiz2 = new Quiz(2, quiz2Items, "Quiz 2");
        quizRepo.Add(quiz2); 
        foreach (var item in quiz2Items)
        {
            quizItemRepo.Add(item); 
        }

    }
}