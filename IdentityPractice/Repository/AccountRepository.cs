using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityPractice.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityPractice.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountRepository(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
    }
}
