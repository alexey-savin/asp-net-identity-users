using System.Collections.Generic;
using System.Web.Mvc;

namespace AspNetIdentityUsers.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View(GetData("Index"));
        }

        [Authorize(Roles = "Users")]
        public ActionResult OtherAction()
        {
            return View("Index", GetData("OtherAction"));
        }

        private Dictionary<string, object> GetData(string actionName)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("Action", actionName);
            dict.Add("User", HttpContext.User.Identity.Name);
            dict.Add("Is Authenticated?", HttpContext.User.Identity.IsAuthenticated);
            dict.Add("Authentication Type", HttpContext.User.Identity.AuthenticationType);
            dict.Add("Is in Users Role?", HttpContext.User.IsInRole("Users"));

            return dict;
        }
    }
}