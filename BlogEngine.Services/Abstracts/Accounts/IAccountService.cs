using BlogEngine.Dtos.Dtos.Accounts;
using BlogEngine.Services.Dtos.Posts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Services.Abstracts.Accounts
{
    public interface IAccountService
    {
        Task<AccountInforDto> SignUpAsync(AccountDto model);
        Task<AccountInforDto> ChangePasswordAsync(Guid id, string password);
        Task<AccountInforDto> UpdateAsync(AccountDto model);

        Task<AccountInforDto> GetByConditionAsync(AccountDto condition);
        Task<AccountInforDto> GetByIdAsync(Guid id);
        Task<bool> CheckUserExistAsync(string email);
        Task<AccountInforDto> GetUserAsync(string email);
        Task<bool> SaveRefeshTokenAsync(Guid id, string refreshToken);
    }
}
