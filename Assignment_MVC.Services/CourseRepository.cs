using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Assignment_MVC.Database;
using Assignment_MVC.Entities;

namespace Assignment_MVC.Services
{
    public class CourseRepository
    {
        MyDatabase db = new MyDatabase();


        //GetAll()
        public IEnumerable<Course> GetAll()
        {
            return db.Courses.ToList();
        }


        //GetById
        public Course GetById(int? id)
        {
            return db.Courses.Find(id);
        }


        //Insert
        public void Insert(Course course, IEnumerable<int> selectedTrainerId, IEnumerable<int> selectedStudentId, IEnumerable<int> selectedAssignmentId)
        {
            db.Courses.Attach(course);
            db.Entry(course).Collection("Trainers").Load();
            db.Entry(course).Collection("Students").Load();
            db.Entry(course).Collection("Assignments").Load();
            db.Entry(course).State = EntityState.Added;
            if(!(selectedTrainerId is null))
            {
                foreach (var id in selectedTrainerId)
                {
                    Trainer trainer = db.Trainers.Find(id);
                    if(trainer != null)
                    {
                        course.Trainers.Add(trainer);
                    }
                }
                db.SaveChanges();
            }
            if (!(selectedStudentId is null))
            {
                foreach (var id in selectedStudentId)
                {
                    Student student = db.Students.Find(id);
                    if (student != null)
                    {
                        course.Students.Add(student);
                    }
                }
                db.SaveChanges();
            }
            if (!(selectedAssignmentId is null))
            {
                foreach (var id in selectedAssignmentId)
                {
                    Assignment assignment = db.Assignments.Find(id);
                    if (assignment != null)
                    {
                        course.Assignments.Add(assignment);
                    }
                }
                db.SaveChanges();
            }
            db.SaveChanges();
        }


        //Update
        public void Update(Course course, IEnumerable<int> selectedTrainerId, IEnumerable<int> selectedStudentId, IEnumerable<int> selectedAssignmentId)
        {
            db.Courses.Attach(course);
            db.Entry(course).Collection("Trainers").Load();
            db.Entry(course).Collection("Students").Load();
            db.Entry(course).Collection("Assignments").Load();
            course.Trainers.Clear();
            course.Students.Clear();
            course.Assignments.Clear();
            if(!(selectedTrainerId is null))
            {
                foreach (var id in selectedTrainerId)
                {
                    Trainer trainer = db.Trainers.Find(id);
                    if(trainer!= null)
                    {
                        course.Trainers.Add(trainer);
                    }
                }
                db.SaveChanges();
            }
            if (!(selectedStudentId is null))
            {
                foreach (var id in selectedStudentId)
                {
                    Student student = db.Students.Find(id);
                    if (student != null)
                    {
                        course.Students.Add(student);
                    }
                }
                db.SaveChanges();
            }
            if (!(selectedAssignmentId is null))
            {
                foreach (var id in selectedAssignmentId)
                {
                    Assignment assignment  = db.Assignments.Find(id);
                    if (assignment != null)
                    {
                        course.Assignments.Add(assignment);
                    }
                }
                db.SaveChanges();
            }
            db.Entry(course).State = EntityState.Modified;
            db.SaveChanges();
        }


        //Delete
        public void Delete(Course course)
        {
            db.Entry(course).State = EntityState.Deleted;
            db.SaveChanges();
        }


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
