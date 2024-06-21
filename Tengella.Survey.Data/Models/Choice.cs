using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Models
{
    public class Choice
    {
        public int ChoiceId { get; set; }
        //FK
        public int QuestionId { get; set; }
        public int? Position { get; set; }
        public string? Text { get; set; }
    }
}
