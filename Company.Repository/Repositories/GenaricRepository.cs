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
    public class GenaricRepository<T> : IGenaricRepository<T> where T : BaseEntity
    {
        private readonly CompanyDbContext _context;

        public GenaricRepository(CompanyDbContext context)
        {
            _context = context;
        }

        public void Add(T Entity)
        { 
            _context.Add(Entity);
            _context.SaveChanges();
        }


        public void Delete(T Entity)
        {
            _context.Remove(Entity);
            _context.SaveChanges();
        }

        

        public IEnumerable<T> GetAll()
        => _context.Set<T>().ToList();

        public T GetById(int id)
        => _context.Set<T>().Find(id);

        public void Update(T Entity)
        {
            _context.Set<T>().Update(Entity);
            _context.SaveChanges();
        }

    }
}
