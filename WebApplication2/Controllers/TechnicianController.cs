using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class TechnicianController : Controller
    {
        // GET: Technician
        public ActionResult Index()
        {
            var context = new TechSupportEntities();
            var technicians = context.Technicians.ToList();
            return View(technicians);
        }

        public ActionResult EditTech(int id)
        {
            var context = new TechSupportEntities();
            var tech = context.Technicians.FirstOrDefault(a => a.TechID == id);
            return View(tech);
        }
        public ActionResult CreateNewTech()
        {
            var context = new TechSupportEntities();
            var tech = context.Technicians.ToList();
            return View(tech);
        }

        public ActionResult AddNewTechToDB(Technician tecj)
        {

            var context = new TechSupportEntities();
            context.Technicians.Add(tecj);
            context.SaveChanges();
            return Redirect("Index");
        }

        public ActionResult EditT(int id, Technician technician)
        {
            var contet = new TechSupportEntities();
            var Techn = contet.Technicians.Where(p => p.TechID == id).FirstOrDefault();
            Techn.Name = technician.Name;
            Techn.Email = technician.Email;
            Techn.Phone = technician.Phone;
            contet.SaveChanges();
            return Redirect("/Technicians/Index");
        }

        public ActionResult ShowTech(int id)
        {
            var context = new TechSupportEntities();
            var tech = context.Technicians.FirstOrDefault(a => a.TechID == id);
            return View(tech);
        }
        public ActionResult DeleteTech(int id)
        {
            var context = new TechSupportEntities();
            var tech = context.Technicians.FirstOrDefault(p => p.TechID == id);
            return View(tech);
        }

        public ActionResult DeleteTechFromDB(int id, Technician tech)
        {
            var context = new TechSupportEntities();
            try
            {
                Technician techni = context.Technicians.Where(a => a.TechID == id).FirstOrDefault();
                context.SaveChanges();
                context.Technicians.Remove(techni);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return Redirect("/Technician/Index");

        }
    }
}