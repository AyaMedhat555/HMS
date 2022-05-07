using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Responses
{
    public class LoginResponse
    {
        public string status { get; set; }
        public string UserName { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
        public string Token { get; set; } = String.Empty;
    }
}
