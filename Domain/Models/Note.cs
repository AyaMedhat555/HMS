
namespace Domain.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Body { get; set; }
        public Nurse Nurse { get; set; }
         
        public int NurseId { get; set; }
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        public int? IndoorPatientRecordId { get; set; }






    }
}
