using AutoMapper;
using BlogEngine.Core;
using BlogEngine.Dtos.Dtos.Accounts;
using BlogEngine.Http.Utilities.Hashs;
using BlogEngine.Infrastructure.Data.Infrastructure;
using BlogEngine.Services.Abstracts.Accounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly GenericUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        public AccountService(GenericUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<AccountInforDto> ChangePasswordAsync(Guid id, string password)
        {
            var user = await _unitOfWork.UserRepository.FindByIdAsync(id);

            if (user != null)
            {
                return null;
            }



            // Keep old password
            user.PasswordHash = _passwordHasher.GenerateIdentityV3Hash(password);
            // Hash password
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return new AccountInforDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };
        }

        public async Task<bool> CheckUserExistAsync(string email)
        {
            var user = await _unitOfWork.UserRepository.AnyAsync(x => x.Email.Equals(email));


            return user;
        }



        public Task<AccountInforDto> GetByConditionAsync(AccountDto condition)
        {
            throw new NotImplementedException();
        }

        public Task<AccountInforDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountInforDto> GetUserAsync(string email)
        {
            var user = await _unitOfWork.UserRepository.GetSingleAsync(x => x.Email.Equals(email));

            return _mapper.Map<User, AccountInforDto>(user);
        }

        public async Task<bool> SaveRefeshTokenAsync(Guid id, string refreshToken)
        {
            var user = await _unitOfWork.UserRepository.GetSingleAsync(x => x.Id == id);

            if (user == null)
            {
                return false;
            }

            user.RefeshToken = refreshToken;
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<AccountInforDto> SignUpAsync(AccountDto model)
        {
            var user = await _unitOfWork.UserRepository.GetSingleAsync(x => x.UserName.Equals(model.UserName));

            if (user != null)
            {
                return null;
            }

            var entity = _mapper.Map<AccountDto, User>(model);

            // Hash password
            entity.Id = Guid.NewGuid();
            entity.PasswordHash = _passwordHasher.GenerateIdentityV3Hash(entity.PasswordHash);
            _unitOfWork.UserRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync();

            return new AccountInforDto
            {
                Id = entity.Id,
                UserName = entity.UserName,
                Email = entity.Email
            };
        }

        public async Task<AccountInforDto> UpdateAsync(AccountDto model)
        {
            var user = await _unitOfWork.UserRepository.FindByIdAsync(model.Id);

            if (user != null)
            {
                return null;
            }

            var entity = _mapper.Map<AccountDto, User>(model);

            // Keep old password
            entity.PasswordHash = user.PasswordHash;
            // Hash password
            _unitOfWork.UserRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return new AccountInforDto
            {
                Id = entity.Id,
                UserName = entity.UserName,
                Email = entity.Email
            };
        }
    }

       
    }
