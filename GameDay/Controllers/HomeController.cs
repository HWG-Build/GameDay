using System.Dynamic;
using System.Web.Mvc;
using Domain.Layer.DataAccessLayer;
using Domain.Layer.Models;
using GameDay.Services.Interfaces;

namespace GameDay.Controllers
{
    public class HomeController : Controller
    {
        GameDayContext db = new GameDayContext();

        private readonly IDependency dependency;
        public HomeController(IDependency dependency)
        {
            this.dependency = dependency;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
