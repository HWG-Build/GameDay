using System;
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
