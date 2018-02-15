using SampleProjectBootStrap.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectPlanning.Models
{
    public class Position
    {
        public Position()
        {
            this.Postings = new HashSet<Posting>();
            this.Position_Qualifications = new HashSet<Position_Qualification>();
        }

        public int ID { get; set; }

        [Display(Name = "Starting Salary")]
        [Required(ErrorMessage = "Starting salary amount is required.")]
        [Range(0.01, 9999999.99, ErrorMessage = "Invalid salary value.")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(Name = "FTE")]
        [Required(ErrorMessage = "You must specify the type.")]
        [StringLength(255, ErrorMessage = "Type should not be more than 255 letters")]
        public string FTEType { get; set; }

        public int CompensationID { get; set; }

        public int JobCodeID { get; set; }

        public virtual Compensation Compensation { get; set; }

        public virtual Location Location { get; set; }

        public virtual JobCode JobCode { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Posting> Postings { get; set; }

        public virtual ICollection<Position_Qualification> Position_Qualifications { get; set; }
    }
}