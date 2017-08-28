using MVCSearchWithAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSearchWithAjax.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            Step2017Entities1 ent = new Step2017Entities1();
            List<EmployeeSearch> empSearch = ent.EmployeeSearches.ToList();
            return View(empSearch);
        }

        public ActionResult SearchEmployee()
        {
            return View();
        }

        public ActionResult DetailsEmployee(string name)
        {
            Step2017Entities1 ent = new Step2017Entities1();
            var result = ent.EmployeeSearches.Where(c => c.Name == name).ToList();
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeSearch empSearch)
        {
            Step2017Entities1 ent = new Step2017Entities1();
            ent.EmployeeSearches.Add(empSearch);
            ent.SaveChanges();
            return RedirectToAction("List");
        }
        
        public ActionResult Edit(int id)
        {
            Step2017Entities1 ent = new Step2017Entities1();
            EmployeeSearch empSearch = ent.EmployeeSearches.Where(c => c.Id == id).FirstOrDefault();
            return View(empSearch);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeSearch empSearch)
        {
            Step2017Entities1 ent = new Step2017Entities1();
            EmployeeSearch es = ent.EmployeeSearches.Where(c => c.Id == empSearch.Id).FirstOrDefault();
            es.Name = empSearch.Name;
            es.Address = empSearch.Address;
            es.Salary = empSearch.Salary;
            ent.SaveChanges();
            return RedirectToAction("List");

        }

        public ActionResult Delete(int id)
        {
            Step2017Entities1 ent = new Step2017Entities1();
            var resultDelete = ent.EmployeeSearches.Where(c => c.Id == id).FirstOrDefault();
            ent.EmployeeSearches.Remove(resultDelete);
            ent.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            Step2017Entities1 ent = new Step2017Entities1();
            EmployeeSearch empSearch = ent.EmployeeSearches.Where(c => c.Id == id).FirstOrDefault();
            return View(empSearch);
        }


    }
}