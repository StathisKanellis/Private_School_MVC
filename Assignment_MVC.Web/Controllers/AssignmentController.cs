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
    public class AssignmentController : Controller
    {
        // GET: Assignment
        public ActionResult AssignmentTable(string sortOrder, string searchTitle, string searchDescription, int? page, int? pSize)
        {

            //--------------- FILTERING type ------------------
            ViewBag.CurrentTitleName = searchTitle;
            ViewBag.CurrentDescriptionName = searchDescription;
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.CurrentpSize = pSize;

            //---------------- SORTING Parameters --------------------
            ViewBag.TitleNameSortParam = String.IsNullOrEmpty(sortOrder) ? "TitleNameDesc" : "";
            ViewBag.DescriptionNameSortParam = sortOrder == "DescriptionAsc" ? "DescriptionDesc" : "DescriptionAsc";
            ViewBag.SubTimeSortParam = sortOrder == "SubTimeAsc" ? "SubTimeDesc" : "SubTimeAsc";


            ViewBag.TNView = "badge badge-primary";
            ViewBag.DNView = "badge badge-primary";
            ViewBag.STView = "badge badge-primary";
            

            AssignmentRepository assignmentRepository = new AssignmentRepository();
            var assignment = assignmentRepository.GetAll();

            //--------------- FILTERING check ------------------
            if (!string.IsNullOrWhiteSpace(searchTitle))
                assignment = assignment.Where(x => x.Title.ToUpper().Contains(searchTitle.ToUpper()));
            if (!string.IsNullOrWhiteSpace(searchDescription))
                assignment = assignment.Where(x => x.Description.ToUpper().Contains(searchDescription.ToUpper()));


            //---------------- SORTING check --------------------
            switch (sortOrder)
            {
                case "TitleNameDesc": assignment = assignment.OrderByDescending(x => x.Title); ViewBag.TNView = "badge badge-danger"; break;
                case "DescriptionAsc": assignment = assignment.OrderBy(x => x.Description); ViewBag.DNView = "badge badge-success"; break;
                case "DescriptionDesc": assignment = assignment.OrderByDescending(x => x.Description); ViewBag.DNView = "badge badge-danger"; break;
                case "SubTimeAsc": assignment = assignment.OrderBy(x => x.SubTime); ViewBag.STView = "badge badge-success"; break;
                case "SubTimeDesc": assignment = assignment.OrderByDescending(x => x.SubTime); ViewBag.STView = "badge badge-danger"; break;
                default: assignment = assignment.OrderBy(x => x.AssignmentId); ViewBag.TNView = "badge badge-success"; break;
            }

            //----------------- PAGINATION check ------------------

            int pageSize = pSize ?? 5;
            int pageNumber = page ?? 1;

            return View(assignment.ToPagedList(pageNumber, pageSize));
        }

        // GET: Assignment/Details
        public ActionResult SimpleDetails(int? id)
        {
            AssignmentRepository assignmentRepository = new AssignmentRepository();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = assignmentRepository.GetById(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }
    }
}