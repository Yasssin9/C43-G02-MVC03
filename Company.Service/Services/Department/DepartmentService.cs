using Company.Data.Models;
using Company.Repository.Interface;
using Company.Service.Interfaces;

namespace Company.Service.Services
{
    public class DepartmentService : IDepartmentServices
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void Add(Department department)
        {
            var mappedDepartment = new Department
            {
                Code = department.Code,
                Name = department.Name,
                CreateAt = DateTime.Now
            };

            _departmentRepository.Add(mappedDepartment);

        }

        public void Delete(Department department)
        {
            _departmentRepository.Delete(department);
        }

        public IEnumerable<Department> GetAll()
        {
            var department= _departmentRepository.GetAll();

            return department;
        }

        public Department GetById(int? id)
        {
            if (id is null)
                return null;  

            return _departmentRepository.GetById(id.Value); 
        }


        public void Update(Department department)
        {
            _departmentRepository.Update(department);
        }
    }
}
