using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Traveler.Models;

namespace Traveler.Controllers
{
    public class UsersController : Controller
    {
        TravelBookingEntities1 db = new TravelBookingEntities1();
        // GET: Users
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer cus)
        {
            if (ModelState.IsValid)
            {
                var adminAccount = db.AdminAccounts.FirstOrDefault(k => k.Email == cus.Email && k.Password == cus.Password);

                if (adminAccount != null)
                {
                    Session["Account"] = adminAccount;
                    return RedirectToAction("Index", "Admin/ToursManage");
                }
                var account = db.Customers.FirstOrDefault(k => k.Email == cus.Email && k.Password == cus.Password);
                if (account != null)
                {
                    Session["Account"] = account;
                    return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.ThongBao = "*Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Register(FormCollection customer)
        //{
        //    if (customer["Password"] != customer["rePassword"])
        //    {
        //        @ViewBag.Notification = "Mật khẩu xác nhận không chính xác";
        //        return View();
        //    }
        //    else
        //    {
        //        string email = customer["Email"].ToString();

        //        var cus = db.Customers.FirstOrDefault(k => k.Email == email);

        //        if (cus != null)
        //        {
        //            ViewBag.Notification = "Đã có người đăng ký bằng email này";
        //            return View();
        //        }
        //        string phoneNum = customer["PhoneNumber"].ToString();

        //        var cusByPhoneNum = db.Customers.FirstOrDefault(c => c.PhoneNumber == phoneNum);
        //        if (cusByPhoneNum != null)
        //        {
        //            ViewBag.Notification = "Đã có người đăng ký bằng số điện thoại này";
        //            return View();
        //        }


        //        else
        //        {
        //            Customer accout = new Customer();
        //            accout.Name = customer["UserName"];
        //            accout.Email = customer["Email"];
        //            accout.PhoneNumber = customer["PhoneNumber"];
        //            accout.Password = customer["Password"];
        //            accout.AvatarImage = "";

        //            db.Customers.Add(accout);
        //            db.SaveChanges();
        //            return RedirectToAction("Login", "Users");
        //        }
        //    }
        //}
        [HttpPost]
        public ActionResult Register(FormCollection customer)
        {
            // Kiểm tra ô textbox bị trống
            if (string.IsNullOrWhiteSpace(customer["UserName"]) || string.IsNullOrWhiteSpace(customer["PhoneNumber"]) || string.IsNullOrWhiteSpace(customer["Email"]) || string.IsNullOrWhiteSpace(customer["Password"]) || string.IsNullOrWhiteSpace(customer["rePassword"]))
            {
                ViewBag.Notification = "Vui lòng điền đầy đủ thông tin.";
                return View();
            }

            // Kiểm tra định dạng số điện thoại
            string phoneNum = customer["PhoneNumber"].ToString();
            if (!IsValidPhoneNumber(phoneNum))
            {
                ViewBag.Notification = "Số điện thoại không hợp lệ.";
                return View();
            }

            // Kiểm tra số điện thoại đã tồn tại
            var cusByPhoneNum = db.Customers.FirstOrDefault(c => c.PhoneNumber == phoneNum);
            if (cusByPhoneNum != null)
            {
                ViewBag.Notification = "Đã có người đăng ký bằng số điện thoại này";
                return View();
            }

            // Kiểm tra email đã tồn tại
            string email = customer["Email"].ToString();
            var cus = db.Customers.FirstOrDefault(k => k.Email == email);
            if (cus != null)
            {
                ViewBag.Notification = "Đã có người đăng ký bằng email này";
                return View();
            }

            // Kiểm tra mật khẩu xác nhận
            if (customer["Password"] != customer["rePassword"])
            {
                ViewBag.Notification = "Mật khẩu xác nhận không chính xác";
                return View();
            }
            else
            {
                // Kiểm tra mật khẩu phải có ít nhất một ký tự số và một ký tự chữ cái
                string password = customer["Password"];
                bool hasNumber = false;
                bool hasLetter = false;

                foreach (char c in password)
                {
                    if (char.IsDigit(c))
                    {
                        hasNumber = true;
                    }
                    if (char.IsLetter(c))
                    {
                        hasLetter = true;
                    }
                }

                if (!hasNumber || !hasLetter)
                {
                    ViewBag.Notification = "Mật khẩu phải chứa ít nhất một ký tự số và một ký tự chữ cái";
                    return View();
                }

                // Tạo tài khoản mới và lưu vào cơ sở dữ liệu
                Customer account = new Customer();
                account.Name = customer["UserName"];
                account.Email = email;
                account.PhoneNumber = phoneNum;
                account.Password = password;
                account.AvatarImage = "";

                db.Customers.Add(account);
                db.SaveChanges();
                return RedirectToAction("Login", "Users");
            }
        }

        // Hàm kiểm tra định dạng số điện thoại
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Kiểm tra số điện thoại có chứa toàn ký tự số không
            foreach (char c in phoneNumber)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            // Kiểm tra số điện thoại có độ dài hợp lệ không
            if (phoneNumber.Length < 9 || phoneNumber.Length > 12)
            {
                return false;
            }

            return true;
        }
        public ActionResult Logout()
        {
            Session["Account"] = null;
            return RedirectToAction("Login", "Users");
        }
    }
}