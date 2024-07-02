using System.ComponentModel.DataAnnotations;

namespace Tengella.Survey.WebApp.Models
{
    public class ChoiceViewModel
    {
        [Required]
        public int ChoiceId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The choice position must be a positive number.")]
        public int ChoicePosition { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The choice text cannot exceed 200 characters.")]
        public string ChoiceText { get; set; } = string.Empty;
    }
}
