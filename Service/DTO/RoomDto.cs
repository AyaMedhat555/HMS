using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.DTO
{
    public  class RoomDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Id { get; set; }
        public int RoomCharges { get; set; }
        public string RoomType { get; set; }
        public int NumberOfBeds { get; set; }
        public int FloorNumber { get; set; }
        public int RoomNumber { get; set; }
        public int  DepartmentId { get; set; }
        public virtual ICollection<BedDto> Beds { get; set; } = new HashSet<BedDto>();

    }
}
