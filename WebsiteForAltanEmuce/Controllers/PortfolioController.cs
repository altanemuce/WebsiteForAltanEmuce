using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteForAltanEmuce.Models.EntityFramework;
using WebsiteForAltanEmuce.Repositories;

namespace WebsiteForAltanEmuce.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio

        PortfolioRepository repository = new PortfolioRepository();
        public ActionResult Index()
        {
            var result = repository.List();
            return View(result);
        }


        [HttpGet]
        public ActionResult AddPortfolio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPortfolio(Portfolio portfolio)
        {
            repository.Add(portfolio);
            return RedirectToAction("Index");
        }

        public ActionResult DeletePortfolio(int id)
        {
            Portfolio portfolio = repository.Find(x=>x.Porfolioid==id);
            repository.Delete(portfolio);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetPortfolio(int id)
        {
            Portfolio portfolio = repository.Find(x => x.Porfolioid == id);
            return View(portfolio);
        }


        [HttpPost]
        public ActionResult GetPortfolio(Portfolio p)
        {
            Portfolio t = repository.Find(x => x.Porfolioid == p.Porfolioid);
            t.Portfoliopic = p.Portfoliopic;
            t.Portfolioname = p.Portfolioname;
            repository.Update(t);
            return RedirectToAction("Index");
        }




    }
}