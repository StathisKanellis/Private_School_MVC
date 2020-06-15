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
    public class TrainerRepository
    {
        MyDatabase db = new MyDatabase();


        //GetAll()
        public IEnumerable<Trainer> GetAll()
        {
            return db.Trainers.ToList();
        }


        //GetById
        public Trainer GetById(int? id)
        {
            return db.Trainers.Find(id);
        }


        //Insert
        public void Insert(Trainer trainer, IEnumerable<int> selectedCoursesId)
        {
            db.Trainers.Attach(trainer);
            db.Entry(trainer).Collection("Courses").Load();
            db.Entry(trainer).State = EntityState.Added;
            if(!(selectedCoursesId is null))
            {
                foreach (var id in selectedCoursesId)
                {
                    Course course = db.Courses.Find(id);
                    if (course != null)
                    {
                        trainer.Courses.Add(course);
                    }
                }
                db.SaveChanges();
            }
            db.SaveChanges();
        }


        //Update
        public void Update(Trainer trainer, IEnumerable<int> selectedCoursesId)
        {
            db.Trainers.Attach(trainer);
            db.Entry(trainer).Collection("Courses").Load();
            trainer.Courses.Clear();
            db.SaveChanges();
            if(!(selectedCoursesId is null))
            {
                foreach (var id in selectedCoursesId)
                {
                    Course course = db.Courses.Find(id);
                    if(course != null)
                    {
                        trainer.Courses.Add(course);
                    }
                }
                db.SaveChanges();
            }
            db.Entry(trainer).State = EntityState.Modified;
            db.SaveChanges();
        }


        //Delete
        public void Delete(Trainer trainer)
        {
            db.Entry(trainer).State = EntityState.Deleted;
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
