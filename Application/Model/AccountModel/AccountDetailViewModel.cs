using Application.Model.KoiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.AccountModel
{
    public  class AccountDetailViewModel
    {
        public string Email { get; set; }
        public string Location { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public KoiOwner OwnedKoi { get; set; }
    }
}
