using MediatR;
using Microsoft.EntityFrameworkCore;
using MediatorPatternP25.Data;
using MediatorPatternP25.Models;

namespace MediatorPatternP25.MediatorClass
{
    public class DeleteEmployee : IRequest<Employee>
    {
        public int Id { get; set; }

        public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployee, Employee>
        {
            private readonly ApplicationContext _context;

            public DeleteEmployeeHandler(ApplicationContext context)
            {
                _context = context;
            }
            public async Task<Employee> Handle(DeleteEmployee request, CancellationToken cancellationToken)
            {
                var employee = _context.Employees.FirstOrDefault(emp => emp.Id == request.Id);
                if (employee is not null)
                {                    
                    employee.Isdeleted = true;
                    await _context.SaveChangesAsync();
                    return employee;
                }
                return default;
            }
        }
    }
}
