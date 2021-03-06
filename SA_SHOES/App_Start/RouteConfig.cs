using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SA_SHOES
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*botdetect}",
             new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "Product Category",
                url: "san-pham/{metatitle}-{id}",
                defaults: new { controller = "Product", action = "Categoty", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product",
                url: "san-pham",
                defaults: new { controller = "Product", action = "ListProduct", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product Detail",
                url: "chi-tiet/{metatitle}-{prid}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "About",
                url: "gioi-thieu",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Contact",
                url: "lien-he",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Cart",
                url: "gio-hang",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Payment",
                url: "thanh-toan",
                defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login",
                url: "dang-nhap",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Resgister",
                url: "dang-ky",
                defaults: new { controller = "User", action = "Resgister", id = UrlParameter.Optional }
            );



            routes.MapRoute(
                name: "Add Cart",
                url: "them-gio-hang",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Payment Success",
                url: "hoan-thanh",
                defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Home",
                url: "trang-chu",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
