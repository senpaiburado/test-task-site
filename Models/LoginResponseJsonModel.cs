using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Models
{
    public class LoginResponseJsonModel
    {
        public int EntityId { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string EmailConfirm { get; set; }
        public string MobileConfirm { get; set; }
        public string ContryID { get; set; }
        public int Status { get; set; }
        public string lid { get; set; }
        public string FTPHost { get; set; }
        public int FTPPort { get; set; }

        // If there are errors
        public int ResultCode { get; set; } = 0;
        public string ResultMessage { get; set; } = "";
    }
}
