namespace Tengella.Survey.WebApp.Models
{
    public class SurveyViewModel
    {
        public int SurveyObjectId { get; set; }
        public string? SurveyTitle { get; set; } = string.Empty;
        public string? SurveyDescription { get; set; } = string.Empty;
        public string? SurveyType { get; set; } = string.Empty;
        public List<QuestionViewModel>? SurveyQuestions { get; set; } = new List<QuestionViewModel>();
        public List<ChoiceViewModel>? SurveyChoices { get; set; } = new List<ChoiceViewModel> { };
        public List<AnswerViewModel>? SurveyAnswers { get; set; }
    }
}
