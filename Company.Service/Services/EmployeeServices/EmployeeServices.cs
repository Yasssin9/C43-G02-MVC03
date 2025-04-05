using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interface;
using Company.Service.Helper;
using Company.Service.Interfaces.IEmployeeServices;
using Company.Service.Interfaces.IEmployeeServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services.EmployeeServices
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeServices(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(EmployeeDto EmployeeDto)
        {
            //Manual Mapping
            //Employee employee=new Employee
            //{
            //    Address = EmployeeDto.Address,
            //    Age = EmployeeDto.Age,
            //    DepartmentId = EmployeeDto.DepartmentId,
            //    Email = EmployeeDto.Email,
            //    HiringDate = EmployeeDto.HiringDate,
            //    ImageUrl = EmployeeDto.ImageUrl,
            //    Name = EmployeeDto.Name,
            //    PhoneNumber = EmployeeDto.PhoneNumber,
            //    Salary = EmployeeDto.Salary
            //};

            EmployeeDto.ImageUrl = DocumentSettings.UploadFile(EmployeeDto.Image, "Images");

            Employee employee =_mapper.Map<Employee>(EmployeeDto);   

            _unitOfWork.Employee.Add(employee);
            _unitOfWork.Complete();

        }

        public void Delete(EmployeeDto employeeDto)
        {
            //Employee employee = new Employee
            //{
            //    Address = employeeDto.Address,
            //    Age = employeeDto.Age,
            //    DepartmentId = employeeDto.DepartmentId,
            //    Email = employeeDto.Email,
            //    HiringDate = employeeDto.HiringDate,
            //    ImageUrl = employeeDto.ImageUrl,
            //    Name = employeeDto.Name,
            //    PhoneNumber = employeeDto.PhoneNumber,
            //    Salary = employeeDto.Salary
            //};

            Employee employee = _mapper.Map<Employee>(employeeDto);


            _unitOfWork.Employee.Add(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var Employees = _unitOfWork.Employee.GetAll();

            //var mappedEmployees = Employee.Select(x => new EmployeeDto
            //{
            //    DepartmentId=x.DepartmentId,
            //    Address=x.Address,
            //    Age=x.Age,
            //    Email=x.Email,
            //    HiringDate=x.HiringDate,
            //    ImageUrl=x.ImageUrl,
            //    Name=x.Name,
            //    PhoneNumber=x.PhoneNumber,
            //    Salary=x.Salary,
            //    CreateAt=x.CreateAt,
            //    Id=x.Id

            //});

            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(Employees);

            return mappedEmployees;
        }

        public EmployeeDto GetById(int? id)
        {
            if (id == null)
                return null;
            var employee=_unitOfWork.Employee.GetById(id.Value);
            if (employee is null)
                return null;

            //EmployeeDto employeeDto = new EmployeeDto
            //{
            //    Address = employee.Address,
            //    Age = employee.Age,
            //    DepartmentId = employee.DepartmentId,
            //    Email = employee.Email,
            //    HiringDate = employee.HiringDate,
            //    ImageUrl = employee.ImageUrl,
            //    Name = employee.Name,
            //    PhoneNumber = employee.PhoneNumber,
            //    Salary = employee.Salary,
            //    Id = employee.Id,
            //    CreateAt = employee.CreateAt,

            //};

            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public void Update(EmployeeDto Employee)
        {
            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
            var employee= _unitOfWork.Employee.GetEmployeeByName(name);

            //var mappedEmployees = employee.Select(x => new EmployeeDto
            //{
            //    DepartmentId = x.DepartmentId,
            //    Address = x.Address,
            //    Age = x.Age,
            //    Email = x.Email,
            //    HiringDate = x.HiringDate,
            //    ImageUrl = x.ImageUrl,
            //    Name = x.Name,
            //    PhoneNumber = x.PhoneNumber,
            //    Salary = x.Salary,
            //    CreateAt = x.CreateAt,
            //    Id = x.Id

            //});

            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employee);

            return mappedEmployees;

        }
            

    }
}
