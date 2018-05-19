using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter username!")]
        [DataType(DataType.Text)]
        [MinLength(1)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
