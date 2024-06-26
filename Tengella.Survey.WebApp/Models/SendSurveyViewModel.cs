using Tengella.Survey.Data.Models;

namespace Tengella.Survey.WebApp.Models
{
    public class SendSurveyViewModel
    {
        public int SurveyObjectId { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public string Subject { get; set; }
        public string Message { get; set; }
        public string SurveyLink { get; set; } = "https://localhost:7128/SurveyObjects/";
    }
}
    