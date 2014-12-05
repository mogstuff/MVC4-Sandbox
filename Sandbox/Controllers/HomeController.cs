using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sandbox.DAL;
using Sandbox.Models;
using Microsoft.AspNet.SignalR;

namespace Sandbox.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "ASP.NET MVC4 Sandbox Application";
            string message = "HELLO " + DateTime.Now;
            var context = GlobalHost.ConnectionManager.GetHubContext<CustomerHub>();
            context.Clients.All.addNewMessageToPage(message);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            string message = "Home/About Method Called " + DateTime.Now;
            var context = GlobalHost.ConnectionManager.GetHubContext<CustomerHub>();
            context.Clients.All.addNewMessageToPage(message);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
