using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_MVC.Entities;
using Assignment_MVC.Services;
using Assignment_MVC.Web.Models;

namespace Assignment_MVC.Web.Controllers
{
    public class StatsController : Controller
    {
        // GET: Stats
        public ActionResult Index()
        {
            StatsViewModel statsView = new StatsViewModel();

            StudentRepository studentRepository = new StudentRepository();
            var students = studentRepository.GetAll();
            TrainerRepository trainerRepository = new TrainerRepository();
            var trainers = trainerRepository.GetAll();
            CourseRepository courseRepository = new CourseRepository();
            var courses = courseRepository.GetAll();
            AssignmentRepository assignmentRepository = new AssignmentRepository();
            var assignments = assignmentRepository.GetAll();


            statsView.StudentsCount = students.Count();
            statsView.TrainersCount = trainers.Count();
            statsView.CoursesCount = courses.Count();
            statsView.AssignmentsCount = assignments.Count();

            //Grouping Students Per Course
            statsView.StudentsPerCourse = from student in students
                                          group student by student.Course into x
                                          orderby x.Key
                                          select x;

            //Grouping Trainers Per Course
            statsView.TrainersPerCourse = trainers
                                        .SelectMany(x => x.Courses.Select(y => new
                                        {
                                            Key = y,
                                            Value = x
                                        })).GroupBy(y => y.Key, x => x.Value);

            //Grouping Assignments Per Course
            statsView.AssignmentPerCourse = assignments
                                        .SelectMany(x => x.Courses.Select(y => new
                                        {
                                            Key = y,
                                            Value = x
                                        })).GroupBy(y => y.Key, x => x.Value);

            //Grouping Assignments Per Student
            statsView.AssignmentPerStudent = assignments
                                        .SelectMany(x => x.MarkAssignments.Select(y => new
                                        {
                                            Key = x,
                                            Value = y
                                        })).GroupBy(x => x.Key, y => y.Value);


            statsView.Students = students;
            statsView.Courses = courses;
            statsView.Assignments = assignments;

            return View(statsView);
 
        }


        public ActionResult ShowAll()
        {
            StudentCourseTrainerAssignment sctm = new StudentCourseTrainerAssignment();
            return View(sctm);
        }
    }
}