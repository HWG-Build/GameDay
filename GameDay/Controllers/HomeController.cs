using System.Web.Mvc;

namespace GameDay.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        //    protected override void OnException(ExceptionContext filterContext)
        //    {
        //        //Return if Exception is handled
        //        if (filterContext.ExceptionHandled)
        //            return;

        //        if (filterContext.Exception is NullReferenceException)
        //        {
        //            filterContext.Result = new ViewResult
        //            {
        //                //ViewName = "~/Views/Shared/Error.cshtml"
        //                ViewName = "~/Views/Shared/CustomError.cshtml"
        //            };
        //        }

        //        if (filterContext.Exception is CustomException)
        //        {
        //            //DO SOMETHING
        //        }

        //        filterContext.ExceptionHandled = true;
        //    }
        //}

        //internal class CustomException
        //{
        //}
    }
}
