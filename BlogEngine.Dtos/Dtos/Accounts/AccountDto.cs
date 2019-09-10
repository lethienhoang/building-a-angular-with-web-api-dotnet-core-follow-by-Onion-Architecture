using BlogEngine.Services.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogEngine.Dtos.Dtos.Accounts
{
    public class AccountDto : BaseDto
    {
        public string PhoneNumber { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        public string RefeshToken { get; set; }
    }
}
