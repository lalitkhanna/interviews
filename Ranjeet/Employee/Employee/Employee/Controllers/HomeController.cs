using Employee.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private UsersContext db = new UsersContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddEmployee()
        {
            ViewBag.Message = "Add Employee.";
            EmployeeModel objEmployeeModel = new EmployeeModel();
            FillDropdowns();     
            return View(objEmployeeModel);
        }

        private void FillDropdowns()
        {
            ViewBag.StateID = db.State.OrderBy(q => q.StateName);

            List<City> objcity = new List<City>();
            ViewBag.CityID = new SelectList(objcity, "Id", "CityName", 0);
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeModel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Employee.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
 
            }
            FillDropdowns();
            return View(employee);
        }

        public ActionResult AllEmployees()
        {
            ViewBag.Message = "All Employees.";
            return View(db.Employee);
        }

        [HttpPost]
        public ActionResult GetCityByStaeId(int stateid)
        {
            List<City> objcity = new List<City>();
            objcity = db.City.Where(m => m.StateId == stateid).ToList();
            SelectList obgcity = new SelectList(objcity, "Id", "CityName", 0);
            return Json(obgcity);
        }
    }
}
