using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop_asp.Models;
namespace Shop_asp.Controllers
{
    public class UserController : BaseController
    {
        
        // GET: User
        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            if (username.Length>0 && password.Length>0)
            {
                User user = db.Users.FirstOrDefault(us => us.username == username || us.email == username && us.password == password);
                //if (user!=null)
                //{
                //    return RedirectToAction("index","");
                //}
            }
           
           
            return View();
        }
    }
}