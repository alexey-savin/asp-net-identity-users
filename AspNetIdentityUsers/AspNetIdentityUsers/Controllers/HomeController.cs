using System.Collections.Generic;
using System.Web.Mvc;

namespace AspNetIdentityUsers.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Key", "Value");

            return View(data);
        }
    }
}