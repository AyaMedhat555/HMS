using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public Doctor Doctor { get; set; }
        
        public int DoctorId { get; set; }

        [Required]
        public DayOfWeek DayOfWork { get; set; }

       
        

        [Required]
    
       // [DataType(DataType.Time)]
       // [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan StartTime { get; set; }

        [Required]
       
       // [DataType(DataType.Time)]
       // [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan EndTime { get; set; }

        [Required]
       // [Display(Name = "Per Patient Time")]
        public TimeSpan TimePerPatient { get; set; }

       
    }
}
