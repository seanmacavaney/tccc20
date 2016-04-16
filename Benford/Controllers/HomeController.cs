using Benford.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Benford.Controllers
{
    public class HomeController : Controller
    {
        public IBenfordService BenfordService { get; set; }

        public HomeController(IBenfordService benfordService)
        {
            this.BenfordService = benfordService;
        }

        public ActionResult Index()
        {
            var model = this.BenfordService.Analyze();
            return View(model);
        }
    }
}