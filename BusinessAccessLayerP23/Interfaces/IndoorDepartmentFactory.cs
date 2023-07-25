using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayerP23.Interfaces
{
    public abstract class IndoorDepartmentFactory : IDepartmentFactory
    {
        public abstract IDepartment CreateDepartment();
    }
}
