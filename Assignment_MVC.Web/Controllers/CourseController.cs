using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Assignment_MVC.Services;
using Assignment_MVC.Entities;
using PagedList;
using PagedList.Mvc;

namespace Assignment_MVC.Web.Controllers
{
    public class CourseController : Controller
    {
        CourseRepository courseRepository = new CourseRepository();
        // GET: Course
        public ActionResult CourseTable(string sortOrder, string searchTitle, string searchStream, int? page, int? pSize)
        {

            //--------------- FILTERING type ------------------
            ViewBag.CurrentTitleName = searchTitle;
            ViewBag.CurrentStreamName = searchStream;
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.CurrentpSize = pSize;


            //---------------- SORTING Parameters --------------------
            ViewBag.TitleNameSortParam = String.IsNullOrEmpty(sortOrder) ? "TitleNameDesc" : "";
            ViewBag.StreamNameSortParam = sortOrder == "StreamNameAsc" ? "StreamNameDesc" : "StreamNameAsc";
            ViewBag.StartDateSortParam = sortOrder == "StartDateAsc" ? "StartDateDesc" : "StartDateAsc";
            ViewBag.EndDateSortParam = sortOrder == "EndDateAsc" ? "EndDateDesc" : "EndDateAsc";

            
            ViewBag.TCView = "badge badge-primary";
            ViewBag.SCView = "badge badge-primary";
            ViewBag.SDCView = "badge badge-primary";
            ViewBag.EDCView = "badge badge-primary";

            CourseRepository courseRepository = new CourseRepository();
            var courses = courseRepository.GetAll();

            //--------------- FILTERING check------------------
            if (!string.IsNullOrWhiteSpace(searchTitle))
                courses = courses.Where(x => x.Title.ToUpper().Contains(searchTitle.ToUpper()));
            if (!string.IsNullOrWhiteSpace(searchStream))
                courses = courses.Where(x => x.Stream.ToUpper().Contains(searchStream.ToUpper()));

            //---------------- SORTING check --------------------
            switch (sortOrder)
            {
                case "TitleNameDesc": courses = courses.OrderByDescending(x => x.Title); ViewBag.TCView = "badge badge-danger"; break;
                case "StreamNameAsc": courses = courses.OrderBy(x => x.Stream); ViewBag.SCView = "badge badge-success"; break;
                case "StreamNameDesc": courses = courses.OrderByDescending(x => x.Stream); ViewBag.SCView = "badge badge-danger"; break;
                case "StartDateAsc": courses = courses.OrderBy(x => x.StartDate); ViewBag.SDCView = "badge badge-success"; break;
                case "StartDateDesc": courses = courses.OrderByDescending(x => x.StartDate); ViewBag.SDCView = "badge badge-danger"; break;
                case "EndDateAsc": courses = courses.OrderBy(x => x.EndDate); ViewBag.EDCView = "badge badge-success"; break;
                case "EndDateDesc": courses = courses.OrderByDescending(x => x.Stream); ViewBag.EDCView = "badge badge-danger"; break;
                default: courses = courses.OrderBy(x => x.CourseId);ViewBag.TCView = "badge badge-success"; break;
            }

            //----------------- PAGINATION check ------------------

            int pageSize = pSize ?? 5;
            int pageNumber = page ?? 1;         //nullable coehelesing operator

            return View(courses.ToPagedList(pageNumber, pageSize));
        }

        // GET: Course/Details
        public ActionResult SimpleDetails(int? id)
        {
            CourseRepository courseRepository = new CourseRepository();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = courseRepository.GetById(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            AssignmentRepository assignemntRepository = new AssignmentRepository();
            ViewBag.SelectedAssignmentsId = assignemntRepository.GetAll().Select(x => new SelectListItem()
            {
                Value = x.AssignmentId.ToString(),
                Text = x.Title
            });

            TrainerRepository trainerRepository = new TrainerRepository();
            ViewBag.SelectedTrainersId = trainerRepository.GetAll().Select(x => new SelectListItem()
            {
                Value = x.TrainerId.ToString(),
                Text = x.LastName
            });

            StudentRepository studentRepository = new StudentRepository();
            ViewBag.SelectedStudentsId = studentRepository.GetAll().Select(x => new SelectListItem()
            {
                Value = x.StudentId.ToString(),
                Text = x.LastName
            });

            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,Title,Stream,PhotoUrl,CourseType,StartDate,EndDate,Fees")] Course course, IEnumerable<int> SelectedTrainersId, IEnumerable<int> SelectedStudentsId, IEnumerable<int> SelectedAssignmentsId)
        {
            if (ModelState.IsValid)
            {
                courseRepository.Insert(course, SelectedTrainersId, SelectedStudentsId, SelectedAssignmentsId);
                return RedirectToAction("CourseTable");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = courseRepository.GetById(id);
            if (course == null)
            {
                return HttpNotFound();
            }

            TrainerRepository trainerRepository = new TrainerRepository();
            ViewBag.SelectedTrainersId = trainerRepository.GetAll().Select(x => new SelectListItem()
            {
                Value = x.TrainerId.ToString(),
                Text = x.LastName,
                Selected = course.Trainers.Any(y => y.TrainerId == x.TrainerId)
            });

            StudentRepository studentRepository = new StudentRepository();

            ViewBag.SelectedStudentsId = studentRepository.GetAll().Select(x => new SelectListItem()
            {
                Value = x.StudentId.ToString(),
                Text = x.LastName,
                Selected = course.Students.Any(y => y.StudentId == x.StudentId)
            });

            AssignmentRepository assignemntRepository = new AssignmentRepository();
            ViewBag.SelectedAssignmentsId = assignemntRepository.GetAll().Select(x => new SelectListItem()
            {
                Value = x.AssignmentId.ToString(),
                Text = x.Title,
                Selected = course.Assignments.Any(y => y.AssignmentId == x.AssignmentId)
            });

            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,Title,Stream,PhotoUrl,CourseType,StartDate,EndDate,Fees")] Course course, IEnumerable<int> selectedTrainersId, IEnumerable<int> selectedStudentsId, IEnumerable<int> selectedAssignmentsId)
        {
            if (ModelState.IsValid)
            {
                courseRepository.Update(course, selectedTrainersId, selectedStudentsId, selectedAssignmentsId);
                return RedirectToAction("CourseTable");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = courseRepository.GetById(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = courseRepository.GetById(id);
            if (course.Assignments.Count > 0)
            {
                return View("Error");
            }
            else
            {
                courseRepository.Delete(course);
                return RedirectToAction("CourseTable");
            }

        }
    }
}