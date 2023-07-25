using MediatR;
using Microsoft.EntityFrameworkCore;
using MediatorPatternP25.Data;
using MediatorPatternP25.Models;

namespace MediatorPatternP25.MediatorClass
{
    public class GetEmployeeById : IRequest<Employee>
    {
        public int Id { get; set; }
        public class GetAllEmployeesHanlder : IRequestHandler<GetEmployeeById, Employee?>
        {
            private readonly ApplicationContext _context;
            public GetAllEmployeesHanlder(ApplicationContext context)
            {
                _context = context;
            }
            public async Task<Employee?> Handle(GetEmployeeById request, CancellationToken cancellationToken)
            {
                var employee = await _context.Employees.Where(x => x.Isdeleted == Convert.ToBoolean(0)).FirstOrDefaultAsync(emp => emp.Id == request.Id);
                return employee;
            }
        }
    }
}