using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment_MVC.Entities
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        [Required, MaxLength(60), MinLength(2)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required, MaxLength(60), MinLength(2)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "SubTime"), DataType(DataType.Date)]
        public DateTime SubTime { get; set; }
        

        //NavigationProperty
        //Relationships   with
        //MarkAssignment  many
        //Course          many

        public virtual ICollection<MarkAssignment> MarkAssignments { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
