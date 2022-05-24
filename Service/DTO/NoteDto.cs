using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.DTO
{
    public  class NoteDto

    {
      
        //public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Body { get; set; }
        public int? NurseId { get; set; }
        public int? DoctorId { get; set; }
        public int? IndoorPatientRecordId { get; set; }
    }
}
