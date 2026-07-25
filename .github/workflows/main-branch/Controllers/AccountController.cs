using Microsoft.AspNetCore.Mvc;

namespace RSVPApp.Controllers
{
    // STUB — this is the skeleton that lives on main.
    // The leader's branch (branch-leader-login-auth) replaces this with the
    // real static-credential login logic and merges it back via pull request.
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return Content("Login page coming soon — built on the leader's branch.");
        }
    }
}
