﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Traveler.Facades;
using Traveler.Models;

namespace Traveler.Design_pattern.Facade_pattern
{
    public class TravelFacade : ITravelFacade
    {
        private TravelBookingEntities1 _db = new TravelBookingEntities1();

        public List<TourGuide> GetTourGuides()
        {
            return _db.TourGuides.ToList();
        }

        public List<Tour> GetTours()
        {
            List<Tour> toursList = _db.Tours.ToList();
            toursList.Reverse();
            return toursList;
        }

        public List<Destination> GetDestinations()
        {
            return _db.Destinations.ToList();
        }

        public List<DepartureLocation> GetDepartureLocations()
        {
            return _db.DepartureLocations.ToList();
        }
    }
}