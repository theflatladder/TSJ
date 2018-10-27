using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSJCommunication.Helpers;
using TSJCommunication.Models;

namespace TSJCommunication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectPermanent("/Polls");
        }

    }
}