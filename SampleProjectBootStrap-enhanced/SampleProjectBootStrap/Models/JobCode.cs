using ProjectPlanning.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleProjectBootStrap.Models
{
    public class JobCode
    {
        public int ID { get; set; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "You must specify the code.")]
        [StringLength(8, ErrorMessage = "Code should not be more than 8 letters")]
        public string Code { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Position name is required.")]
        [StringLength(100, ErrorMessage = "Position name cannot be more than 100 characters long.")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Occupation description is required.")]
        [StringLength(700, ErrorMessage = "Occupation description cannot be more than 700 characters long.")]
        public string Description { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}