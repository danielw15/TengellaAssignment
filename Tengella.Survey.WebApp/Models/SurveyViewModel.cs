namespace Tengella.Survey.WebApp.Models
{
    public class SurveyViewModel
    {
        public int SurveyId { get; set; }
        public string SurveyTitle { get; set; } = string.Empty;
        public string SurveyDescription { get; set; } = string.Empty;
        public string SurveyType { get; set; } = string.Empty;
        public List<QuestionViewModel>? SurveyQuestions { get; set; }
        public List<ChoiceViewModel>? SurveyChoices { get; set; }
        public List<AnswerViewModel>? SurveyAnswers { get; set;}
    }
}
