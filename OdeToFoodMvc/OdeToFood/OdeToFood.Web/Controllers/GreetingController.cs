using OdeToFood.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index(string name)
        {
            var model = new GreetingViewModel();

            //var name = HttpContext.Request.QueryString["name"];
            //We do not need to use the http request querystring since in MVC we can have the value passed in the method like so:
            //public ActionResult Index(string name)
            model.Name = name ?? "no name";
            model.Message = ConfigurationManager.AppSettings["message"];
            
            return View(model);
        }
    }
}