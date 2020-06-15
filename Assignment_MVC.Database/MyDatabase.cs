using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Assignment_MVC.Entities;

namespace Assignment_MVC.Database
{
    public class MyDatabase :DbContext
    {
        public MyDatabase() :base("Connection")
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<TutionFees> Fees { get; set; }
        public DbSet<MarkAssignment> MarkAssignments { get; set; }

    }
}
