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
    public class TrainerController : Controller
    {
        TrainerRepository trainerRepository = new TrainerRepository();
        // GET: Trainer
        public ActionResult TrainerTable(string sortOrder, string searchFirstName, string searchLastName, int? searchMinAge, int? searchMaxAge, string searchCountry, double? searchMinSalary, double? searchMaxSalary, int? page, int? pSize)
        {
            //--------------- FILTERING type ------------------
            ViewBag.CurrentFirstName = searchFirstName;
            ViewBag.CurrentLastName = searchLastName;
            ViewBag.CurrentMinAge = searchMinAge;
            ViewBag.CurrentMaxAge = searchMaxAge;
            ViewBag.CurrentCountry = searchCountry;
            ViewBag.CurrentMinSalary = searchMinSalary;
            ViewBag.CurrentMaxSalary = searchMaxSalary;
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.CurrentpSize = pSize;


            //---------------- SORTING Parameters --------------------
            ViewBag.FirstNameSortParam = String.IsNullOrEmpty(sortOrder) ? "FirstNameDesc" : "";
            ViewBag.LastNameSortParam = sortOrder == "LastNameAsc" ? "LastNameDesc" : "LastNameAsc";
            ViewBag.AgeSortParam = sortOrder == "AgeAsc" ? "AgeDesc" : "AgeAsc";
            ViewBag.CountrySortParam = sortOrder == "CountryAsc" ? "CountryDesc" : "CountryAsc";
            ViewBag.SalarySortParam = sortOrder == "SalaryAsc" ? "SalaryDesc" : "SalaryAsc";


            ViewBag.FNView = "badge badge-primary";
            ViewBag.LNView = "badge badge-primary";
            ViewBag.AView = "badge badge-primary";
            ViewBag.CView = "badge badge-primary";
            ViewBag.SView = "badge badge-primary";
            

            var trainer = trainerRepository.GetAll();

            //--------------- FILTERING check ------------------
            if (!string.IsNullOrWhiteSpace(searchFirstName))
                trainer = trainer.Where(x => x.FirstName.ToUpper().Contains(searchFirstName.ToUpper()));
            if (!string.IsNullOrWhiteSpace(searchLastName))
                trainer = trainer.Where(x => x.LastName.ToUpper().Contains(searchLastName.ToUpper()));
            if (!(searchMinAge is null))
                trainer = trainer.Where(x => x.Age <= searchMinAge);
            if (!(searchMaxAge is null))
                trainer = trainer.Where(x => x.Age >= searchMaxAge);
            if (!(searchMinSalary is null))
                trainer = trainer.Where(x => x.Salary <= searchMinSalary);
            if (!(searchMaxSalary is null))
                trainer = trainer.Where(x => x.Salary >= searchMaxSalary);


            //---------------- SORTING check --------------------
            switch (sortOrder)
            {
                case "FirstNameDesc": trainer = trainer.OrderByDescending(x => x.FirstName); ViewBag.FNView = "badge badge-danger"; break;
                case "LastNameAsc": trainer = trainer.OrderBy(x => x.LastName); ViewBag.LNView = "badge badge-success"; break;
                case "LastNameDesc": trainer = trainer.OrderByDescending(x => x.LastName); ViewBag.LNView = "badge badge-danger"; break;
                case "AgeAsc": trainer = trainer.OrderBy(x => x.Age); ViewBag.AView = "badge badge-success"; break;
                case "AgeDesc": trainer = trainer.OrderByDescending(x => x.Age); ViewBag.AView = "badge badge-danger"; break;
                case "CountryAsc": trainer = trainer.OrderBy(x => x.Country); ViewBag.CView = "badge badge-success"; break;
                case "CountryDesc": trainer = trainer.OrderByDescending(x => x.Country); ViewBag.CView = "badge badge-danger"; break;
                case "SalaryAsc": trainer = trainer.OrderBy(x => x.Salary); ViewBag.SView = "badge badge-success"; break;
                case "SalaryDesc": trainer = trainer.OrderByDescending(x => x.Salary); ViewBag.SView = "badge badge-danger"; break;
                default: trainer = trainer.OrderBy(x => x.TrainerId); ViewBag.FNView = "badge badge-success"; break;
            }

            //----------------- PAGINATION check ------------------

            int pageSize = pSize ?? 5;
            int pageNumber = page ?? 1;   //nullable coehelesing operator

            return View(trainer.ToPagedList(pageNumber, pageSize));
        }

        // GET: Trainer/Details
        public ActionResult SimpleDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = trainerRepository.GetById(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: TestTrainers/Create
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

        // POST: TestTrainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainerId,FirstName,LastName,DateOfBirth,Salary,PhotoUrl,Telephone,Email,Country")] Trainer trainer, IEnumerable<int> selectedCoursesId)
        {
            if (ModelState.IsValid)
            {
                trainerRepository.Insert(trainer, selectedCoursesId);
                return RedirectToAction("TrainerTable");
            }

            return View(trainer);
        }

        // GET: TestTrainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = trainerRepository.GetById(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            CourseRepository courseRepository = new CourseRepository();
            ViewBag.selectedCourseId = courseRepository.GetAll().Select(x => new SelectListItem()
            {
                Value = x.CourseId.ToString(),
                Text = x.Title,
                Selected = trainer.Courses.Any(y => y.CourseId == x.CourseId)
            });
            return View(trainer);
        }

        // POST: TestTrainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainerId,FirstName,LastName,DateOfBirth,Salary,PhotoUrl,Telephone,Email,Country")] Trainer trainer, IEnumerable<int> selectedCourseId)
        {
            if (ModelState.IsValid)
            {
                trainerRepository.Update(trainer, selectedCourseId);
                return RedirectToAction("TrainerTable");
            }
            return View(trainer);
        }

        // GET: TestTrainers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = trainerRepository.GetById(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: TestTrainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainer trainer = trainerRepository.GetById(id);
            trainerRepository.Delete(trainer);
            return RedirectToAction("TrainerTable");
        }
    }
}