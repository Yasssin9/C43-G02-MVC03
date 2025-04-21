using Company.Data.Models;
using Company.Repository.Repositories;
using Company.Service.Interfaces.DepartmentServices;
using Company.Service.Interfaces.DepartmentServices.Dto;
using Company.Service.Interfaces.IEmployeeServices;
using Company.Service.Interfaces.IEmployeeServices.Dto;
using Company.Service.Services;
using Company.Service.Services.EmployeeServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeServices;

        private readonly IDepartmentServices _DepartmentServices;

        public EmployeeController(IEmployeeServices employeeServices,IDepartmentServices departmentServices)
        {
            _employeeServices = employeeServices;
            _DepartmentServices = departmentServices;
        }

        public IActionResult Index(string searchIp)
        {
            IEnumerable<EmployeeDto> employee;

            if (string.IsNullOrEmpty(searchIp))
                employee = _employeeServices.GetAll();
            else
                employee = _employeeServices.GetEmployeeByName(searchIp);

            return View(employee);
        }


        [HttpGet]
        public IActionResult Create()
        {
            //var departments = _DepartmentServices.GetAll();
            ViewBag.Departments = _DepartmentServices.GetAll();
            return View();
        }


        [HttpPost]
        public IActionResult Create(EmployeeDto employee) 
        {
            try
            {
                if ((ModelState.IsValid))
                {
                    _employeeServices.Add(employee);
                    return RedirectToAction(nameof(Index));
                }
                return View(employee);
            }
            catch (Exception ex) 
            { 
            return View(employee);
            }

        }

        public async Task<IActionResult> Details(int? id)
        {
            var employee=_employeeServices.GetById(id);
            if (employee is null) 
            {
                return RedirectToAction("NotFoundPage", null, "Home");
            }
            return View(employee);

        }

        public IActionResult Delete(int id)
        {
            var employee = _employeeServices.GetById(id);
            if (employee is null)
                return RedirectToAction("NotFoundPage", null, "Home");

            _employeeServices.Delete(employee);

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("NotFoundPage", "Home");

            var employee = _employeeServices.GetById(id.Value);

            if (employee == null)
                return RedirectToAction("NotFoundPage", "Home");

            return View(employee);
        }


        [HttpPost]
        public IActionResult Edit(int? id, EmployeeDto employee)
        {
            if (employee.Id != id.Value)
                return RedirectToAction("NotFoundPage", null, "Home");


            _employeeServices.Update(employee);

            return RedirectToAction(nameof(Index));
        }
    }
}
