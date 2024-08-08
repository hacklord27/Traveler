using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveler.Models;

namespace Traveler.Design_pattern.Factory_Method_Pattern
{
    internal interface ITourSearchStrategy
    {
        List<Tour> SearchTours(TravelBookingEntities1 db, string departureLocation, string destination, DateTime? departureDay, (int, int) priceInterval);
    }
}
