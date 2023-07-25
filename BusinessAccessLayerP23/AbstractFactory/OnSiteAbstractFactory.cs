using BusinessAccessLayerP23.Department;
using BusinessAccessLayerP23.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayerP23.AbstractFactory
{
    public class OnSiteAbstractFactory : OutDoorDepartmentFactory
    {
        public override IDepartment CreateDepartment()
        {
            return new OnSite();
        }
    }
}
