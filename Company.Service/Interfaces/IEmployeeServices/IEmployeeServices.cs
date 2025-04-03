using Company.Data.Models;
using Company.Service.Interfaces.IEmployeeServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Interfaces.IEmployeeServices
{
    public interface IEmployeeServices
    {
        EmployeeDto GetById(int? id);
        IEnumerable<EmployeeDto> GetAll();
        void Add(EmployeeDto Employee);
        void Update(EmployeeDto Employee);
        void Delete(EmployeeDto Employee);
        IEnumerable<EmployeeDto> GetEmployeeByName(string name);

    }
}
