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
        //private int userId = 0;

        [Authorize]
        public ActionResult Index()
        {
            if (Request.Url.AbsolutePath == "/Polls/Index" || Request.Url.AbsolutePath == "/polls")
                return Redirect("/Polls");

            List<Polls> polls = null;
            using (DataContext context = new DataContext())
            {
                polls = context.Polls.ToList();
            }
            ViewBag.Polls = polls;

            return View();
        }


        #region Add

        [Authorize(Roles = "admin")]
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

            return Redirect("/Polls");
        }

        #endregion


        #region Vote

        [Authorize]
        public ActionResult Vote(int? id = null)
        {
            using (DataContext context = new DataContext())
            {
                ViewBag.Poll = context.Polls.FirstOrDefault(c => c.Id == id);
                ViewBag.Options = context.Options.Where(c => c.PollId == id).OrderBy(c => c.Id).ToList();
                ViewBag.Votes = context.Votes.Where(c => c.PollId == id).ToList();
                ViewBag.UserId = User.Identity.Name;
            }
            if (ViewBag.Poll == null || ViewBag.Options == null) Redirect("/Polls");

            return View();
        }

        [HttpPost]
        public ActionResult Vote(List<bool> results, int amountOfOptions, int pollId, FormCollection formCollection)
        {
            using (DataContext context = new DataContext())
            {
                if (context.Polls.First(c => c.Id == pollId).MultipleChoice)
                {
                    var options = context.Options.Where(c => c.PollId == pollId).OrderBy(c => c.Id).ToList();

                    for (int i = 0, optionsIndex = 0; i < results.Count; i++, optionsIndex++)
                    {
                        if (results[i] == true)
                        {
                            i++;
                            context.Votes.Add(new Votes() { PollId = pollId, UserId = User.Identity.Name, OptionId = options[optionsIndex].Id });
                        }
                    }
                }
                else
                {
                    context.Votes.Add(new Votes() { PollId = pollId, UserId = User.Identity.Name, OptionId = Convert.ToInt32(formCollection["radioResults"].ToString()) });
                }
                context.SaveChanges();
            }

            return Redirect("/Polls/Vote/" + pollId);
        }

        #endregion


        #region Delete

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            using (DataContext context = new DataContext())
            {
                var poll = context.Polls.FirstOrDefault(c => c.Id == id);
                if (poll != null) context.Polls.Remove(poll);
                context.SaveChanges();
            }

            return Redirect("/Polls");
        }

        #endregion
    }
}