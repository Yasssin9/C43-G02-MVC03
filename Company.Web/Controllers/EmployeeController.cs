using Company.Data.Models;
using Company.Repository.Repositories;
using Company.Service.Interfaces.DepartmentServices;
using Company.Service.Interfaces.IEmployeeServices;
using Company.Service.Interfaces.IEmployeeServices.Dto;
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
            //ViewBag.Message = "Hello From Employee Index (ViewBag)";

            //ViewData["TextMessage"] = "Hello From Employee Index (ViewData)";

            IEnumerable<EmployeeDto> employee = new List<EmployeeDto>();

            if (string.IsNullOrEmpty(searchIp))
                employee = _employeeServices.GetAll();
            else             
                employee= _employeeServices.GetEmployeeByName(searchIp);
                return View (employee);

           
        }
        [HttpGet]
        public IActionResult Create()
        {
            var departments = _DepartmentServices.GetAll();
            ViewBag.Departments = departments;
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
