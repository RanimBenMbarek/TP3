using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;



namespace WebApplication2.Controllers
{
    public class PersonController : Controller
    {
        [Route("Person/{id}")]
        public ActionResult Index(int id=0)
        {
            Personal_info personne = Personal_info.getInstance();
            //Personal_info personne=new Personal_info();
            return View(personne.GetPerson(id));
        }
        [HttpGet]
        [Route("Person/all")]
        public ActionResult all()
        {
            Personal_info p = Personal_info.getInstance();
           //Personal_info p=new Personal_info();
            return View(p.GetAllPerson());
        }
        
        
        [HttpGet]
        [Route("Person/search")]
        public ViewResult search()
        {
            return View();
        }
       
        [HttpPost]
        [Route("Person/search")]
        public RedirectToRouteResult search(string firstname,string country)
        {
            Personal_info p = Personal_info.getInstance();
            List<Person> liste = p.GetAllPerson();
            foreach (Person person in liste)
            {
                if (person.firstName == firstname && person.country == country)
                {
                    return RedirectToAction("Index", new { id = person.id });

                }
            }
            return RedirectToAction("Index", new { id=0});


        }

        
    }
}
