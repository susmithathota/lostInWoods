using System;
using System.Collections.Generic;
using lostInWoods.Models;
using Microsoft.AspNetCore.Mvc;
using lostInWoods.Factory; //Need to include reference to new Factory Namespace
using System.Linq;

namespace lostInWoods.Controllers
{
    public class TrailController : Controller
    {
        private readonly TrailFactory trailFactory;
        public TrailController(TrailFactory trail)
        {
            trailFactory = trail;
        }
        //GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.TrailList = trailFactory.FindAllTrails();
            return View();
        }
        [HttpPost]
        [Route("NewTrail")]
        public IActionResult NewTrail()
        {
            return View("NewTrail");
        }
        [HttpPost]
        [Route("AddNewTrail")]
        public IActionResult AddNewTrail(Trail newTrail)
        {
            trailFactory.AddNewTrail(newTrail);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Trail/{trailId}")]
        public IActionResult GetTrailById(double trailId){
            Trail trailObj=trailFactory.GetTrailById(trailId).SingleOrDefault();
            ViewBag.Trail=trailObj;
            // ViewBag.Description=trailObj.Description;
            // ViewBag.Length=trailObj.Length;
            // ViewBag.Elevatiob=trailObj.Elevation;
            // ViewBag.Latitude=trailObj.Latitude;
            // ViewBag.Latitude=trailObj.Longitude;
            return View("ShowTrailInfo");
        }

    }
}