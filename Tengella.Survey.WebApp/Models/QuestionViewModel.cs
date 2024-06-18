namespace Tengella.Survey.WebApp.Models
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public int QuestionPosition { get; set; }
        public List<ChoiceViewModel> QuestionChoices { get; set; }

    }
}
