using Model1.DAO;
using SA_SHOES.Common;
using SA_SHOES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SA_SHOES.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {

            ViewBag.Slide = new SlideDao().ListAll();
            var productDao = new ProductDao();
            ViewBag.NewProducts = productDao.ListNewProduct(3);
            ViewBag.ListFeatureProducts = productDao.ListFeatureProduct(3);
            ViewBag.ListCategory = new ProductCategoryDao().ListAll1(3);
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
        
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupID(1);
            return PartialView(model);
        }

        [ChildActionOnly]
        public  PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConStants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            
            return PartialView(list);
        }


    }
}