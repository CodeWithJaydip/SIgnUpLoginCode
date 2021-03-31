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

        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
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
    }
}
