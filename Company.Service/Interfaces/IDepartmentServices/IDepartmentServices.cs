using Company.Data.Models;
using Company.Service.Interfaces.DepartmentServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Interfaces.DepartmentServices
{
    public interface IDepartmentServices
    {
        DepartmentDto GetById(int? id);
        IEnumerable<DepartmentDto> GetAll();
        void Add(DepartmentDto Department);
        void Update(DepartmentDto Department);
        void Delete(DepartmentDto Department);

    }
}
