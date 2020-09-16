using CobaltElectronics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CobaltElectronics.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? id)
        {
            var model = db.Proizvods.ToArray();
            if (id != null)
            {
                model = db.Categories.Find(id).proizvodi.ToArray();
                ViewBag.Table = db.Categories.Find(id).Name;
            }

            return View(model);
        }

        public ActionResult addToCart(int Id)
        {
  
            Dictionary<int, int> id_quantity=null;
            var model = db.Proizvods.Find(Id);
            if (Session["shoppingCart"] == null)
            {
                if (model != null && model.DaliNaZaliha==true)
                {

                    id_quantity = new Dictionary<int, int>();


                    id_quantity.Add(Id, 1);
                    Session["shoppingCart"] = id_quantity;
                }
            }
            else {
                if (model != null && model.DaliNaZaliha == true)
                {
                    id_quantity = Session["shoppingCart"] as Dictionary<int, int>;
                    if (id_quantity.ContainsKey(Id))
                    {
                        id_quantity[Id] += 1;
                    }
                    else
                    {
                        id_quantity.Add(Id, 1);
                    }
                    Session["shoppingCart"] = id_quantity;
                }
            }

            return RedirectToAction("Index");
        }
        public ActionResult shoppingCart() {

            Dictionary<int, int> id_quantity = Session["shoppingCart"] as Dictionary<int,int>;
            if (id_quantity != null)
            {
                List<Proizvod> proizvodi = new List<Proizvod>();
                foreach (int a in id_quantity.Keys)
                {
                    proizvodi.Add(db.Proizvods.Find(a));
                }

                return View(proizvodi);
            }
            else {
                return View();
            }
        }
        public ActionResult removeFromCart(int Id)
        {

            Dictionary<int, int> id_quantity = Session["shoppingCart"] as Dictionary<int, int>;
            if (id_quantity.ContainsKey(Id)) {
                id_quantity.Remove(Id);
            }
            return RedirectToAction("shoppingCart");
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
    }
}