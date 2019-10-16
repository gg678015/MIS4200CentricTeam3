using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200team3.Models
{
    public class Profile
    {
        [Key]
        [Display(Name = "ProfileID")]
        public int profileID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name Required")]
        [StringLength(15)]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name Required")]
        [StringLength(15)]
        public string lastName { get; set; }

        [Display(Name = "Business Unit")]
        [Required(ErrorMessage = "Business Unit Required")]
        [StringLength(10)]
        public string businessUnit { get; set; }

        [Display(Name = "Hire Date")]
        [Required(ErrorMessage = "Hire Date Required; ")]
        [StringLength(15)]
        public string hireDate { get; set; }

        [Display(Name = "Employee Title")]
        [Required(ErrorMessage = "Employee Title Required")]
        [StringLength(10)]
        public string employeeTitle { get; set; }

        [Display(Name = "Mobile phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\(\d{3}\) |\d{3}-)\d{3}-\d{4}$", ErrorMessage = "Phone numbers must be in the format (xxx) xxx-xxxx or xxx-xxx-xxxx")]
        public string phone { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required")]
        [StringLength(50)]

        public string email { get; set; }
    }
}