using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop_asp.Models;
namespace Shop_asp.Controllers
{
    public class IndexController : BaseController
    {
      
        // GET: Index
        public ActionResult Index()
        {
            ViewBag.Slider = db.Sliders.ToList();
            ViewBag.Product = db.Products.ToList();
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        
       
        public ActionResult Contact()
        {
            return View();
        }
    }
}