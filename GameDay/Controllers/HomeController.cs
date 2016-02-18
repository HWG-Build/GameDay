using System.Web.Mvc;
using GameDay.Services.Interfaces;

namespace GameDay.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDependency dependency;
        public HomeController(IDependency dependency)
        {
            this.dependency = dependency;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}