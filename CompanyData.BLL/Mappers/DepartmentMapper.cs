using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CompanyData.DAL.Entities;

namespace CompanyData.BLL.Mappers
{
    internal class DepartmentMapper : Profile
    {
        public DepartmentMapper()
        {
           
            CreateMap<Department, Models.DepartmentDTO>();
            CreateMap<Models.DepartmentForCreationDTO, Department>();
            CreateMap<Models.DepartmentDTO,Department>();
            CreateMap<Department, Models.DepartmentForCreationDTO>();
        }
    }
}
