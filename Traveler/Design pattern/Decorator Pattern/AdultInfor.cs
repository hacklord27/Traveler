using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Traveler.Design_pattern.Decorator_Pattern
{
    // Concrete implementation of adult customer information
    public class AdultInfor : ICustomerInfor
    {
        public double PriceTicket { get; set; }

        public AdultInfor(double priceTicket)
        {
            PriceTicket = priceTicket;
        }

        public double CalculatePrice()
        {
            return PriceTicket;
        }
    }
}