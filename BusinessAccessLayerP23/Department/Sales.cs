﻿using BusinessAccessLayerP23.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayerP23.Department
{
    public class Sales : IDepartment
    {
        public decimal CalculateOvertime(int hours)
        {
            return (hours * 100);
        }
    }
}
