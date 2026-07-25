using Microsoft.AspNetCore.Mvc;
using RSVPApp.Data;
using RSVPApp.Models;

namespace RSVPApp.Controllers
{
    public class AccountController : Controller
    {

        // LOGIN PAGE
        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }



        // LOGIN SUBMIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(
            string username,
            string password,
            string? returnUrl)
        {

            if (string.IsNullOrWhiteSpace(username) ||
               string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Please enter username and password.";
                return View();
            }



            var user = StaticData.Users
                .FirstOrDefault(u =>
                    u.Username.Equals(username,
                    StringComparison.OrdinalIgnoreCase)
                    &&
                    u.Password == password
                );



            if (user == null)
            {
                ViewBag.Error = "Invalid username or password.";
                return View();
            }



            // CREATE SESSION

            HttpContext.Session.SetString(
                "Username",
                user.Username
            );


            HttpContext.Session.SetString(
                "DisplayName",
                user.DisplayName
            );



            TempData["Success"] =
                $"Welcome back, {user.DisplayName}!";



            if (!string.IsNullOrEmpty(returnUrl)
                && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }



            return RedirectToAction(
                "Index",
                "Home"
            );

        }




        // REGISTER PAGE

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }




        // REGISTER SUBMIT

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(
     string username,
     string displayName,
     string email,
     string password)
        {

            if (string.IsNullOrWhiteSpace(username) ||
               string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Username and password are required.";
                return View();
            }


            bool exists = StaticData.Users.Any(
                u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
            );


            if (exists)
            {
                ViewBag.Error = "Username already exists.";
                return View();
            }



            var newUser = new User
            {
                Username = username,
                Password = password,
                DisplayName = string.IsNullOrWhiteSpace(displayName)
                    ? username
                    : displayName,

                Email = email
            };


            StaticData.Users.Add(newUser);


            TempData["Success"] =
                "Account created! You can now sign in.";


            return RedirectToAction("Login");
        }

        





        // LOGOUT

        [HttpGet]
        public IActionResult Logout()
        {

            HttpContext.Session.Clear();


            TempData["Success"] =
            "You have been logged out.";


            return RedirectToAction(
                "Index",
                "Home"
            );

        }

    }
}