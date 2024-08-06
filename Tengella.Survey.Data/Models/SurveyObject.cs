using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Models
{
    public class SurveyObject
    {
        public SurveyObject() 
        {
            Questions = new HashSet<Question>();
            Submissions = new HashSet<Submission>();
        }
        [Key]
        public int SurveyObjectId { get; set; }

        // Foreign Key
        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The survey title cannot exceed 200 characters.")]
        public string SurveyTitle { get; set; } = string.Empty;

        [Required]
        [StringLength(500, ErrorMessage = "The survey description cannot exceed 500 characters.")]
        public string SurveyDescription { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "The survey type cannot exceed 100 characters.")]
        public string SurveyType { get; set; } = string.Empty;

        // Navigation
        public User? User { get; set; }
        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public ICollection<Submission> Submissions { get; set; } = new List<Submission>();
    }
}
