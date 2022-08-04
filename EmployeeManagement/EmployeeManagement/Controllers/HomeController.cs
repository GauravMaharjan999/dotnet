using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HomeController :Controller

    {
        private IEmployeeRepositary _employeeRepositary;
        public HomeController(IEmployeeRepositary employeeRepositary)
        {
            _employeeRepositary = employeeRepositary;
        }

        public ViewResult Index()
        {
            var model = _employeeRepositary.GetAllEmployees();

            return View(model) ;
        }
        public IActionResult Begin()
        {

            return View();
        }
        public ViewResult Details(int? id)
        {
            Employee model = _employeeRepositary.GetEmployee(id??1);
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {   
                Employee = model,
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepositary.Add(employee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }
    }
}
