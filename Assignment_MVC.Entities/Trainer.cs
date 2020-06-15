using Assignment_MVC.Entities.Custom_Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_MVC.Entities
{
    public class Trainer
    {
        public int TrainerId { get; set; }
        [Required, MaxLength(60), MinLength(2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, MaxLength(60), MinLength(2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth"), DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [CustomValidation(typeof(MyValidationMethods), "ValidateGreateOrEqualToZero")]
        [Display(Name = "Annual Salary")]
        public double Salary { get; set; }
        [Display(Name = "Photo URL")]
        public string PhotoUrl { get; set; }
        [Display(Name = "Phone Number")]
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
        //Relationships with
        //Course        many
        public virtual ICollection<Course> Courses { get; set; }
    }
}
