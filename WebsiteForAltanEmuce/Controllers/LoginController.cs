using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebsiteForAltanEmuce.Models.EntityFramework;

namespace WebsiteForAltanEmuce.Controllers
{
   [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            CreativeWebsiteForAltanEmuceEntities db = new CreativeWebsiteForAltanEmuceEntities();
            var result = db.Admin.FirstOrDefault(x=>x.Adminname==admin.Adminname && x.Adminpassword==admin.Adminpassword);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(result.Adminname, false);
                Session["Adminname"] = result.Adminname.ToString();
                return RedirectToAction("Index", "Portfolio");
            }
            else 
            {
                return RedirectToAction("Index","Login");
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}