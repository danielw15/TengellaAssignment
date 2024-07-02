using System.ComponentModel.DataAnnotations;

namespace Tengella.Survey.WebApp.Models
{
    public class QuestionViewModel
    {
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public int SurveyObjectId { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "The question name cannot exceed 200 characters.")]
        public string QuestionName { get; set; } = string.Empty;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The question position must be a positive number.")]
        public int QuestionPosition { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The question type cannot exceed 50 characters.")]
        public string QuestionType { get; set; } = string.Empty;
        public List<ChoiceViewModel>? QuestionChoices { get; set; } = new List<ChoiceViewModel>();

    }
}
