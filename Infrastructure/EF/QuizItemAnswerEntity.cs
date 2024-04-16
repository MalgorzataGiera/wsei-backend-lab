using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF
{
    public class QuizItemAnswerEntity
    {
        //public QuizItemAnswerEntity(int id, string answer, ISet<QuizItemEntity> quizItems)
        //{
        //    Id = id;
        //    Answer = answer;
        //    QuizItems = quizItems;
        //}

        public int Id { get; set; }
        public string Answer { get; set; }
        public ISet<QuizItemEntity> QuizItems { get; set; } = new HashSet<QuizItemEntity>();
    }
}

