using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }

        // Foreign Key
        [Required]
        public int QuestionId { get; set; }

        // Foreign Key
        [Required]
        public int SubmissionId { get; set; }

        [Required]
        [StringLength(500)]
        public string AnswerValue { get; set; } = string.Empty;

        // Navigation Properties
        public Question Question { get; set; } = null!;
        public Submission Submission { get; set; } = null!;
    }
}
