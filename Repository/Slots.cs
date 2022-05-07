using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Slots
    {
        public int slot_num { get; set; }
        public TimeSpan slot_time { get; set; }
        public DayOfWeek DayOfWork { get; set; }
    }
}
