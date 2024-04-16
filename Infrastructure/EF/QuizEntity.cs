using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF
{
    public class QuizEntity
    {
        //public QuizEntity(int id, string title, ISet<QuizItemEntity> items)
        //{
        //    Id = id;
        //    Title = title;
        //    Items = items;
        //}

        public int Id { get; set; }
        public string Title { get; set; }
        public ISet<QuizItemEntity> Items { get; set; } = new HashSet<QuizItemEntity>();
    }
}

