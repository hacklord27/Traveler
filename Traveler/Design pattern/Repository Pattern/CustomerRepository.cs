using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveler.Models;

namespace Traveler.Design_pattern.Repository_Pattern
{
    public class CustomerRepository : Repository_Pattern
    {
        private readonly TravelBookingEntities1 _db;

        public CustomerRepository(TravelBookingEntities1 context)
        {
            _db = context;
        }

        public void DeleteCustomer(int id)
        {
            var customer = _db.Customers.Find(id);
            if (customer != null)
            {
                _db.Customers.Remove(customer);
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}