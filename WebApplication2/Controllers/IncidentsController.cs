using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class IncidentsController : Controller
    {
        // GET: Incidents
        public ActionResult Index()
        {
            var context = new TechSupportEntities();
            var inc = context.Incidents.ToList();
            return View(inc);
        }
        public ActionResult CreateNewIncident()
        {
            var context = new TechSupportEntities();
            var Customers = context.Customers
                                .ToList();
            ViewData["Customers"] = new SelectList(Customers, "CustomerID", "Name");

            var products = context.Products.ToList();
            ViewData["Products"] = new SelectList(products, "ProductCode", "Name");

            var technicians = context.Technicians.ToList();
            ViewData["Technicians"] = new SelectList(technicians, "TechID", "Name");

            return View();
        }

        public ActionResult AddNewToDB(Incident incident)
        {
            var context = new TechSupportEntities();
            context.Incidents.Add(incident);
            context.SaveChanges();
            return Redirect("/Incidents/Index");
        }

        public ActionResult EditIncident(int id)
        {
            var context = new TechSupportEntities();
            var incident = context.Incidents.FirstOrDefault(x => x.IncidentID == id);
            var Customers = context.Customers
                                .ToList();
            ViewData["Customers"] = new SelectList(Customers, "CustomerID", "Name");

            var products = context.Products.ToList();
            ViewData["Products"] = new SelectList(products, "ProductCode", "Name");

            var technicians = context.Technicians.ToList();
            ViewData["Technicians"] = new SelectList(technicians, "TechID", "Name");

            return View(incident);
        }

        public ActionResult edtIncident(int id, Incident newIncident)
        {
            var context = new TechSupportEntities();
            var incident = context.Incidents.Where(x => x.IncidentID == id).FirstOrDefault();
            incident.ProductCode = newIncident.ProductCode;
            incident.TechID = newIncident.TechID;
            incident.DateClosed = newIncident.DateClosed;
            incident.DateOpened = newIncident.DateOpened;
            incident.Title = newIncident.Title;
            incident.Description = newIncident.Description;
            context.SaveChanges();
            return Redirect("Incidents/Index");
        }

        public ActionResult ShowIncident(int id)
        {
            var context = new TechSupportEntities();
            var incident = context.Incidents.FirstOrDefault(x => x.IncidentID == id);
            return View(incident);
        }

        public ActionResult DeleteIncident(int id)
        {
            var context = new TechSupportEntities();
            Incident Incident = context.Incidents.FirstOrDefault(x => x.IncidentID == id);
            return View(Incident);
        }

        public ActionResult DeleteFromDB(int id)
        {
            var context = new TechSupportEntities();
            try
            {
                Incident Incident = context.Incidents.Where(a => a.IncidentID == id).FirstOrDefault();
                context.SaveChanges();
                context.Incidents.Remove(Incident);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return Redirect("/Incidents/Index");

            //return View("Index");
        }
    }
}