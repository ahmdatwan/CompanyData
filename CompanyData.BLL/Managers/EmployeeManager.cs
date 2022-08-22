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
    public class EmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private const string IdNotFoundErrorMessage = "Employee ID not found";

        public EmployeeManager(IEmployeeRepository employeeRepository,IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<bool> isExistingEmployee(int employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            return employee != null;
        }

        public async Task<IEnumerable<EmployeeDTO>>GetEmployees()
        {
            var employeeEntities = await _employeeRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<EmployeeDTO>>(employeeEntities);
        }
        public async Task<EmployeeDTO> GetEmployee(int employeeId)
        {
            var existEmployee = await isExistingEmployee(employeeId);
            if (!existEmployee)
            {
                throw new InvalidIdException(IdNotFoundErrorMessage);
            }
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            return _mapper.Map<EmployeeDTO>(employee);

        }

        public async Task<EmployeeDTO> CreateEmployee(int departmentId, EmployeeForCreationDTO employee)
        {
            var department = await  _departmentRepository.GetByIdAsync(departmentId);
            if (department==null)
            {
                throw new InvalidIdException(IdNotFoundErrorMessage);
            }
            var employeeEntity = _mapper.Map<Employee>(employee);
            _employeeRepository.Insert(employeeEntity, department);
            await _employeeRepository.SaveChangesAsync();
            return _mapper.Map<EmployeeDTO>(employeeEntity);


        }

        public async Task UpdateEmployee(int employeeId, EmployeeForCreationDTO employee)
        {
            var existEmployee = await isExistingEmployee(employeeId);
            if (!existEmployee)
            {
                throw new InvalidIdException(IdNotFoundErrorMessage);
            }
             
            var toUpdatetDepartment = await _departmentRepository.GetByIdAsync(employee.DepartmentId);
            if (toUpdatetDepartment == null)
            {
                throw new InvalidIdException("Department ID does not exist");
            }

            var employeeToUpdate = await _employeeRepository.GetByIdAsync(employeeId);

            _mapper.Map(employee, employeeToUpdate);

            await _employeeRepository.SaveChangesAsync();

        }

        public async Task DeleteEmployee(int employeeId)
        {
            var existEmployee = await isExistingEmployee(employeeId);
            if (!existEmployee)
            {
                throw new InvalidIdException(IdNotFoundErrorMessage);
            }
            var employeeToDelete = await _employeeRepository.GetByIdAsync(employeeId);

            _employeeRepository.DeleteAsync(employeeToDelete);
            await _employeeRepository.SaveChangesAsync();

        }

        
    }
}

