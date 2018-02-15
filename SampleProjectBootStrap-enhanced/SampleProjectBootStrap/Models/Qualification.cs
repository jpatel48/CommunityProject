using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectPlanning.Models
{
    public class Qualification
    {
        public Qualification()
        {
            this.Position_Qualifications = new HashSet<Position_Qualification>();
        }

        public int ID { get; set; }

        [Display(Name = "Qualification")]
        [Required(ErrorMessage = "You cannot leave the qualification blank.")]
        [StringLength(255, ErrorMessage = "Qualification name cannot be more than 255 characters long.")]
        public string QualificationName { get; set; }

        public ICollection<Position_Qualification> Position_Qualifications { get; set; }
    }
}