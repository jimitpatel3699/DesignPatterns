using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FactoryPatternP23.Dto;
using FactoryPatternP23.Interface;
using FactoryPatternP23.Model;
using BusinessAccessLayerP23.Interfaces;
using BusinessAccessLayerP23.AbstractFactory;
using BusinessAccessLayerP23.Factory;
using Practical23_API.ViewModel;

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
        public ActionResult<IEnumerable<EmployeeVM>> GetEmployees()
        {
            var employees = _employeeRepository.GetEmployees();
            return Ok(_mapper.Map<IEnumerable<EmployeeVM>>(employees));
        }

        [HttpGet("{id:int}", Name = "GetEmployeeById")]
        public ActionResult<EmployeeVM> GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee != null)
            {
                return Ok(_mapper.Map<EmployeeVM>(employee));
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult AddEmployee(CreateEmployeeVM createEmployee)
        {
            if (ModelState.IsValid)
            {
                var insertEmployee = _mapper.Map<Employee>(createEmployee);
                _employeeRepository.AddEmployee(insertEmployee);
                var addedEmployee = _mapper.Map<EmployeeVM>(insertEmployee);
                return Ok(addedEmployee);
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateEmployee(UpdateVM updateEmployee) 
        {
            if (ModelState.IsValid)
            {
               var updatedEmployee = _employeeRepository.UpdateEmployee(updateEmployee);
                return Ok(updatedEmployee);
            }
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Employee> DeleteEmployee(int id)
        {
            var employeeEntity = _employeeRepository.GetEmployeeById(id);
            if (employeeEntity !=null)
            {
                return _employeeRepository.DeleteEmployee(employeeEntity);
            }
            
            return NoContent();
        }
        //factorypattern
        [HttpGet("{id:int}/{hours:int}")]
        public ActionResult<EmployeeHourBonusVM> GetOvertimePay(int id, int hours)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
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
            var employeeHourBouns = _mapper.Map<EmployeeHourBonusVM>(employee);
            employeeHourBouns.Hours = hours;
            if (department != null)
            {
                employeeHourBouns.Bouns = department.CalculateOvertime(hours);
            }
            return Ok(employeeHourBouns);
        }
        //abstract factory method
        [HttpGet("{id:int}/abstract/hours/{hours:int}")]
        public ActionResult<EmployeeHourBonusVM> GetOvertimePayUsingAbstract(int id, int hours)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
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
            var employeeHourBouns = _mapper.Map<EmployeeHourBonusVM>(employee);
            employeeHourBouns.Hours = hours;
            if (department is not null)
            {
                employeeHourBouns.Bouns = department.CalculateOvertime(hours);
            }
            return Ok(employeeHourBouns);
        }
    }
}
