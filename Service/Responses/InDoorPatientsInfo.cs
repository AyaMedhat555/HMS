using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Responses
{
    public class InDoorPatientsInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        
        public int Age { get; set; }

        public string PhoneNumber { get; set; }
        public byte[]? Image { get; set; }


    }
}







