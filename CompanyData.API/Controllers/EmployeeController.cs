using CompanyData.BLL.Exceptions;
using CompanyData.BLL.Managers;
using CompanyData.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyData.API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeManager _employeeManager;
        public EmployeeController(EmployeeManager employeeManager)
        {
                _employeeManager = employeeManager ??  throw new ArgumentNullException(nameof(employeeManager)); ;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            return Ok(await _employeeManager.GetEmployees());
        }
        [HttpGet("{employeeId}", Name = "GetEmployee")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int employeeId)
        {
            try
            {
                return Ok(await _employeeManager.GetEmployee(employeeId));
            }
            catch (InvalidIdException ex)
            {
                return NotFound(ex.Message);
            }
        }
       
        [HttpPost("createEmployeeAtDepartment/{departmentId}")]
        public async Task<ActionResult> CreateEmployee(int departmentId, EmployeeForCreationDTO employee)
        {
            
            var createdEmployee = await _employeeManager.CreateEmployee(departmentId, employee);
            return CreatedAtRoute("GetEmployee", new { employeeId = createdEmployee.Id }, createdEmployee);

        }
        [HttpPut("{employeeId}")]
        public async Task<ActionResult> UpdateEmployee(int employeeId, EmployeeForCreationDTO employee)
        {
            try
            {
                await _employeeManager.UpdateEmployee(employeeId,employee);
                return NoContent();
            }
            catch (InvalidIdException ex)
            {
                return NotFound(ex.Message);
            }
        }
       
        [HttpDelete("{employeeId}")]
        public async Task<ActionResult> DeleteEmployee(int employeeId)
        {
            try
            {
                await _employeeManager.DeleteEmployee(employeeId);
                return NoContent();
            }
            catch (InvalidIdException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
