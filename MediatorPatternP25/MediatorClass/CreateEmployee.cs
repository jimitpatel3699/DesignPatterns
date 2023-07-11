using MediatR;
using MediatorPatternP25.Data;
using MediatorPatternP25.Models;

namespace MediatorPatternP25.MediatorClass
{
    public class CreateEmployee : IRequest<Employee>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public decimal Salary { get; set; }
        public Status Status { get; set; }
        public Department DepartmentId { get; set; }

        public class CreateEmployeeHandler : IRequestHandler<CreateEmployee, Employee>
        {
            private readonly ApplicationContext _context;
            public CreateEmployeeHandler(ApplicationContext context)
            {
                _context = context;
            }

            public async Task<Employee> Handle(CreateEmployee request, CancellationToken cancellationToken)
            {
                var employee = new Employee { Name = request.Name, Salary = request.Salary, Email = request.Email, DepartmentId = request.DepartmentId,Status=request.Status };
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
        }
    }
}
