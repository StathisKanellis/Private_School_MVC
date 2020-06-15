using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment_MVC.Entities;
using Assignment_MVC.Services;

namespace Assignment_MVC.Web.Models
{
    public class StudentCourseTrainerAssignment
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Trainer> Trainers { get; set; }
        public IEnumerable<Assignment> Assignments { get; set; }

        public StudentCourseTrainerAssignment()
        {
            StudentRepository studentRepository = new StudentRepository();
            CourseRepository courseRepository = new CourseRepository();
            TrainerRepository trainerRepository = new TrainerRepository();
            AssignmentRepository assignmentRepository = new AssignmentRepository();

            Students = studentRepository.GetAll();
            Courses = courseRepository.GetAll();
            Trainers = trainerRepository.GetAll();
            Assignments = assignmentRepository.GetAll();
        }
    }
}