using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Assignment_MVC.Entities;
using Assignment_MVC.Services;
using PagedList;
using PagedList.Mvc;

namespace Assignment_MVC.Web.Controllers
{
    public class StudentController : Controller
    {
        StudentRepository studentRepository = new StudentRepository();

        // GET: Student
        public ActionResult StudentTable(string sortOrder, string searchFirstName, string searchLastName, int? searchMinAge, int? searchMaxAge, string searchCountry, int? page, int? pSize)
        {

            //--------------- FILTERING type ------------------
            ViewBag.CurrentFirstName = searchFirstName;
            ViewBag.CurrentLastName = searchLastName;
            ViewBag.CurrentMinAge = searchMinAge;
            ViewBag.CurrentMaxAge = searchMaxAge;
            ViewBag.CurrentCountry = searchCountry;
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.CurrentpSize = pSize;


            //---------------- SORTING Parameters --------------------
            ViewBag.FirstNameSortParam = String.IsNullOrEmpty(sortOrder) ? "FirstNameDesc" : "";
            ViewBag.LastNameSortParam = sortOrder == "LastNameAsc" ? "LastNameDesc" : "LastNameAsc";
            ViewBag.AgeSortParam = sortOrder == "AgeAsc" ? "AgeDesc" : "AgeAsc";
            ViewBag.CountrySortParam = sortOrder == "CountryAsc" ? "CountryDesc" : "CountryAsc";


            ViewBag.FNView = "badge badge-primary";
            ViewBag.LNView = "badge badge-primary";
            ViewBag.AView = "badge badge-primary";
            ViewBag.CView = "badge badge-primary";

            StudentRepository studentRepository = new StudentRepository();
            var student = studentRepository.GetAll();

            //--------------- FILTERING check ------------------
            if (!string.IsNullOrWhiteSpace(searchFirstName))
                student = student.Where(x => x.FirstName.ToUpper().Contains(searchFirstName.ToUpper()));
            if (!string.IsNullOrWhiteSpace(searchLastName))
                student = student.Where(x => x.LastName.ToUpper().Contains(searchLastName.ToUpper()));
            if (!(searchMinAge is null))
                student = student.Where(x => x.Age <= searchMinAge);
            if (!(searchMaxAge is null))
                student = student.Where(x => x.Age >= searchMaxAge);


            //---------------- SORTING check --------------------
            switch (sortOrder)
            {
                case "FirstNameDesc": student = student.OrderByDescending(x => x.FirstName); ViewBag.FNView = "badge badge-danger"; break;
                case "LastNameAsc": student = student.OrderBy(x => x.LastName); ViewBag.LNView = "badge badge-success"; break;
                case "LastNameDesc": student = student.OrderByDescending(x => x.LastName); ViewBag.LNView = "badge badge-danger"; break;
                case "AgeAsc": student = student.OrderBy(x => x.Age); ViewBag.AView = "badge badge-success"; break;
                case "AgeDesc": student = student.OrderByDescending(x => x.Age); ViewBag.AView = "badge badge-danger"; break;
                case "CountryAsc": student = student.OrderBy(x => x.Country); ViewBag.CView = "badge badge-success"; break;
                case "CountryDesc": student = student.OrderByDescending(x => x.Country); ViewBag.CView = "badge badge-danger"; break;
                default: student = student.OrderBy(x => x.StudentId); ViewBag.FNView = "badge badge-success"; break;
            }

            //----------------- PAGINATION check ------------------

            int pageSize = pSize ?? 5;
            int pageNumber = page ?? 1;   //nullable coehelesing operator

            return View(student.ToPagedList(pageNumber, pageSize));
        }

        // GET: Student/Details
        public ActionResult SimpleDetails(int? id)
        {
            StudentRepository studentRepository = new StudentRepository();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = studentRepository.GetById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            CourseRepository courseRepository = new CourseRepository();
            ViewBag.selectedCoursesId = courseRepository.GetAll().Select(x => new SelectListItem()
            {
                Value = x.CourseId.ToString(),
                Text = x.Title
            });

            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,FirstName,LastName,DateOfBirth")] Student student, IEnumerable<int> selectedCoursesId)
        {
            if (ModelState.IsValid)
            {
                studentRepository.Insert(student, selectedCoursesId);
                return RedirectToAction("StudentTable");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = studentRepository.GetById(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            CourseRepository courseRepository = new CourseRepository();
            ViewBag.selectedCoursesId = courseRepository.GetAll().Select(x => new SelectListItem()
            {
                Value = x.CourseId.ToString(),
                Text = x.Title,
                //Selected = student.Courses.Any(y => y.CourseID == x.CourseID)
            });


            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,FirstName,LastName,DateOfBirth")] Student student, IEnumerable<int> selectedCoursesId)
        {
            if (ModelState.IsValid)
            {
                studentRepository.Update(student, selectedCoursesId);
                return RedirectToAction("StudentTable");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = studentRepository.GetById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = studentRepository.GetById(id);
            studentRepository.Delete(student);
            return RedirectToAction("StudentTable");
        }
    }
}