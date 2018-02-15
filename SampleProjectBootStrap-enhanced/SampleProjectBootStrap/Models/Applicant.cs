using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectPlanning.Models
{
    public class Applicant
    {
        public Applicant()
        {
            this.Applications = new HashSet<Application>();
        }

        public int ID { get; set; }

        [Display(Name ="Applicant")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
       

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(255, ErrorMessage = "First name cannot be more than 255 characters long.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You cannot leave the last name blank.")]
        [StringLength(255, ErrorMessage = "Last name cannot be more than 255 characters long.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number (no spaces).")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = false)]
        public Int64 Phone { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [StringLength(70)]
        [DataType(DataType.EmailAddress)]
        [Index("IX_Unique_Applicant_email", IsUnique = true)]
        public string Email { get; set; }

        public ICollection<Application> Applications { get; set; }
        public object RowVersion { get; internal set; }
    }
}