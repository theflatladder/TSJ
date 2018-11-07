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

            List<Polls> polls = null;
            using (DataContext context = new DataContext())
            {
                polls = context.Polls.ToList();
            }
            ViewBag.Polls = polls;

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

                foreach (var option in options)
                {
                    context.Options.Add(new Options() { PollId = newPoll.Id, Value = option });
                }
                context.SaveChanges();
            }

            return RedirectPermanent("/Polls");
        }




        public ActionResult Edit(int? id = null)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Polls newPoll, List<string> options)
        {
            /*
            using (DataContext context = new DataContext())
            {
                context.Polls.Add(newPoll);
                context.SaveChanges();

                foreach (var option in options)
                {
                    context.Options.Add(new Options() { PollId = newPoll.Id, Value = option });
                }
                context.SaveChanges();
            }
            */
            return RedirectPermanent("/Polls");
        }





        public ActionResult Vote(int? id = null)
        {
            using (DataContext context = new DataContext())
            {
                ViewBag.Poll = context.Polls.FirstOrDefault(c => c.Id == id);
                ViewBag.Options = context.Options.Where(c => c.PollId == id).ToList();
            }
            if (ViewBag.Poll == null || ViewBag.Options == null) RedirectPermanent("/Polls");

            return View();
        }

        [HttpPost]
        public ActionResult Vote(List<bool> results, int amountOfOptions)
        {
            //amount of false = amountOfOptions. нужно true посчитать и понять, какие это именно варианты.
            //и это только чекбоксы.

            //ебаные радиобаттоны и чекбоксы. первые не читаются, вторые через раз отдают хайден инпут, хуй распарсишь...
            return RedirectPermanent("/Polls");
        }

    }
}