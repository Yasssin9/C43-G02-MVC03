using Company.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Interface
{
    public interface IEmployeeRepository  : IGenaricRepository<Employee>     
    {
        Employee GetEmployeeByName(string name);
        IEnumerable<Employee> GetEmployeeByAddress(string address);
       
    }
}
