using System.Dynamic;
using System.Web.Mvc;
using Domain.Layer.DataAccessLayer;
using Domain.Layer.Models;
using GameDay.Services.Interfaces;

namespace GameDay.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}
