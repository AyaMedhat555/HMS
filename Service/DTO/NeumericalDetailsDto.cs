﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class NeumericalDetailsDto : TestDetailsDto
    {
        public float NumericalValue { get; set; }
        public float Min_Range { get; set; }
        public float Max_Range { get; set; }

    }
}
