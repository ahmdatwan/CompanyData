using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CompanyData.BLL.Models;
using CompanyData.DAL.Entities;

namespace CompanyData.BLL.Mappers
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<Employee,EmployeeDTO>();
            CreateMap<Models.EmployeeDTO, Employee>();
            CreateMap<Models.EmployeeForCreationDTO, Employee>();
            CreateMap<Employee, Models.EmployeeForCreationDTO>();

        }
    }
}
