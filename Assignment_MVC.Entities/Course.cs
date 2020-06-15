using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment_MVC.Entities
{
    public class Course : IValidatableObject, IComparable
    {
        public int CourseId { get; set; }
        [Required, MaxLength(60),MinLength(2)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required, MaxLength(60), MinLength(2)]
        [Display(Name = "Stream")]
        public string Stream { get; set; }
        [Required]
        [Display(Name = "Start Date"), DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date"), DataType(DataType.Date)]
        public DateTime EndDate { get; set; }


        //NavigationProperty
        //Relationships with
        //Trainer       many 
        //Student       many 
        //Assignmemt    many 
        //TutionFees    one or zero

        public virtual ICollection<Trainer> Trainers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual TutionFees TutionFees { get; set; }

        //Validation for End Date and Start Date
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return new ValidationResult("End date can't be earlier than Start date.");
            }
        }

        //Implement method IComparable to sort object
        public int CompareTo(object obj)
        {
            Course other = (Course)obj;
            if (this.CourseId > other.CourseId) { return 1; }
            else if (this.CourseId < other.CourseId) { return -1; }
            else return 0;
        }
    }
}
