using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteForAltanEmuce.Models.EntityFramework;
using WebsiteForAltanEmuce.Repositories;

namespace WebsiteForAltanEmuce.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        // GET: About

        GenericRepository<About> repository = new GenericRepository<About>();


        [HttpGet]
    
        public ActionResult Index()
        {
            var result = repository.List();
            return View(result);
        }

        [HttpPost]
        public ActionResult Index(About about) 
        {
            var result = repository.Find(x => x.Aboutid == 1);
            result.Abouttitle = about.Abouttitle;
            result.Abouttext = about.Abouttext;
            repository.Update(result);
            return RedirectToAction("Index");
        }
    }
}