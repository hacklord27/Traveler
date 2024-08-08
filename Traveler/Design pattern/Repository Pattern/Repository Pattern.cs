using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveler.Models;

namespace Traveler.Design_pattern.Repository_Pattern
{
    public interface Repository_Pattern
    {
        void DeleteCustomer(int id);
        void Save();
    }
}
