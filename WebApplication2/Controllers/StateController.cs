using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class StateController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            var context = new TechSupportEntities();
            var state = context.States.ToList();
            return View(state);
        }

        public ActionResult EditState(string id)
        {
            var context = new TechSupportEntities();
            var state = context.States.FirstOrDefault(p=>p.StateCode == id);
            return View(state);
        }
        public ActionResult ShowState(string id)
        {
            var context = new TechSupportEntities();
            var state = context.States.FirstOrDefault(p => p.StateCode == id);
            return View(state);
        }
        public ActionResult CreateNewState()
        {
            var context = new TechSupportEntities();
            return View();
        }

        public ActionResult AddNewStateToDB(State st)
        {

            var context = new TechSupportEntities();
            context.States.Add(st);
            context.SaveChanges();
            return Redirect("Index");
        }
        public ActionResult EditDb(string id, State state)
        {
           
            var context = new TechSupportEntities();
            var st = context.States.Where(p => p.StateCode == id).FirstOrDefault();
            st.StateName = state.StateName;
            st.FirstZipCode = state.FirstZipCode;
            st.LastZipCode = state.LastZipCode;
            context.SaveChanges();
            return Redirect("Index");
        }
        public ActionResult DeleteState(string id)
        {
            var context = new TechSupportEntities();
            var state = context.States.FirstOrDefault(p => p.StateCode == id);
            return View(state);
        }

        public ActionResult DeleteStateFromDB(string id, State state)
        {
            var context = new TechSupportEntities();
            try
            { 
                State cust = context.States.Where(a => a.StateCode == id).FirstOrDefault();
                context.SaveChanges();
                context.States.Remove(cust);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return Redirect("/State/Index");
        }



    }
}