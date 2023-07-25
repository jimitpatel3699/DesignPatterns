using DataAccessLayerP24.Model;
using DataAccessLayerP24.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RepositoryPatternP24.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeRepository;
        public EmployeeController(IEmployee employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }
        [HttpGet("{id?}")]
        public IActionResult GetEmployeesbyId(int? id)
        {
            if (id.HasValue)
            {
                var emp = _employeeRepository.GetSingleEmployee(id);
                if (emp == null)
                {
                    return StatusCode(404, "Sorry,record not found!!");
                }
                return Ok(emp);
            }
            else
            {
                return Ok(_employeeRepository.GetAllEmployees());
            }
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeAddVM employee)
        {
            if (ModelState.IsValid)
            {
                return Ok(_employeeRepository.AddEmployee(employee));
            }
            return BadRequest("Model State is not valid");
        }
        [HttpPut]
        public IActionResult UpdateEmployee(EmployeeVM employee)
        {
            if (ModelState.IsValid)
            {
                return Ok(_employeeRepository.UpdateEmployee(employee));
            }
            return BadRequest("sorry!record not found.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            return Ok(_employeeRepository.DeleteEmployee(id));
        }
    }
}
