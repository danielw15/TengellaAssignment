namespace Tengella.Survey.WebApp.Models
{
    public class ChoiceViewModel
    {
        public int ChoiceId { get; set; } = 0;
        public int? ChoicePosition { get; set;} = 0;
        public string? ChoiceText { get; set; } = string.Empty;
    }
}
