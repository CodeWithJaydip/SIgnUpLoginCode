using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityPractice.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace IdentityPractice.Helpers
{
    public class ApplicationUserClaimsPrincipalFactory:UserClaimsPrincipalFactory<ApplicationUser,IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager,IOptions<IdentityOptions> options):
            base(userManager,roleManager,options)
        {

        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var Identity=await  base.GenerateClaimsAsync(user);
            Identity.AddClaim(new Claim("UserFirstName", user.FirstName ?? ""));
            Identity.AddClaim(new Claim("UserLastName", user.LastName ?? ""));
            return Identity;
        }
    }
}
