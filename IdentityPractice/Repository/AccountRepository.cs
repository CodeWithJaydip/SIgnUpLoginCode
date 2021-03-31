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
        private readonly UserManager<IdentityUser> _userManager;

        public AccountRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> CreateAsync(SignUpUserModel model)
        {
            var user = new IdentityUser()
            {
                Email = model.Email,
                UserName = model.Email,


            };
           var result= await _userManager.CreateAsync(user, model.Password);
            return result;
        }
    }
}
