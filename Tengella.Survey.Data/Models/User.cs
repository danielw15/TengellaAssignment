using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengella.Survey.Data.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public string? UserType { get; set; }
        public string? OrgNumber { get; set; }
        public string? OrgName { get; set; }

        [NotMapped]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        // Navigation
        public ICollection<SurveyObject> SurveyObjects { get; set; } = new List<SurveyObject>();
    }
}
