using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MediatorPatternP25.MediatorClass;
using MediatorPatternP25.Models;
using MediatorPatternP25.Validate;

namespace MediatorPatternP25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            ValidateEmployee validation = new ValidateEmployee();
            ValidationResult result = validation.Validate(employee);
            if (result.IsValid)
            {
                CreateEmployee command = new CreateEmployee() { Name = employee.Name, Email = employee.Email, Salary = employee.Salary, DepartmentId = employee.DepartmentId };

                return _mediator.Send(command).ContinueWith(task =>
                {
                    if (task.IsCompletedSuccessfully)
                    {
                        return Ok(task.Result);
                    }
                    else
                    {
                        return BadRequest();
                    }
                });
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return _mediator.Send(new GetAllEmployees()).ContinueWith(task =>
            {
                if (task.IsCompletedSuccessfully)
                {
                    return Ok(task.Result);
                }
                else
                {
                    return BadRequest();
                }
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return _mediator.Send(new GetEmployeeById { Id = id }).ContinueWith(task =>
            {
                if (task.IsCompletedSuccessfully)
                {
                    var emp = task.Result;
                    if (emp != null)
                    {
                        return Ok(emp);
                    }
                    else
                    {
                        return NotFound("Employee with this id could not be found");
                    }
                }
                else
                {
                    return BadRequest();
                }
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            ValidateEmployee validation = new ValidateEmployee();
            ValidationResult result = validation.Validate(employee);
            if (result.IsValid)
            {
                UpdateEmployee command = new UpdateEmployee() { Id = id, Name = employee.Name, Email = employee.Email, Salary = employee.Salary, DepartmentId = employee.DepartmentId };

                return _mediator.Send(command).ContinueWith(task =>
                {
                    if (task.IsCompletedSuccessfully)
                    {
                        return Ok(task.Result);
                    }
                    else
                    {
                        return BadRequest();
                    }
                });
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return GetById(id).ContinueWith(task =>
            {
                if (task.IsCompletedSuccessfully)
                {
                    var result = task.Result;
                    if (result != null)
                    {
                        DeleteEmployee command = new DeleteEmployee() { Id = id };
                        return _mediator.Send(command).ContinueWith(deleteTask =>
                        {
                            if (deleteTask.IsCompletedSuccessfully)
                            {
                                return Ok(deleteTask.Result);
                            }
                            else
                            {
                                return BadRequest();
                            }
                        });
                    }
                }
                return BadRequest();
            });
        }
    }
}
