using ProjectPlanning.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleProjectBootStrap.Models
{
    public class Department
    {
        public int ID { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "You must specify the department.")]
        [StringLength(255, ErrorMessage = "Department should not be more than 255 letters")]
        public string DepartmentName { get; set; }

        public virtual ICollection<Posting> Postings { get; set; }
    }
}