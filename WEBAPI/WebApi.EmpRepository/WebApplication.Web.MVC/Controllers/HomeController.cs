using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApplication.Web.MVC.Models;

namespace WebApplication.Web.MVC.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string  api_url= "api/employeesApi";


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Employee> employees = new List<Employee>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            HttpResponseMessage response = await client.GetAsync(api_url);
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<Employee>>(res);
            }

            return View(employees);
        }

        public async Task<IActionResult> Details(int id)
        {
            Employee e = await GetEmployeeByID(id);
            return View(e);


        }
        public async Task<Employee> GetEmployeeByID(int id)
        {
            Employee e = new Employee();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            HttpResponseMessage response = await client.GetAsync(api_url + $"/{id}");
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                e = JsonConvert.DeserializeObject<Employee>(res);
            }

            return e;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            HttpResponseMessage response = await client.PostAsJsonAsync(api_url, e);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Employee e = await GetEmployeeByID(id);
            return View(e);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            HttpResponseMessage response = await client.PutAsJsonAsync(api_url + $"/{e.Id}", e);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            HttpResponseMessage response = await client.DeleteAsync(api_url + $"/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
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
