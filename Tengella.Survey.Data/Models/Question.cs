using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        // Foreign Key
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

        // Navigation
        public SurveyObject SurveyObject { get; set; } = null!;
        public ICollection<Choice> Choices { get; set; } = new List<Choice>();
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
