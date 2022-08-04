using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication4.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {

        IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> empList = _employee.getAllEmployees();
            return View(empList);
        }

        public IActionResult Details(int id)
        {
            Employee obj = _employee.getEmployeeById(id);
            return View(obj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Employee obj)
        {
            _employee.createEmployee(obj);
            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            Employee obj = _employee.getEmployeeById(id);
            return View(obj);
        }

        [HttpPost]

        public IActionResult Edit(Employee obj)
        {
            _employee.updateEmployee(obj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee obj = _employee.getEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteEmp(int id)
        {
            _employee.deleteEmployee(id);
            return RedirectToAction("Index");
        }

    }
}