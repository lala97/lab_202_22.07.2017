using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop_asp.Models;

namespace Shop_asp.Controllers
{
    public class BaseController : Controller
    {
        public SendCodeViewModel model;

        protected  ShopEntities db = new ShopEntities();

        // GET: Base
        public BaseController()
        {
          //  model = _LayoutL.Populate();
             ViewBag.LayoutModel = "scjksbc";
           
        }
    }
}