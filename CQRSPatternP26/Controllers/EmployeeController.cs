using DataAccessLayerP26.Model;
using DataAccessLayerP26.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSPatternP26.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ICommand _commandRepository;
        private readonly IQuery _queryRepository;
        public EmployeeController(ICommand commandRepository,IQuery queryRepository)
        {
            this._commandRepository = commandRepository;
            this._queryRepository = queryRepository;
        }
        [HttpGet("{id?}")]
        public IActionResult GetEmployeesbyId(int? id)
        {
            if (id.HasValue)
            {
                var emp = _queryRepository.GetSingleEmployee(id);
                if (emp == null)
                {
                    return StatusCode(404, "Sorry,record not found!!");
                }
                return Ok(emp);
            }
            else
            {
                return Ok(_queryRepository.GetAllEmployees());
            }
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeAddVM employee)
        {
            if (ModelState.IsValid)
            {
                return Ok(_commandRepository.AddEmployee(employee));
            }
            return BadRequest("Model State is not valid");
        }
        [HttpPut]
        public IActionResult UpdateEmployee(EmployeeVM employee)
        {
            if (ModelState.IsValid)
            {
                return Ok(_commandRepository.UpdateEmployee(employee));
            }
            return BadRequest("sorry!record not found.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            return Ok(_commandRepository.DeleteEmployee(id));
        }
    }
}
