using Company.Data.Models;
using Company.Repository.Repositories;
using Company.Service.Interfaces.DepartmentServices;
using Company.Service.Interfaces.IEmployeeServices;
using Company.Service.Interfaces.IEmployeeServices.Dto;
using Microsoft.AspNetCore.Mvc;

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
            //ViewBag.Message = "Hello From Employee Index (ViewBag)";

            //ViewData["TextMessage"] = "Hello From Employee Index (ViewData)";


            if (string.IsNullOrEmpty(searchIp))
            {
                var employee = _employeeServices.GetAll();
                return View(employee);
            }
            else             
            {
            var employees= _employeeServices.GetEmployeeByName(searchIp);
                return View (employees);
            }
           
        }
        [HttpGet]
        public IActionResult Create() 
        {           
            ViewBag.departments = _DepartmentServices.GetAll();
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






    }
}
