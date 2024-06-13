namespace Tengella.Survey.WebApp.Models
{
    public class SurveyViewModel
    {
        public int SurveyId { get; set; }
        public string SurveyTitle { get; set; }
        public string SurveyDescription { get; set; }
        public List<QuestionViewModel> SurveyQuestions { get; set; }
    }
}
