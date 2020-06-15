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
    public class StudentRepository
    {
        MyDatabase db = new MyDatabase();


        //GetAll()
        public IEnumerable<Student> GetAll()
        {
            return db.Students.ToList();
        }


        //GetById
        public Student GetById(int? id)
        {
            return db.Students.Find(id);
        }


        //Insert
        public void Insert(Student student, IEnumerable<int> selectedCoursesId)
        {
            db.Students.Attach(student);
            db.Entry(student).Reference("Course").Load();
            db.Entry(student).State = EntityState.Added;
            if (!(selectedCoursesId is null))
            {
                foreach (var id in selectedCoursesId)
                {
                    Course course = db.Courses.Find(id);
                    if (course != null)
                    {
                        student.Course = course;
                    }
                }
                db.SaveChanges();
            }
            db.SaveChanges();
        }


        //Update
        public void Update(Student student, IEnumerable<int> selectedCoursesId)
        {
            db.Students.Attach(student);
            db.Entry(student).Reference("Course").Load();
            //student.Course.Clear();
            db.SaveChanges();
            if (!(selectedCoursesId is null))
            {
                foreach (var id in selectedCoursesId)
                {
                    Course course = db.Courses.Find(id);
                    if (course != null)
                    {
                        student.Course = course;
                    }
                }
                db.SaveChanges();
            }
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
        }


        //Delete
        public void Delete(Student student)
        {
            db.Entry(student).State = EntityState.Deleted;
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
