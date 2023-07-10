using DataAccessLayerP22.Handler;
using DataAccessLayerP22.Model;
using DataAccessLayerP22.Repository;
using DataAccessLayerP22.Singleton;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SingletonPatternP22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeRepository;
        private readonly Logger _logger = SingletonClass.GetLoggerInstance();
        public EmployeeController(IEmployee employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }
        [HttpGet("{id?}")]
        public IActionResult GetEmployeesbyId(int? id)
        {
            _logger.Log("GetEmployeesbyId action method called");
         if(id.HasValue) 
         {
                var emp = _employeeRepository.GetSingleEmployee(id);
                if (emp == null)
                {
                    _logger.ErrorLog("404,Sorry,record not found!!");
                    return StatusCode(404, "Sorry,record not found!!");
                }
                return Ok(emp);
         }
         else
            {
                _logger.Log("AllEmployee action method called");
                return Ok(_employeeRepository.GetAllEmployees());
            }
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeAddVM employee)
        {
            _logger.Log("AddEmployee action method called");
            if (ModelState.IsValid)
            {
                return Ok(_employeeRepository.AddEmployee(employee));
            }
            _logger.ErrorLog("Model State is not valid from AddEmployee action method ");
            return BadRequest("Model State is not valid");
        }
        [HttpPut]
        public IActionResult UpdateEmployee(EmployeeViewModel employee)
        {
            _logger.Log("UpdateEmployee action method called");
            if (ModelState.IsValid)
            {
                return Ok(_employeeRepository.UpdateEmployee(employee));
            }
            _logger.ErrorLog("sorry!record not found from UpdateEmployee action method ");
            return BadRequest("sorry!record not found.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _logger.Log("DeleteEmployee action method called");
            return Ok(_employeeRepository.DeleteEmployee(id));
        }
    }
}
