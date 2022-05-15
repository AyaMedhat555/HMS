using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class FullSlots
    {
        public DateTime AppointmentDate { get; set; }

        public List<TimeSlot> FreeSlots { get; set; }
    }
}
