using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService.Common
{
    public interface ISendMailService
    {
        public Task<bool> SendMailAsync(string email, string subject, string message);
    }
}
