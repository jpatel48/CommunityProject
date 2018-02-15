using SampleProjectBootStrap.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectPlanning.Models
{
    public class Location
    {
        public Location()
        {
            this.Postings = new HashSet<Posting>();
        }

        public int ID { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "You must specify the city name.")]
        [StringLength(255, ErrorMessage = "City name should not be more than 255 letters")]
        public string Address { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "You must specify the city name.")]
        [StringLength(75, ErrorMessage = "City name should not be more than 75 letters")]
        public string CityName { get; set; }

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "You must specify the city name.")]
        [RegularExpression("[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]", ErrorMessage = "Please enter a valid Postal Code (no spaces).")]
        [DataType(DataType.PostalCode)]
        public int PostalCode { get; set; }

        public virtual ICollection<Posting> Postings { get; set; }
    }
}