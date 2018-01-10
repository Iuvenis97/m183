using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            var username = Request["username"];
            var passwort = Request["passwort"];
            var stay_logged_in = Request["stay_logged_in"];

            if(username == "test" && passwort == "test")
            {
                if(stay_logged_in == "on")
                {
                    var auth_cookie = new HttpCookie("misleading_name_for_an_authentication_cookie");
                    auth_cookie.Value = "SOME_NICE_VALUE";
                    auth_cookie.Expires = DateTime.Now.AddDays(1);
                    auth_cookie.Path = "localhost:51192";

                    Response.Cookies.Add(auth_cookie);
                }
                else
                {
                    Session["misleading_name_for_an_authentication_cookie"] = "SOME_NICE_VALUE";
                }
                Response.Redirect("Admin/Home");
            }
            else
            {
                ViewBag.content = "Failed to login";
            }

            return View();
        }
    }
}