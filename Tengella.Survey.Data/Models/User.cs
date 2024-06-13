using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Models
{
    public class User
    {
        [Display(Name = "User ID")]
        public int UserId { get; set; }
        [StringLength(60, MinimumLength = 2)]
        [Display(Name = "First Name")]
        [Required]
        public string? FirstName { get; set; }
        [StringLength(60, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        [Required]
        public string? LastName { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Email { get; set; }
        [StringLength(60, MinimumLength = 8)]
        [Required]
        public string? Password { get; set; }
        [RegularExpression(@"^[0-9]+$")]
        [Required]
        public string? PhoneNumber { get; set; }
        public DateTime CreationDate { get; set; }
        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

    }
}
