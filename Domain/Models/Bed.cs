using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Bed
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public bool Reserved { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }

       
       
        

    }
}
