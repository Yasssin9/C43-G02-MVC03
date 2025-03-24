using Company.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Interface
{
    public interface IGenaricRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }
}
