using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayerP23.Interfaces
{
    public interface IDepartmentFactory
    {
        public abstract IDepartment CreateDepartment();
    }
}
