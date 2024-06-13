namespace Tengella.Survey.WebApp.Models
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int QuestionPosition { get; set; }
        public List<AnswerViewModel> QuestionAnswers { get; set; }

    }
}
