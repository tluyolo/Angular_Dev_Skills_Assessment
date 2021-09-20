using Angular_Dev_Skills_Assessment.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Angular_Dev_Skills_Assessment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
                return View();
        }
   
        public JsonResult GetPersons()
        {
            IEnumerable<Person> person = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/");
                //HTTP GET
                var responseTask = client.GetAsync("PersonApi");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Person>>();
                    readTask.Wait();

                    person = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    person = Enumerable.Empty<Person>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }

                return Json(person, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult InsertPerson()
        {
            IEnumerable<Person> person = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/");
                //HTTP GET
                var responseTask = client.GetAsync("PersonApi");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Person>>();
                    readTask.Wait();

                    person = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    person = Enumerable.Empty<Person>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }

                return Json(person, JsonRequestBehavior.AllowGet);

                // return Json(person);
            }
        }

        public ActionResult PersonInfo()
        {
         
            return View(new Person());
        }
        public ActionResult About()
        {
            ViewBag.Message = "Angular Dev Skills Assessment.";

            return View();
        }
		
		public ActionResult Contact()
        {
            ViewBag.Message = "Luyolo theo Ngati.";

            return View();
        }
    }
}