using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_MVC.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required, MaxLength(60), MinLength(2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, MaxLength(60), MinLength(2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Photo URL")]
        public string PhotoUrl { get; set; }
        [Required]
        [Display(Name = "Date Of Birth"), DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Telephone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public Country Country { get; set; }
        [NotMapped]
        public int Age
        {
            get { return DateTime.Now.Year - this.DateOfBirth.Year; }
        }

        //NavigationProperty
        //Relationships     with
        //Course            one or zero
        //MarkAssignment    many
        public virtual int? CourseId { get; set; } 
        public virtual Course Course { get; set; }
        public virtual ICollection<MarkAssignment> MarkAssignments { get; set; }
    }
}
