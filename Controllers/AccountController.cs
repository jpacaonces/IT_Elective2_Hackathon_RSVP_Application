using Microsoft.AspNetCore.Mvc;
using RSVPApp.Data;

namespace RSVPApp.Controllers
{
    // LEADER'S BRANCH: feature/login-auth
    // Replaces the stub AccountController from main with real logic that
    // checks the submitted username/password against the static Users list.
    public class AccountController : Controller
    {
        private const string SessionUserKey = "LoggedInUser";

        [HttpGet]
        public IActionResult Login()
        {
            // Already signed in? Skip straight to the events page.
            if (HttpContext.Session.GetString(SessionUserKey) != null)
            {
                return RedirectToAction("Index", "Event");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {
            var matchedUser = StaticData.Users.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);

            if (matchedUser is null)
            {
                ViewBag.Error = "Incorrect username or password. Please try again.";
                return View();
            }

            // Static-credential "session": store the display name in session state.
            HttpContext.Session.SetString(SessionUserKey, matchedUser.DisplayName);

            return RedirectToAction("Index", "Event");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove(SessionUserKey);
            return RedirectToAction("Index", "Home");
        }
    }
}
