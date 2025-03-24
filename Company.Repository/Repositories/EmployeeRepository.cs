using Company.Data.Contexts;
using Company.Data.Models;
using Company.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class EmployeeRepository :GenaricRepository<Employee>, IEmployeeRepository
    {
        private readonly CompanyDbContext _context;

        public EmployeeRepository(CompanyDbContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployeeByAddress(string address)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
