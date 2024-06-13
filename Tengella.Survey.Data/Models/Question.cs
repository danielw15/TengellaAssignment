using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Models
{
    public class Question
    {
        public Question() 
        {
            Answers = new HashSet<Answer>();
        }
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public int QuestionPosition { get; set; } = 0;
        public string QuestionType { get; set; }
        public ICollection<Answer> Answers { get; set; }
        //FK
        public int SurveyObjectId { get; set; }
        public SurveyObject? SurveyObject { get; set; }


    }
}
