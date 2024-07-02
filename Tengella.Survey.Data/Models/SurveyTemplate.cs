using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Models
{
    public class SurveyTemplate
    {
        [Key]
        public int SurveyTemplateId { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The template name cannot exceed 200 characters.")]
        public string TemplateName { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "The description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;

        // Navigation
        public ICollection<TemplateQuestion> Questions { get; set; } = new HashSet<TemplateQuestion>();
    }
}
