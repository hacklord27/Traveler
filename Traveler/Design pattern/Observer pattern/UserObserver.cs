using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Traveler.Models;

namespace Traveler.Design_pattern.Observer_pattern
{
    public class UserObserver : IUserObserver
    {
        private readonly ModelStateDictionary _modelState;
        public UserObserver(ModelStateDictionary modelState)
        {
            _modelState = modelState;
        }


        public void UserEdit(Customer customer)
        {
            // Thêm thông báo vào ModelState
            _modelState.AddModelError(string.Empty, $"Sản phẩm mới đã được thêm vào: {customer.Name}");
        }
    }
}