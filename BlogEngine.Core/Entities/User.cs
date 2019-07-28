using BlogEngine.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEngine.Core
{
    public class User  : EntityBase
    {
       
        public virtual string PhoneNumber { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string Email { get; set; }
        public virtual string UserName { get; set; }
        public virtual Guid Id { get; set; }
        public virtual string RefeshToken { get; set; }
    }
}
