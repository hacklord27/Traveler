using System.Collections.Generic;
using Traveler.Models;

namespace Traveler.Facades
{
    public interface ITravelFacade
    {
        List<TourGuide> GetTourGuides();
        List<Tour> GetTours();
        List<Destination> GetDestinations();
        List<DepartureLocation> GetDepartureLocations();
    }
}