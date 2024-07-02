using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Models
{
    public class TemplateQuestion
    {
        [Key]
        public int TemplateQuestionId { get; set; }

        [Required]
        public int SurveyTemplateId { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The question text cannot exceed 500 characters.")]
        public string QuestionText { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The question position must be a positive number.")]
        public int QuestionPosition { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The question type cannot exceed 50 characters.")]
        public string QuestionType { get; set; } = string.Empty;

        // Navigation
        public SurveyTemplate SurveyTemplate { get; set; } = null!;
        public ICollection<TemplateChoice> Choices { get; set; } = new HashSet<TemplateChoice>();
    }
}
