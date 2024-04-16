using Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendLab01;

namespace Infrastructure.Mappers
{
    public class QuizMapper
    {
        public static QuizItem FromEntityToQuizItem(QuizItemEntity entity)
        {
            return new QuizItem(
                entity.Id,
                entity.Question,
                entity.IncorrectAnswers.Select(e => e.Answer).ToList(),
                entity.CorrectAnswer);
        }

        public static Quiz FromEntityToQuiz(QuizEntity entity)
        {
            List<QuizItem> items = new List<QuizItem>();
            foreach (var i in entity.Items)
                items.Add(FromEntityToQuizItem(i));
            return new Quiz(
                entity.Id,
                entity.Title,
                items);
        }

        public static QuizItemUserAnswer FromEntityToQuizItemUserAnswer(QuizItemUserAnswerEntity entity)
        {
            return new QuizItemUserAnswer(
              entity.QuizId,              
              FromEntityToQuizItem(entity.QuizItem),
              entity.UserId,
              entity.UserAnswer);
        }
    }
}
