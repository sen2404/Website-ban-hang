using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Websitebanhang.Models;

namespace Websitebanhang.Areas.Admin.Controllers


{
    public class HomeController : Controller
    {
        private DBConnect db = new DBConnect();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                var checkEmail = db.KhachHangs.FirstOrDefault(m => m.email == kh.email);
                if (checkEmail == null)
                {
                    kh.password = GetMD5(kh.password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.KhachHangs.Add(kh);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.EmailError = "Email đã tồn tại";
                    return View();
                }

            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = db.KhachHangs.Where(s => s.email.Equals(email) && s.password.Equals(f_password)).ToList();
                if (data != null)
                {
                    //add session
                    Session["Tenkh"] = data.FirstOrDefault().TenKhachHang;
                    Session["Email"] = data.FirstOrDefault().email;
                    Session["idKhachHang"] = data.FirstOrDefault().id;
                    var checkadmin = data.FirstOrDefault().Role;
                    if (checkadmin == "Admin")
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }

                }
                else
                {
                    ViewBag.error = "Đăng nhập không thành công";
                    return RedirectToAction("Login");
                }
            }

            return View();
        }
        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }


        public static string GetMD5(string pass)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(pass);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}