using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Models
{
    public class TemplateChoice
    {
        [Key]
        public int TemplateChoiceId { get; set; }

        [Required]
        public int TemplateQuestionId { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The choice text cannot exceed 200 characters.")]
        public string ChoiceText { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The choice position must be a positive number.")]
        public int ChoicePosition { get; set; }

        // Navigation
        public TemplateQuestion TemplateQuestion { get; set; } = null!;
    }
}
