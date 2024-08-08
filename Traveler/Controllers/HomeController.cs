//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Traveler.Models;

//namespace Traveler.Controllers
//{
//    public class HomeController : Controller
//    {
//        TravelBookingEntities1 db = new TravelBookingEntities1();
//        public ActionResult Index()
//        {
//            ViewBag.TourGuidesList = db.TourGuides.ToList();
//            List<Tour> toursList = db.Tours.ToList();
//            toursList.Reverse();
//            ViewBag.ToursList = toursList;
//            ViewBag.DestinationLst = db.Destinations.ToList();
//            ViewBag.DepartureLocationLst = db.DepartureLocations.ToList();

//            return View();
//        }

//        public ActionResult About()
//        {
//            ViewBag.Message = "Your application description page.";

//            return View();
//        }

//        public ActionResult Services()
//        {
//            ViewBag.Message = "Your contact page.";

//            return View();
//        }
//    }
//}
using System.Web.Mvc;
using Traveler.Design_pattern.Facade_pattern;
using Traveler.Facades;

namespace Traveler.Controllers
{
    public class HomeController : Controller
    {
        private TravelFacade _travelFacade = new TravelFacade();

        public ActionResult Index()
        {
            ViewBag.TourGuidesList = _travelFacade.GetTourGuides();
            ViewBag.ToursList = _travelFacade.GetTours();
            ViewBag.DestinationLst = _travelFacade.GetDestinations();
            ViewBag.DepartureLocationLst = _travelFacade.GetDepartureLocations();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
