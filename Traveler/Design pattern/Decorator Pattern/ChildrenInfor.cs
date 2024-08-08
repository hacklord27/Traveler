using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Traveler.Design_pattern.Decorator_Pattern
{
    // Concrete implementation of child customer information
    public class ChildrenInfor : ICustomerInfor
    {
        public double PriceTicket { get; set; }

        public ChildrenInfor(double priceTicket)
        {
            PriceTicket = priceTicket * 0.7; // Assume child ticket price is 70% of adult ticket price
        }

        public double CalculatePrice()
        {
            return PriceTicket;
        }
    }
}