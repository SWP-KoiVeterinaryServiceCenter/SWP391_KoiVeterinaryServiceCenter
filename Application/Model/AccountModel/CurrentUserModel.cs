﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.AccountModel
{
    public class CurrentUserModel
    {
        public Guid AccountId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string ContactLink { get; set; }
        public string Fullname { get; set; }
        public string Phonenumber { get; set; }
        public string ProfileImage { get; set; }
    }
}
