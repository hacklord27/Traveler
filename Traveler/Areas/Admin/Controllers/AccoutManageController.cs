using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Traveler.Models;
using Traveler.Design_pattern.Observer_pattern;
using Traveler.Design_pattern.Repository_Pattern;

namespace Traveler.Areas.Admin.Controllers
{
    public class AccoutManageController : Controller
    {
        private TravelBookingEntities1 db = new TravelBookingEntities1();
        private readonly ModelStateDictionary _modelState;
        private readonly IUserObserver _userObserver;
        private readonly Repository_Pattern _customerRepository;
        public AccoutManageController()
        {
            _modelState = new ModelStateDictionary();
            _userObserver = new UserObserver(_modelState);
            _customerRepository = new CustomerRepository(new TravelBookingEntities1());
        }
     
        // GET: Admin/Ticket
        public ActionResult Index()
        {
            var customers = db.Customers;
            return View(customers.ToList());
        }
        public ActionResult Edit(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var userObserver = new UserObserver(ModelState);
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                // Gửi thông báo JSON từ Observer
                return Json(new { success = true });
            }
            return View(customer);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _customerRepository.DeleteCustomer(id);
            _customerRepository.Save();
            return RedirectToAction("Index");
        }

    }

}