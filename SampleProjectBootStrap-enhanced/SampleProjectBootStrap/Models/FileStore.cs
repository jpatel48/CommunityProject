using ProjectPlanning.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleProjectBootStrap.Models
{
    public class FileStore
    {
        public int ID { get; set; }

        [Display(Name = "File Content")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(256, ErrorMessage = "File Content cannot be more than 256 characters long.")]
        public string FileContent { get; set; }

        [Display(Name = "File Meme Type")]
        [Required(ErrorMessage = "You cannot leave the last name blank.")]
        [StringLength(256, ErrorMessage = "File Meme Type be more than 256 characters long.")]
        public string FileMemeType { get; set; }

        [Display(Name = "File Name")]
        [Required(ErrorMessage = "File Name is required.")]
        [StringLength(70)]
        public string FileName { get; set; }

        public ICollection<Application> Applications { get; set; }
    }
}