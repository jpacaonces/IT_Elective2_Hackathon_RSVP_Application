using Microsoft.AspNetCore.Mvc;
using RSVPApp.Data;
using RSVPApp.Models;

namespace RSVPApp.Controllers
{
    public class AccountController : Controller
    {
        // ==========================================
        // LOGIN PAGE
        // ==========================================
        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // ==========================================
        // LOGIN SUBMIT
        // ==========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(
            string email,
            string password,
            bool rememberMe = false,
            string? returnUrl = null)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Please enter both email and password.";
                return View();
            }

            // Matches against Email OR Username in your static/DB user store
            var user = StaticData.Users.FirstOrDefault(u =>
                (u.Email?.Equals(email, StringComparison.OrdinalIgnoreCase) == true ||
                 u.Username.Equals(email, StringComparison.OrdinalIgnoreCase)) &&
                u.Password == password
            );

            if (user == null)
            {
                ViewBag.Error = "Invalid email address or password.";
                return View();
            }

            // CREATE SESSION
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("DisplayName", user.DisplayName ?? user.Username);

            TempData["Success"] = $"Welcome back, {user.DisplayName ?? user.Username}!";

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        // ==========================================
        // REGISTER PAGE
        // ==========================================
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // ==========================================
        // REGISTER SUBMIT
        // ==========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(
            string fullName,
            string email,
            string password,
            string confirmPassword,
            bool agreeToTerms = false)
        {
            // 1. Check for required fields
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Email and password are required.";
                return View();
            }

            // 2. Check password match
            if (password != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match.";
                return View();
            }

            // 3. Check if user already exists (by Email or Username)
            bool exists = StaticData.Users.Any(u =>
                u.Email?.Equals(email, StringComparison.OrdinalIgnoreCase) == true ||
                u.Username.Equals(email, StringComparison.OrdinalIgnoreCase)
            );

            if (exists)
            {
                ViewBag.Error = "An account with this email already exists.";
                return View();
            }

            // Derive a fallback username from the email address before the '@'
            string derivedUsername = email.Split('@')[0];

            // 4. Create and store new user
            var newUser = new User
            {
                Username = derivedUsername,
                DisplayName = string.IsNullOrWhiteSpace(fullName) ? derivedUsername : fullName,
                Email = email,
                Password = password
            };

            StaticData.Users.Add(newUser);

            TempData["Success"] = "Account created successfully! You can now sign in.";
            return RedirectToAction("Login");
        }

        // ==========================================
        // LOGOUT
        // ==========================================
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Success"] = "You have been logged out.";

            return RedirectToAction("Index", "Home");
        }
    }
}