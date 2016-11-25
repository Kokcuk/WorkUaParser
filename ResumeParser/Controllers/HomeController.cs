using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeParser.Common;
using ResumeParser.Models;
using ResumeParser.WorkUa;

namespace ResumeParser.Controllers
{
    public class HomeController : Controller
    {
        private WorkUaParser workUaParser;

        public HomeController()
        {
            this.workUaParser = new WorkUaParser(new HttpHandler());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult ParseResume()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ParseResume(ParseResumeModel model)
        {
            var resume = this.workUaParser.Parse(model.Url);
            return View("_ResumeView", resume);
        }
    }
}