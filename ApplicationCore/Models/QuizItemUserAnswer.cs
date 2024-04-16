using ApplicationCore.Interfaces.Repository;

namespace BackendLab01;

public class QuizItemUserAnswer: IIdentity<string>
{
    public int QuizId { get; set; }
    public QuizItem  QuizItem{ get; set; }
    public int UserId { get; set; }
    public string Answer { get; set; }
    public QuizItemUserAnswer(int quizId, QuizItem quizItem, int userId, string answer)
    {
        QuizId = quizId;
        QuizItem = quizItem;
        UserId = userId;
        Answer = answer;        
    }

    public QuizItemUserAnswer()
    {
    }

    public bool IsCorrect()
    {
        return QuizItem.CorrectAnswer == Answer;
    }

    public string Id
    {
        get => $"{QuizId}{UserId}{QuizItem.Id}";
        set
        {
            
        }
    }
}