using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _Michael_Tinnin.Models;

namespace _Michael_Tinnin.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            MailViewModel model = new MailViewModel();
            return View(model);
        }

        

        [HttpPost]
        public ActionResult Index(MailViewModel model)
        {
           
            return View(model);
        }
        
    }
}