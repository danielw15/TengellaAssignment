using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerName { get; set; }
        public int QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}
