using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HouseApp.Controllers;
using HouseApp.Models;

namespace HouseApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            //Response.Redirect("DashBoard.aspx");
            return View();
        }

        /// ///////////////////////
        
        public ActionResult Menu()
        {
            ViewBag.Title = "Menu";
            return View("");
        }
        public ActionResult Control()
        {
            ViewBag.Title = "Control";
            return View("");
        }
        public ActionResult CustomizeDevice()
        {
            ViewBag.Title = "Customize Device";
            return View("");
        }
    }
}
