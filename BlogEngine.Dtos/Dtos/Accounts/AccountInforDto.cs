using BlogEngine.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEngine.Dtos.Dtos.Accounts
{
    public class AccountInforDto : BaseDto
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public string PasswordHash { get; set; }
        public string RefreshToken { get; set; }
    }
}
