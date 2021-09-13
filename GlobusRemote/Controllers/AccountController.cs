using GlobusRemote.Models;
using GlobusRemote.Data.Repositories.Custom;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GlobusRemote.Controllers
{
    public class AccountController : Controller
    {
        private AccountRepository _accountRepository;

        public AccountController(
            AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IActionResult Ru()
        {
            return View();
        }

        public IActionResult En()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = _accountRepository.Get(viewModel.Login, viewModel.Password);

            if (user == null)
            {
                //ModelState.AddModelError(nameof(LoginViewModel.Login),
                //    "Не правильный логин или пароль");
                //return View(viewModel);
                return RedirectToAction("Index", "Home", new { Auth = false });
            }

            var claims = new List<Claim>();
            claims.Add(new Claim("Id", user.Fid.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.Fname));
            claims.Add(new Claim(
                ClaimTypes.AuthenticationMethod,
                Startup.AuthName));

            var claimsIdentity = new ClaimsIdentity(claims, Startup.AuthName);

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(claimsPrincipal, new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.Now.AddMinutes(10)
            });

            return RedirectToAction("Index", "Home", new { Auth = true });
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
