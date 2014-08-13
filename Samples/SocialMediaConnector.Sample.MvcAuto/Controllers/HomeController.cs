using System.Web.Mvc;
using SocialMediaConnector.MvcAuto.Models;
using SocialMediaConnector.Core;

namespace SocialMediaConnector.MvcAuto.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index", new IndexViewModel());
        }
    }
}