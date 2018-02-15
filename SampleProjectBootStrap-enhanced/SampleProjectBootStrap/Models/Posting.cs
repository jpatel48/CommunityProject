using SampleProjectBootStrap.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectPlanning.Models
{
    public class Posting
    {
        public Posting()
        {
            this.Applications = new HashSet<Application>();
        }

        [Display(Name = "Job Posting")]
        public int ID { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "You must specify the title.")]
        [StringLength(255, ErrorMessage = "Title should not be more than 255 letters")]
        public string Title { get; set; }

        [Display(Name = "Closing Date")]
        [Required(ErrorMessage = "You must specify the closing date for the job posting.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ClosingDate { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "You must specify the position for the posting.")]
        public int PositionID { get; set; }

        public int LocationID { get; set; }
        public int DepartmentID { get; set; }

        public virtual Position Position { get; set; }
        public virtual Location Location { get; set; }
        public virtual Department Department { get; set; }

        public ICollection<Application> Applications { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ClosingDate < DateTime.Today)
            {
                yield return new ValidationResult("Closing date cannot be in the Past.", new[] { "ClosingDate" });
            }
            if (StartDate.GetValueOrDefault() < ClosingDate)
            {
                yield return new ValidationResult("Start date for the posting cannot be before the closing date.", new[] { "StartDate" });
            }
        }
    }
}