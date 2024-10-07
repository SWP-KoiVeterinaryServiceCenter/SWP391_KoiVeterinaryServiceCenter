using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.AccountModel
{
    public class ResetPasswordModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
