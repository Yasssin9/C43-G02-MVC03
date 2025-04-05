using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interface;
using Company.Service.Interfaces.DepartmentServices;
using Company.Service.Interfaces.DepartmentServices.Dto;
using Company.Service.Interfaces.IEmployeeServices.Dto;

namespace Company.Service.Services
{
    public class DepartmentService : IDepartmentServices
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(DepartmentDto departmentDto)
        {
            //var mappedDepartment = new Department
            //{
            //    Code = department.Code,
            //    Name = department.Name,
            //    CreateAt = DateTime.Now
            //};

            var mappedDepartment = _mapper.Map<Department>(departmentDto);

            _unitOfWork.Department.Add(mappedDepartment);
            _unitOfWork.Complete();
        }

        public void Delete(DepartmentDto departmentDto)
        {
            var mappedDepartment = _mapper.Map<Department>(departmentDto);

            _unitOfWork.Department.Delete(mappedDepartment);
            _unitOfWork.Complete();
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            var department= _unitOfWork.Department.GetAll();

            var mappedDepartment = _mapper.Map<IEnumerable<DepartmentDto>>(department);

            return mappedDepartment;
        }

        public DepartmentDto GetById(int? id)
        {
           

            if (id is null)
                return null;

            var department = _unitOfWork.Department.GetById(id.Value);
            var mappedDepartment = _mapper.Map<DepartmentDto>(department);

            return mappedDepartment;
        }


        public void Update(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);

            _unitOfWork.Department.Update(department);

            _unitOfWork.Complete();
        }
    }
}
