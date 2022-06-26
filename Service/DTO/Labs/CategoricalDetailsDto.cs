using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO.Labs
{
    public class CategoricalDetailsDto : TestDetailsDto
    {
        public string MeasuredValue { get; set; }
        public string? NormalValue { get; set; }
    }
}
