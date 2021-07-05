using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteForAltanEmuce.Models.EntityFramework;
using WebsiteForAltanEmuce.Repositories;

namespace WebsiteForAltanEmuce.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        GenericRepository<Service> repository = new GenericRepository<Service>();

        public ActionResult Index()
        {
            var result = repository.List();
            return View(result);
        }


        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddService(Service service)
        {
            repository.Add(service);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteService(int id)
        {
            var result = repository.Find(x=>x.Serviceid==id);
            repository.Delete(result);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetService(int id)
        {
            var result = repository.Find(x=>x.Serviceid==id);
            return View(result);
        }

        [HttpPost]
        public ActionResult GetService(Service service)
        {
            var result = repository.Find(x=>x.Serviceid==service.Serviceid);
            result.Servicesubtitle = service.Servicesubtitle;
            result.Servicetext = service.Servicetext;
            repository.Update(result);
            return RedirectToAction("Index");
        }


    }
}