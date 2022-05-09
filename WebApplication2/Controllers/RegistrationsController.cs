using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class RegistrationsController : Controller
    {
        // GET: Registrations
        public ActionResult Index()
        {
            var context = new TechSupportEntities();
            var reg = context.Registrations.ToList();
            return View(reg);
        }
        public ActionResult EditRegistrations(int id)
        {
            var context = new TechSupportEntities();
            var regi = context.Registrations.FirstOrDefault(p => p.CustomerID == id);
            var Customers = context.Customers.ToList();
            ViewData["Customers"] = new SelectList(Customers, "CustomerID", "Name");

            var products = context.Products.ToList();
            ViewData["Products"] = new SelectList(products, "ProductCode", "Name");
            return View(regi);
        }

        public ActionResult EditRegToDB(int id, Registration registration)
        {
            var context = new TechSupportEntities();
            var incident = context.Registrations.Where(x => x.CustomerID == id).FirstOrDefault();
            //incident.CustomerID = registration.CustomerID;
            //incident.ProductCode = registration.ProductCode;
            incident.RegistrationDate = registration.RegistrationDate;
            context.SaveChanges();
            return Redirect("Index");
        }

        public ActionResult ShowRegDetails(int id, Registration registration)
        {
            var context = new TechSupportEntities();
            var regi = context.Registrations.FirstOrDefault(p => p.CustomerID == id);
            var Customers = context.Customers.ToList();
            ViewData["Customers"] = new SelectList(Customers, "CustomerID", "Name");

            var products = context.Products.ToList();
            ViewData["Products"] = new SelectList(products, "ProductCode", "Name");
            return View(regi);
        }

        public ActionResult DeleteRegistrations(int id, Registration registration)
        {
            var context = new TechSupportEntities();
            Registration reg = context.Registrations.FirstOrDefault(x => x.CustomerID == id);
            return View(reg);
        }

        public ActionResult DeleteRegFromDB(int id, Registration registration)
        {
            var context = new TechSupportEntities();
            try
            {
                Registration reg = context.Registrations.Where(a => a.CustomerID == id).FirstOrDefault();
                context.SaveChanges();
                context.Registrations.Remove(reg);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return Redirect("/Registrations/Index");
        }

        public ActionResult CreateNewReg()
        {
            var context = new TechSupportEntities();
            var Customers = context.Customers
                                .ToList();
            ViewData["Customers"] = new SelectList(Customers, "CustomerID", "Name");

            var products = context.Products.ToList();
            ViewData["Products"] = new SelectList(products, "ProductCode", "Name");
            return View();
        }
        public ActionResult AddNewRegToDB(Registration reg)
        {
            reg.RegistrationDate = DateTime.Now;
            var context = new TechSupportEntities();
            context.Registrations.Add(reg);
            context.SaveChanges();
            return Redirect("Index");
        }
    }
}