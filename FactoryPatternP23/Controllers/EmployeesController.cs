using AutoMapper;
using BAL.AbstractFactory;
using BAL.Factory;
using BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FactoryPatternP23.Dto;
using FactoryPatternP23.Interface;
using FactoryPatternP23.Model;

namespace FactoryPatternP23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
   
        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var employees = await _employeeRepository.GetEmployees();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));
        }

        [HttpGet("{id:int}", Name = "GetEmployeeById")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            if (employee != null)
            {
                return Ok(_mapper.Map<EmployeeDto>(employee));
            }
            return NotFound();
        }

        [HttpGet("{id:int}/{hours:int}")]
        public async Task<ActionResult<EmployeeDtoHourBonus>> GetOvertimePay(int id, int hours)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            IDepartment? department = null;
            switch (employee.DepartmentId)
            {
                case Department.IT:
                    department = new ITFactory().CreateDepartment();
                    break;  
                case Department.Sales:
                    department = new SalesFactory().CreateDepartment();
                    break;
                default:
                    break;
            }
            var employeeHourBouns = _mapper.Map<EmployeeDtoHourBonus>(employee);
            employeeHourBouns.Hours = hours;
            if (department != null)
            {
                employeeHourBouns.Bouns = department.CalculateOvertime(hours);
            }
            return Ok(employeeHourBouns);
        }

    
        [HttpPost]
        public async Task<IActionResult> AddEmployee(CreateEmployeeDto createEmployee)
        {
            if (ModelState.IsValid)
            {
                var insertEmployee = _mapper.Map<Employee>(createEmployee);
                await _employeeRepository.AddEmployee(insertEmployee);
                var addedEmployee = _mapper.Map<EmployeeDto>(insertEmployee);
                return Ok(addedEmployee);
            }
           return BadRequest();
        }        

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EmployeeDto>> DeleteEmployee(int id)
        {
            var employeeEntity = await _employeeRepository.GetEmployeeById(id);
            if (employeeEntity is null)
            {
                return NotFound();
            }
            await _employeeRepository.DeleteEmployee(employeeEntity);
            return NoContent();
        }

        [HttpGet("{id:int}/abstract/hours/{hours:int}")]
        public async Task<ActionResult<EmployeeDtoHourBonus>> GetOvertimePayUsingAbstract(int id, int hours)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            if (employee is null)
            {
                return NotFound();
            }

            IndoorDepartmentFactory? indoorDepartmentFactory = null;
            OutDoorDepartmentFactory? outdoorDepartmentFactory = null;
            IDepartment? department = null;
            switch (employee.DepartmentId)
            {
                case Department.IT:
                    indoorDepartmentFactory = new ITAbstractFactory();
                    department = indoorDepartmentFactory.CreateDepartment();
                    break;
                case Department.HR:
                    indoorDepartmentFactory = new HRAbstractFactory();
                    department = indoorDepartmentFactory.CreateDepartment();
                    break;
                case Department.Sales:
                    outdoorDepartmentFactory = new SalesAbstractFactory();
                    department = outdoorDepartmentFactory.CreateDepartment();
                    break;
                case Department.OnSite:
                    outdoorDepartmentFactory = new OnSiteAbstractFactory();
                    department = outdoorDepartmentFactory.CreateDepartment();
                    break;
                default:
                    break;
            }
            var employeeHourBouns = _mapper.Map<EmployeeDtoHourBonus>(employee);
            employeeHourBouns.Hours = hours;
            if (department is not null)
            {
                employeeHourBouns.Bouns = department.CalculateOvertime(hours);
            }
            return Ok(employeeHourBouns);
        }
    }
}
