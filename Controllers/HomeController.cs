using Clavaxtask.Data;
using Clavaxtask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Clavaxtask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext context;

        public HomeController(ILogger<HomeController> logger,ApplicationContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var data = context.Employees.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid == true)
            {
                context.Employees.Add(employee);
                int a = await context.SaveChangesAsync();
                if (a > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(employee);
                }
            }
            else
            {
                return View(employee);
            }
            
        }


        public IActionResult Edit(string id)
        {
            var EmployeeData = context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            if (EmployeeData != null)
            {
                return View(EmployeeData);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
           
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid == true)
            {
                context.Employees.Update(employee);
                int res = context.SaveChanges();
                if (res > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            else
                return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(string id)
        {
            var employee = context.Employees.Where(x=>x.EmployeeId==id).FirstOrDefault();

            if (ModelState.IsValid == true)
            {
                context.Employees.Remove(employee);
                int res = context.SaveChanges();
                if (res > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            else
            return RedirectToAction(nameof(Index));
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