using MediatR;
using Microsoft.EntityFrameworkCore;
using MediatorPatternP25.Data;
using MediatorPatternP25.Models;

namespace MediatorPatternP25.MediatorClass
{
    public class GetAllEmployees : IRequest<IEnumerable<Employee>>
    {
        public class GetAllEmployeesHanlder : IRequestHandler<GetAllEmployees, IEnumerable<Employee>>
        {
            private readonly ApplicationContext _context;
            public GetAllEmployeesHanlder(ApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Employee>> Handle(GetAllEmployees request, CancellationToken cancellationToken)
            {
                var employees = await _context.Employees.Where(x=>x.Isdeleted == Convert.ToBoolean(0)).ToListAsync();
                return employees;
            }
        }
    }
}
