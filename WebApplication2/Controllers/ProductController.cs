using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var context = new TechSupportEntities();
            var product = context.Products.ToList();
            return View(product);
        }

        public ActionResult EditProduct(string code)
        {
            var context = new TechSupportEntities();
            var product = context.Products.FirstOrDefault(a => a.ProductCode == code);
            return View(product);
        }

        public ActionResult CreateNewProduct()
        {
            return View();
        }

        public ActionResult AddNewProductToDB(Product product)
        {
            var context = new TechSupportEntities();
            context.Products.Add(product);
            context.SaveChanges();
            return Redirect("Index");
        }

        public ActionResult edtPrduct(string code, Product product)
        {
            var context = new TechSupportEntities();
            var prod = context.Products.Where(x => x.ProductCode == code).FirstOrDefault();
            prod.Name = product.Name;
            prod.Version = product.Version;
            prod.ReleaseDate = product.ReleaseDate;
            context.SaveChanges();
            return Redirect("/Index");
        }

        public ActionResult ShowProduct(string code)
        {
            var context = new TechSupportEntities();
            var product = context.Products.FirstOrDefault(a => a.ProductCode == code);
            return View(product);
        }
        public ActionResult DeleteProduct(string code)
        {
            var context = new TechSupportEntities();
            Product pro = context.Products.FirstOrDefault(z => z.ProductCode == code);
            return View(pro);
        }
        public ActionResult DeleteFromPro(string code)
        {
            var context = new TechSupportEntities();
            try
            {
                IEnumerable<Registration> r = context.Registrations.Where(a => a.ProductCode == code);
                foreach (Registration registration in r)
                {
                    context.Registrations.Remove(registration);
                }

                Product p = context.Products.Where(a => a.ProductCode == code).FirstOrDefault();
                context.SaveChanges();
                context.Products.Remove(p);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return Redirect("/Product/Index");

            //return View("Index");
        }

    }
}