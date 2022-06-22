using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class TestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float TestCharge { get; set; }
        public virtual ICollection<CategoricalParamterDto> CategoricalParamters { get; set; } = new HashSet<CategoricalParamterDto>();
        public virtual ICollection<NeumericalParameterDto> NumericalParamters { get; set; } = new HashSet<NeumericalParameterDto>();
    }
}
