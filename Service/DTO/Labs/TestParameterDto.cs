using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO.Labs
{
    public abstract class TestParameterDto
    {
        public int Id { get; set; }
        public string TestParameterName { get; set; }
        public string FieldType { get; set; }
        public string InputPattern { get; set; }
        public string Unit { get; set; }
    }
}
