using AutoMapper;
using Company.Data.Models;
using Company.Service.Interfaces.IEmployeeServices.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Mapping.EmployeeMapping
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee,EmployeeDto>().ReverseMap();
        }

    }
}
