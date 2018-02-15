using ProjectPlanning.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleProjectBootStrap.Models
{
    public class Compensation
    {
        public int ID { get; set; }

        [Display(Name = "Compensation")]
        [Required(ErrorMessage = "You must specify the compensation type.")]
        [StringLength(255, ErrorMessage = "Compensation type should not be more than 255 letters")]
        public string CompensationType { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}