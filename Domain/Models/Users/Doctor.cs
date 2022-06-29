using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Users
{
    public class Doctor : User
    {
        public string DocDegree { get; set; }
        public string DocSpecialization { get; set; }
        public bool clinicalDoctor { get; set; }

       


    }
}

