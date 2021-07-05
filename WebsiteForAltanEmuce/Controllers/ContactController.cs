using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteForAltanEmuce.Models.EntityFramework;
using WebsiteForAltanEmuce.Repositories;

namespace WebsiteForAltanEmuce.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        GenericRepository<Contact> repository = new GenericRepository<Contact>();
        public ActionResult Index()
        {
            var result = repository.List();
            return View(result);
        }
    }
}