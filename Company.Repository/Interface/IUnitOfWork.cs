using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Interface
{
    public interface IUnitOfWork
    {
        public IDepartmentRepository Department { get; set; }
        public IEmployeeRepository Employee { get; set; }
        int Complete();

    }
}
