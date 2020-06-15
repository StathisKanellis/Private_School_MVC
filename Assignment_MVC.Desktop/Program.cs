using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_MVC.Database;
using Assignment_MVC.Services;

namespace Assignment_MVC.Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDatabase db = new MyDatabase();

            Console.WriteLine("===============================================================================");
            Console.WriteLine("     =====Table Course data from Table Student, Assignment, TuitionFees====     ");
            Console.WriteLine("===============================================================================");
            foreach (var course in db.Courses.ToList())
            {
                Console.WriteLine(course.Title + "|{0:C0}", course.TutionFees.Cost);

                foreach (var student in course.Students)
                {
                    Console.WriteLine(student.LastName);
                    foreach (var mark in student.MarkAssignments)
                    {
                        Console.WriteLine("\t{0} | {1}", mark.Assignment.Title, mark.TotalMark);
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("===============================================================================");
            Console.WriteLine("   ==Table Trainer data from Table Course, TuitionFees, Student, Assignment==  ");
            Console.WriteLine("===============================================================================");
            foreach (var trainer in db.Trainers.ToList())
            {
                Console.WriteLine(trainer.LastName);
                foreach (var cource in trainer.Courses)
                {
                    Console.WriteLine("\t{0} | {1:C}", cource.Title, cource.TutionFees.Cost);
                    foreach (var assign in cource.Assignments)
                    {
                        Console.WriteLine("\t\t{0}", assign.Title);
                        foreach (var stud in assign.MarkAssignments)
                        {
                            Console.WriteLine("\t\t\t{0} | {1}", stud.Student.LastName, stud.TotalMark);
                        }
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("===============================================================================");
            Console.WriteLine("       =====Table Assignment data from Table Student,TuitionFees====  ");
            Console.WriteLine("===============================================================================");
            foreach (var assign in db.Assignments.ToList())
            {
                Console.WriteLine(assign.Title);
                foreach (var mark in assign.MarkAssignments)
                {
                    Console.WriteLine("\t{0} | {1}", mark.Student.LastName, mark.TotalMark);
                }
            }

            Console.WriteLine();
            Console.WriteLine("===============================================================================");
            Console.WriteLine("       =====Get All From CourseRepository====  ");
            Console.WriteLine("===============================================================================");

            CourseRepository courseRepository = new CourseRepository();
            //courseRepository.Dispose();
            var lista = courseRepository.GetAll();
            foreach (var item in lista)
            {
                Console.WriteLine($" {item.Title} | {item.Stream} | {item.StartDate} | {item.EndDate} |");
            }

            Console.WriteLine();
            Console.WriteLine("===============================================================================");
            Console.WriteLine("       =====Students Per Course Per Assignment Mark====  ");
            Console.WriteLine("===============================================================================");
         
            foreach (var item in db.Courses.ToList())
            {
                Console.WriteLine(item.Title);
                foreach (var stud in item.Students)
                {
                    Console.WriteLine("\t {0}",stud.LastName);
                    foreach (var assign in stud.MarkAssignments)
                    {
                        Console.WriteLine("\t\t {0}", assign.Assignment.Title); 
                    }
                    Console.WriteLine("\t\t\t\t{0:n2}",stud.MarkAssignments.Average(x => x.TotalMark));
                }
            }
        }
    }
}
