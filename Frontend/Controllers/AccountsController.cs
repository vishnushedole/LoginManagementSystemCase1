using AuthorizationLibrary;
using Frontend.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAuthenticatService _authService;
        public AccountsController(IAuthenticatService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new AuthenticationRequest();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticationRequest model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var authResponse = await _authService.Authenticate(model);
            if (authResponse == null)
            {
                ModelState.AddModelError("", "Bad Username/Password.");
                return View(model);
            }
            HttpContext.Session.SetString("Token", authResponse.Token);
            HttpContext.Session.SetString("Name", authResponse.FullName);
            HttpContext.Session.SetInt32("UserId", authResponse.UserId);

            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Name");
            HttpContext.Session.Remove("Token");
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Clear();
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
    }
}
