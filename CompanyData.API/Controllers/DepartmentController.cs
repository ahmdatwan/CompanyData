using CompanyData.BLL.Exceptions;
using CompanyData.BLL.Managers;
using CompanyData.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyData.API.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentManager _departmentManager;
        public DepartmentController(DepartmentManager departmentManager)
        {
           _departmentManager = departmentManager ?? throw new ArgumentNullException(nameof(departmentManager));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDTO>>> GetDepartments()
        {
            

            return Ok(await _departmentManager.GetDepartments());
        }
        [HttpGet("{departmentId}", Name = "GetDepartment")]
        public async Task<ActionResult<DepartmentDTO>> GetDepartment(int departmentId)
        {
            try
            {
                return Ok(await _departmentManager.GetDepartment(departmentId));
            }
            catch (InvalidIdException ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpPost]
        public async Task<ActionResult> CreateDepartment(DepartmentForCreationDTO department)
        {
           var createdDepartment = await _departmentManager.CreateDepartment(department);
            return CreatedAtRoute("GetDepartment", new { departmentId = createdDepartment.Id }, createdDepartment);
        }

        [HttpPut("{departmentId}")]
        public async Task<ActionResult> UpdateDepartment(int departmentId, DepartmentForCreationDTO department)
        {
            try
            {
                await _departmentManager.UpdateDepartment(departmentId, department);
                return NoContent();
            }
            catch(InvalidIdException ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        [HttpDelete("{departmentId}")]
        public async Task<ActionResult> DeleteDepartment(int departmentId)
        {
            try
            {
                await _departmentManager.DeleteDepartment(departmentId);
                return NoContent();
            }
            catch(InvalidIdException ex)
            {
                return NotFound(ex.Message);
            }
            catch(NonEmptyObjectException ex)
            {
                return UnprocessableEntity(ex.Message);
            }

        }
        [HttpGet("getAllEmployees/{departmentId}")]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetDepartmentEmployees(int departmentId)
        {
            try
            {
                return Ok(await _departmentManager.GetDepartmentEmployees(departmentId));
            }
            catch (InvalidIdException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
