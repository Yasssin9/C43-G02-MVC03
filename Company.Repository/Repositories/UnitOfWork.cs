using Company.Data.Contexts;
using Company.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDbContext _context;

        public UnitOfWork(CompanyDbContext context)
        {
            _context = context;
            Department = new DepartmentRepository(context);
            Employee = new EmployeeRepository(context);
        }

        
        public IDepartmentRepository Department { get; set; }
        public IEmployeeRepository Employee { get; set; }

        public int Complete()
        => _context.SaveChanges();
        
    }
}
