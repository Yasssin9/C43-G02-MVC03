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
    public class DepartmentRepository:GenaricRepository<Department>, IDepartmentRepository
    {
        private readonly CompanyDbContext _context;

        public DepartmentRepository(CompanyDbContext context):base(context)
        {
            _context = context;
        }

       
    }
}
