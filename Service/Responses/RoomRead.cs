using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Responses
{
    public class RoomRead
    {
        public string RoomType { get; set; }
        public int NumberOf_freeBeds { get; set; }
        public int NumberOf_allBeds { get; set; }
        public int FloorNumber { get; set; }
        public int RoomNumber { get; set; }

    }
}


