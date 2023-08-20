using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mvc.Models;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        WebAPITutsContext context = new WebAPITutsContext(); 
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var data = context.Employees.ToList();
            return View(data);
        }
        
        // create
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Employee e)
        {
            if (ModelState.IsValid == true)
            {
                context.Employees.Add(e);
                int res = context.SaveChanges();
                if (res > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Inserted!')</script>";
                    return RedirectToAction("Index");
                }

                else
                {
                    TempData["InsertMessage"] = "<script>alert('Not Inserted!')</script>";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        // end create

        // edit
        public IActionResult Edit(int id)
        {
            var row = context.Employees.Where(m => m.Id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public IActionResult Edit(Employee e)
        {
            if(ModelState.IsValid == true)
            {
                context.Entry(e).State = EntityState.Modified;
                int res = context.SaveChanges();
                if (res > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('updated!')</script>";
                    return RedirectToAction("Index");
                }

                else
                {
                    TempData["InsertMessage"] = "<script>alert('Not updated!')</script>";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        // end edit

        public IActionResult Delete(int id)
        {
            var row = context.Employees.Where(m => m.Id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public IActionResult Delete(Employee e)
        {
            context.Entry(e).State = EntityState.Deleted;

            int res = context.SaveChanges();
            if (res > 0)
            {
                TempData["DeleteMessage"] = "<script>alert('deleted!')</script>";
                return RedirectToAction("Index");
            }

            else
            {
                TempData["DeleteMessage"] = "<script>alert('Not deleted!')</script>";
                return RedirectToAction("Index");
            }

            return View();
        }// end Delete


        public IActionResult Details(int id)
        {
            var row = context.Employees.Where(m => m.Id == id).FirstOrDefault();
            return View(row);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
