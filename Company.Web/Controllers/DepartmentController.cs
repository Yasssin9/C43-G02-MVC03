using Company.Data.Models;
using Company.Repository.Interface;
using Company.Service.Interfaces.DepartmentServices;
using Company.Service.Interfaces.DepartmentServices.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentServices;

        public DepartmentController(IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments= _departmentServices.GetAll();

            //TempData.Keep("TextTempMessage");
            
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentDto department)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _departmentServices.Add(department);

                    TempData["TextTempMessage"] = "Hello From Employee Index (TempData)";

                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("DepartmentError", "ValidationError");
                return View(department);

            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("DepartmentError", ex.Message);
                return View(department);
            }
        }


        public IActionResult Details(int? id,string ViewName="Details") 
        {
            var department=_departmentServices.GetById(id);

            if (department is null)
                return RedirectToAction("NotFoundPage", null, "Home");

            return View(ViewName, department);
        
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("NotFoundPage", "Home");

            var department = _departmentServices.GetById(id.Value);

            if (department == null)
                return RedirectToAction("NotFoundPage", "Home");

            return View(department);
        }


        [HttpPost]
        public IActionResult Edit(int? id, DepartmentDto department)
        {
            if(department.Id !=  id.Value)
                return RedirectToAction("NotFoundPage", null, "Home");


            _departmentServices.Update(department);

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id) 
        {
        var department=_departmentServices.GetById(id);
            if (department is null)
                return RedirectToAction("NotFoundPage", null, "Home");

            _departmentServices.Delete(department);

            return RedirectToAction(nameof(Index));
        }
    }
}
