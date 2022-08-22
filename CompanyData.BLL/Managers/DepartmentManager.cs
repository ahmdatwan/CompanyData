using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CompanyData.BLL.Exceptions;
using CompanyData.BLL.Models;
using CompanyData.DAL.Entities;
using CompanyData.DAL.Repositories;

namespace CompanyData.BLL.Managers
{
   
    public class DepartmentManager
    {
         private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;
        private const string IdNotFoundErrorMessage = "Department ID not found";
        
        public DepartmentManager(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<bool> isExistingDepartment(int departmentId)
        {
            var department = await _departmentRepository.GetByIdAsync(departmentId);
            return department != null;
        } 

        public async Task<IEnumerable<DepartmentDTO>> GetDepartments()
        {
            var departmentsEntities = await _departmentRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<DepartmentDTO>>(departmentsEntities);
        }
        public async Task<DepartmentDTO> GetDepartment(int departmentId)
        {
            var existDepartment = await isExistingDepartment(departmentId);  
            if (! existDepartment)
            {
                 throw new InvalidIdException(IdNotFoundErrorMessage);
            }
            var department = await _departmentRepository.GetByIdAsync(departmentId);
            return _mapper.Map<DepartmentDTO>(department);

        }

        public async Task<DepartmentDTO> CreateDepartment(DepartmentForCreationDTO department)
        {
            var departmentEntity = _mapper.Map<Department>(department);
            _departmentRepository.Insert(departmentEntity);
            await _departmentRepository.SaveChangesAsync();
            return _mapper.Map<DepartmentDTO>(departmentEntity);
            
        }

        public async Task UpdateDepartment(int departmentId, DepartmentForCreationDTO department)
        {
            var existDepartment = await isExistingDepartment(departmentId);
            if (!existDepartment)
            {
                throw new InvalidIdException(IdNotFoundErrorMessage);
            }

            var departmentToUpdate = await _departmentRepository.GetByIdAsync(departmentId);
           
            _mapper.Map(department, departmentToUpdate);
            await _departmentRepository.SaveChangesAsync();
            
        }

        public async Task  DeleteDepartment(int departmentId)
        {
            var existDepartment = await isExistingDepartment(departmentId);
            if (!existDepartment)
            {
                throw new InvalidIdException(IdNotFoundErrorMessage);
            }
            var departmentToDelete = await _departmentRepository.GetByIdAsync(departmentId);
            
            var departmentEmployees = await _departmentRepository.GetEmployees(departmentId);
            if (departmentEmployees.Any())
            {
                throw new NonEmptyObjectException("Department contains employees!");
            }
            _departmentRepository.DeleteAsync(departmentToDelete);
            await _departmentRepository.SaveChangesAsync();

        }

        public async Task<IEnumerable<EmployeeDTO>> GetDepartmentEmployees(int departmentId)
        {
            var department = await _departmentRepository.GetByIdAsync(departmentId);
            if (department == null)
                throw new InvalidIdException(IdNotFoundErrorMessage);
            var departmentEmployees = await _departmentRepository.GetEmployees(departmentId);
            return _mapper.Map<IEnumerable<EmployeeDTO>>(departmentEmployees);
        }
    }
}
