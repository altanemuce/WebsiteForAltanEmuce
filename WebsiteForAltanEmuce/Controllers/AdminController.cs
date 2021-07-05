using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteForAltanEmuce.Models.EntityFramework;
using WebsiteForAltanEmuce.Repositories;

namespace WebsiteForAltanEmuce.Controllers
{

    
    public class AdminController : Controller
    {
        // GET: Admin

        GenericRepository<Admin> repository = new GenericRepository<Admin>();
        public ActionResult Index()
        {
            var result = repository.List();
            return View(result);

        }


        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            repository.Add(admin);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            Admin admin = repository.Find(x => x.Adminid == id);
            repository.Delete(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetAdmin(int id)
        {
            Admin admin = repository.Find(x => x.Adminid == id);
            return View(admin);
        }


        [HttpPost]
        public ActionResult GetAdmin(Admin admin)
        {
            Admin t = repository.Find(x => x.Adminid == admin.Adminid);
            t.Adminname = admin.Adminname;
            t.Adminpassword = admin.Adminpassword;
            repository.Update(t);
            return RedirectToAction("Index");
        }

    }
}