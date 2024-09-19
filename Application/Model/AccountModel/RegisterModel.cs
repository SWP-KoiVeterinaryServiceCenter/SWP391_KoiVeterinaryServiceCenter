using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.AccountModel
{
    public class RegisterModel
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public string ContactLink { get; set; }
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone number.")]
        public string Phonenumber { get; set; }
    }
}
