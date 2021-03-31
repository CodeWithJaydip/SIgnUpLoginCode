using System.Threading.Tasks;
using IdentityPractice.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityPractice.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateAsync(SignUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInModel model);
    }
}