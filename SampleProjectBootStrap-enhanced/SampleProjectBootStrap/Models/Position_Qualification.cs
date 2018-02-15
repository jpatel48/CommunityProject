using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectPlanning.Models
{
    public class Position_Qualification
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You must specify the position.")]
        [Index("IX_Unique_Position_Qualification", Order = 1, IsUnique = true)]
        public int PositionID { get; set; }

        public virtual Position Position { get; set; }

        [Required(ErrorMessage = "You must specify the qualification.")]
        [Index("IX_Unique_Position_Qualification", Order = 2)]
        public int QualificationID { get; set; }

        public virtual Qualification Qualification { get; set; }
    }
}