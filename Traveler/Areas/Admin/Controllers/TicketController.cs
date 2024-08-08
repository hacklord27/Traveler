using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Traveler.Design_pattern.Repository_Pattern;
using Traveler.Models;

namespace Traveler.Areas.Admin.Controllers
{
    public class TicketController : Controller
    {
        private TravelBookingEntities1 db = new TravelBookingEntities1();
        private readonly Repository_Pattern _ticketRepository;
        public TicketController()
        {
            _ticketRepository = new CustomerRepository(new TravelBookingEntities1());
        }
        // GET: Admin/Ticket
        public ActionResult Index()
        {
            IEnumerable<Book> books = db.Books.ToList();

            // Truyền danh sách books cho View
            return View(books);
        }
        // GET: Admin/Ticket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Admin/Ticket/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BookingDay,BookingCode,Status,SlotNumber,Note,ContactPhoneNumber,ContactName")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _ticketRepository.DeleteCustomer(id);
            _ticketRepository.Save();
            return RedirectToAction("Index");
        }
    }
}