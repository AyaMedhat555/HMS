
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Doctor:User
    {
        public string DocDegree { get; set; }
        public string DocSpecialization  { get; set; }

        // public virtual ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>(); //collection navigation property


    }
}

//- department: Department
//- patients:Patient[] 
//- dodtor_notes: String