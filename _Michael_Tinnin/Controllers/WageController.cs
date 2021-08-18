using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _Michael_Tinnin.Models;

namespace _Michael_Tinnin.Controllers
{
    public class WageController : Controller
    {
        // GET: Wage
        public ActionResult Index()
        {
            WageViewModel model = new WageViewModel();
            return View(model);
            
        }
        [HttpPost]
        public ActionResult Index(WageViewModel model)
        {
            return View(model);
        }
    }
}