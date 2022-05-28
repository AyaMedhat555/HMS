using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class AppointmentDto
    {
        public DateTime AppointmentDate { get; set; }

        public string AppointmentType { get; set; }

        public string Complain { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public bool Examined { get; set; }

    }
}
