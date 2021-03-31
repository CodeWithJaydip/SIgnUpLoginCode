using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityPractice.Models;
using IdentityPractice.Services;
using Microsoft.AspNetCore.Identity;

namespace IdentityPractice.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _service;

        public AccountRepository(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,IUserService service)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _service = service;
        }
        public async Task<IdentityResult> CreateAsync(SignUpUserModel model)
        {
            var user = new ApplicationUser()
            {
                Email = model.Email,
                FirstName=model.FirstName,
                LastName=model.LastName,
                UserName = model.Email,
                BirthDate=model.BirthDate
               


            };
           var result= await _userManager.CreateAsync(user, model.Password);
            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(SignInModel model)
        {
           var result= await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            return result;
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<IdentityResult> ChangePassword(ChangePassword model)
        {
            var UserId = _service.GetUserId();
            var user = await _userManager.FindByIdAsync(UserId);
          return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        }
    }
}
