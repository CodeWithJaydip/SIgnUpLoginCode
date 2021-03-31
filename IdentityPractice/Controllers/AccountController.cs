using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityPractice.Models;
using IdentityPractice.Repository;
using Microsoft.AspNetCore.Mvc;

namespace IdentityPractice.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(SignUpUserModel userModel){
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateAsync(userModel);
                if (!result.Succeeded)
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                ModelState.Clear();

            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(SignInModel model)
        {
            if (ModelState.IsValid)
            {
              var result= await _accountRepository.PasswordSignInAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Credential");
            }
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _accountRepository.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public  IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePassword model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.ChangePassword(model);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    return View();
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description); 
                }
            }
            return View(model);
        }
    }
}
