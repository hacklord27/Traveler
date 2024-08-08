using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Traveler.Models;

namespace Traveler.Design_pattern.Observer_pattern
{
    public interface IUserObserver
    {
        void UserEdit(Customer customer);
    }
    
}
