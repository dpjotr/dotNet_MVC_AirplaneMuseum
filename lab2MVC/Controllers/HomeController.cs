using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab2MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.EventLog;

namespace lab2MVC.Controllers
{
    public class HomeController : Controller
    {
        AirplaneRepo repo;
        public HomeController(AirplaneRepo _repo) { repo=_repo;}


        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            List<Airplane> airplanes = repo.airplanes;
            return View(airplanes);
        }

       
        public ActionResult GetByPlane(string model)
        { 
                Airplane airplane = new Airplane();
                foreach (var x in repo.airplanes)
                {
                    if (x.Model == model) airplane = x;
                }
                return View(airplane);
        }

       
        [HttpGet]
        public ActionResult LookForPlane()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult LookForPlane(string model)
        {
            bool isInList=false;
            foreach (var x in repo.airplanes)
            {
                if (x.Model == model) 
                {
                    isInList=true;
                    break;
                }
            }
            if (isInList) return RedirectToAction("GetByPlane",new {model=model}) ;
            else return View();

        }


        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(String link, String country, String manufacturer, String model, int year, String usage, bool isRetired)
        {
            Usage u = Usage.UNKNOWN;
            switch (usage)
            {
                case "Military": u = Usage.MILITARY; break;
                case "Transport": u = Usage.TRANSPORT; break;
                case "Passenger": u = Usage.PASSENGER; break;
            }
            repo.airplanes.Add(new Airplane(country, manufacturer, model, u, isRetired, year, link));

            return RedirectToAction("ServiceMessage", new { message = "New airplane was added" });
        }
        [HttpGet]
        public ActionResult Delete(String country, String manufacturer, String model)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete( String model)
        {
            bool isInList = false;
            foreach (var x in repo.airplanes)
            {
                if (x.Model == model)
                {
                    repo.airplanes.Remove(x);
                    return RedirectToAction("ServiceMessage", new { message = "Airplane was deleted" });
                }
            }

            return RedirectToAction("ServiceMessage", new { message = "There is no such airplane in the database" });
        }
        public ActionResult Statistics()
        {
            String statistics ="";

            statistics = $"Total amount of airplanes in the data base:{repo.airplanes.Count}\n";
            ViewData["Total"] = statistics;
            statistics = $"    Amount of military airplanes in the data base:{repo.airplanes.Where(x=>x.Usage==Usage.MILITARY).Count()}";
            ViewData["Military"] = statistics;
            statistics = $"    Amount of transport airplanes in the data base:{repo.airplanes.Where(x => x.Usage == Usage.TRANSPORT).Count()}";
            ViewData["Transport"] = statistics;
            statistics = $"    Amount of pessanger airplanes in the data base:{repo.airplanes.Where(x => x.Usage == Usage.PASSENGER).Count()}";
            ViewData["Pessanger"] = statistics;
            statistics = $"    Amount of unknown type airplanes in the data base:{repo.airplanes.Where(x => x.Usage == Usage.UNKNOWN).Count()}";
            ViewData["Unknown"] = statistics;


            return View();
        }
        public ActionResult ServiceMessage(String message)
        {
            @ViewData["Message"] = message;
            return View();
        }
    }
}
