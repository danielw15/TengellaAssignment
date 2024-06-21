namespace Tengella.Survey.WebApp.Models
{
    public class AnswerViewModel
    {
        public int AnswerId { get; set; } = 0;
        public int QuestionId { get; set; } = 0;
        public int SubmissionId { get; set; } = 0;
        public string? AnswerValue { get; set; } = string.Empty;

    }
}
