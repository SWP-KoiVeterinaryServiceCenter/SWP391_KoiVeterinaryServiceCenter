using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.AccountModel
{
    public class Token
    {
        public Guid userId { get; set; }
        public string userName { get; set; }
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
    }
}
