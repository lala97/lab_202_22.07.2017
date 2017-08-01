using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop_asp.Models;
using System.Web.Helpers;
namespace Shop_asp.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        [HttpPost]
        public JsonResult Login(string username, string password)
        {
            var pass = Crypto.Hash(password, "MD5");
            User user = db.Users.FirstOrDefault(u => u.username == username && u.password == pass);
          
            if (user != null)
            {
                Session["user"] = true;
                var response = true;
                return Json(response, JsonRequestBehavior.AllowGet);

            }
            else
            {
                var response = false;
                return Json(response, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            Session.Clear();
            return RedirectToAction("index", "index");
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (user.username != null && user.password != null && user.email != null)
            {
                // user.password = Crypto.HashPassword(user.password);
                user.password = Crypto.Hash(user.password, "MD5");
                db.Users.Add(user);
                db.SaveChanges();
              
                return RedirectToAction("index", "index");
            }
            else
            {
                return RedirectToAction("index", "index");
            }
            //  return View();
        }

        [HttpPost]
        public JsonResult checkEmail(string email)
        {
            if (email.Length>0)
            {
                User user = db.Users.FirstOrDefault(usr => usr.email == email);
                if (user != null)
                {
                    var response = new
                    {
                        valid = false,
                        message = "This email already exists!"
                    };
                    return Json(response, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    var response = new
                    {
                        valid = true,                    
                    };
                    return Json(response, JsonRequestBehavior.AllowGet);

                }

            }
            else
            {
                var response = new
                {
                    valid = false,
                    message = "Email is required"
                };
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }
    }
}