using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteForAltanEmuce.Models.EntityFramework;

namespace WebsiteForAltanEmuce.Controllers
{
    [AllowAnonymous]
    public class MainController : Controller
    {
        // GET: Main

        CreativeWebsiteForAltanEmuceEntities db = new CreativeWebsiteForAltanEmuceEntities();

        public ActionResult Index()
        {
            var result = db.About.ToList();
            return View(result);
        }
        public PartialViewResult Base()
        {
            var result = db.Main.ToList();
            return PartialView(result);
        }

        public PartialViewResult Service()
        {
            var result = db.Service.ToList();
            return PartialView(result);
        }

        public PartialViewResult Portfolio()
        {
            var result = db.Portfolio.ToList();
            return PartialView(result);
        }

        [HttpGet]
        public PartialViewResult Contact()
        {
            
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Contact(Contact contact)
        {
            db.Contact.Add(contact);
            db.SaveChanges();
            return PartialView();
        }

    }
}