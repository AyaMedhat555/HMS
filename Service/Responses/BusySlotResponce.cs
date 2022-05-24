using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Responses
{
    public class BusySlotResponce
    {
        public DateTime Day { get; set; }
        public List<TimeSpan> BusySlots { get; set; }
    }
}
