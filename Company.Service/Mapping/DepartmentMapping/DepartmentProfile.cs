using AutoMapper;
using Company.Data.Models;
using Company.Service.Interfaces.DepartmentServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Mapping.DepartmentMapping
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();     
        }
    }
}
