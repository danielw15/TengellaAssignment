using System.ComponentModel.DataAnnotations;

namespace Tengella.Survey.WebApp.Models
{
    public class SurveyViewModel
    {
        [Required]
        public int SurveyObjectId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The survey title cannot exceed 100 characters.")]
        public string SurveyTitle { get; set; } = string.Empty;
        [Required]
        [StringLength(500, ErrorMessage = "The survey description cannot exceed 500 characters.")]
        public string SurveyDescription { get; set; } = string.Empty;
        [Required]
        [StringLength(50, ErrorMessage = "The survey type cannot exceed 50 characters.")]
        public string SurveyType { get; set; } = string.Empty;
        [Required]
        public int UserId { get; set; }
        public string? UserEmail { get; set; }
        [Required]
        public List<QuestionViewModel> SurveyQuestions { get; set; } = new List<QuestionViewModel>();
        
    }
}
