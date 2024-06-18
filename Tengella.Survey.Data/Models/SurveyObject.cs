using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Models
{
    public class SurveyObject
    {
        public SurveyObject() 
        {
            Questions = new HashSet<Question>();
        }
        public int SurveyObjectId { get; set; }
        //FK
        public int UserId { get; set; }
        public string SurveyTitle { get; set; } = string.Empty;
        public string SurveyDescription { get; set; } = string.Empty;
        public string SurveyType { get; set; } = string.Empty;
        //Navigation
        public User? User { get; set; }
        public ICollection<Question> Questions { get; set; }

    }
}
