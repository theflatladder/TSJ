using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSJCommunication.Helpers;
using TSJCommunication.Models;

namespace TSJCommunication.Controllers
{
    public class PollsController : Controller
    {
        public ActionResult Index()
        {
            if (Request.Url.AbsolutePath == "/Polls/Index" || Request.Url.AbsolutePath == "/polls")
                return RedirectPermanent("/Polls");

            DataContext context = new DataContext();

            List<Polls> polls = context.Polls.ToList();
            List<Options> options = context.Options.ToList();

            ViewBag.Polls = polls;
            ViewBag.Options = options;

            return View();
        }
        
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Polls newPoll, List<string> options)
        {
            using (DataContext context = new DataContext())
            {
                context.Polls.Add(newPoll);
                context.SaveChanges();

                foreach(var option in options)
                {
                    context.Options.Add(new Options() { PollId = newPoll.Id, Value = option });
                }
                context.SaveChanges();
            }

            return RedirectPermanent("/Polls");
        }

    }
}