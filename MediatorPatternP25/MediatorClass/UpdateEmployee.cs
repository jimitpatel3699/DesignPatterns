using MediatR;
using MediatorPatternP25.Data;
using MediatorPatternP25.Models;

namespace MediatorPatternP25.MediatorClass
{
    public class UpdateEmployee : IRequest<Employee>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        public string? Email { get; set; }
        public Status Status { get; set; }
        public Department DepartmentId { get; set; }
        public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployee, Employee>
        {
            private readonly ApplicationContext _context;
            public UpdateEmployeeHandler(ApplicationContext context)
            {
                _context = context;
            }

            public async Task<Employee> Handle(UpdateEmployee request, CancellationToken cancellationToken)
            {
                var employee = _context.Employees.FirstOrDefault(emp => emp.Id == request.Id);
                if (employee != null)
                {
                    employee.Name = request.Name;
                    employee.Salary = request.Salary;
                    employee.Email = request.Email;
                    employee.DepartmentId = request.DepartmentId;
                    await _context.SaveChangesAsync();
                    return employee;
                }
                return default;
            }
        }
    }
}
