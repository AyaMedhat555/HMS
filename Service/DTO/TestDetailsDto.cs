using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public abstract class TestDetailsDto
    {
        public int TestParameterId { get; set; }
        public string? TestParameterName { get; set; }
        public string? Unit { get; set; }
    }
}
