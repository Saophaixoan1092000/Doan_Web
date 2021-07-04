using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.ModelConfiguration.Conventions;
using Model1.DAO;
using Model1.EF;
using SA_SHOES.Models;
using BotDetect.Web.Mvc;

namespace SA_SHOES.Controllers
{
    public class UserController : Controller
    {
       
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "RegisterCaptcha", "Mã xác nhận không đúng!")]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var check = new UserDao();
                if (check.checkUsername(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (check.checkEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã được sử dụng");
                }
                else
                {
                    var user = new User();
                    user.fullname = model.Name;
                    user.username = model.UserName;
                    user.password = model.Password;
                    user.email = model.Email;
                    user.address = model.Address;
                    user.phone = model.Phone;
                    user.CreatedDate = DateTime.Now;
                    user.Status = true;
                    var result = check.Insert(user);
                    if(result > 0)
                    {
                        ViewBag.Sucess = "Đăng ký tài khoản thành công";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }
                }
            }
            return View(model);
            //    var hoten = collection["HotenKH"];
            //    var tendn = collection["TenDN"];
            //    var matkhau = collection["Matkhau"];
            //    var matkhau2 = collection["Matkhau2"];
            //    var diachi = collection["Diachi"];
            //    var email = collection["Email"];
            //    var dienthoai = collection["Dienthoai"];


            //    if (String.IsNullOrEmpty(hoten))
            //    {
            //        ViewData["1"] = " Họ và Tên không được để trống";

            //    }
            //    if (String.IsNullOrEmpty(tendn))
            //    {
            //        ViewData["2"] = " Nhập tên đăng nhập";

            //    }
            //    if (String.IsNullOrEmpty(matkhau))
            //    {
            //        ViewData["3"] = " Phải nhập mật khẩu";

            //    }
            //    if (String.IsNullOrEmpty(matkhau2))
            //    {
            //        ViewData["4"] = " Phải nhập lại mật khẩu";
            //    }
            //    if (String.IsNullOrEmpty(diachi))
            //    {
            //        ViewData["5"] = " Phải nhập địa chỉ";
            //    }
            //    if (String.IsNullOrEmpty(email))
            //    {
            //        ViewData["6"] = " Email không được bỏ trống";

            //    }
            //    if (String.IsNullOrEmpty(dienthoai))
            //    {
            //        ViewData["7"] = " Phải nhập số điện thoại";

            //    }
            //    else
            //    {
            //        //Gán giá trị cho đối tượng được tạo mới
            //        kh.fullname = hoten;
            //        kh.username = tendn;
            //        kh.password = matkhau;
            //        kh.address = diachi;
            //        kh.email = email;
            //        kh.phone = dienthoai;
            //        db.Users.
            //        return RedirectToAction("Dangnhap");
            //    }
            //    return this.Dangky();
            //}
        }


        
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel user)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.login(user.UserName, user.Password);
                if(result == 1)
                {
                    return RedirectToAction("Index", "Home");
                    
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");

                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else
                {
                    ModelState.AddModelError("", "Có lỗi trong quá trình đăng nhập");
                }
            }
            
            return View(user);
        }
    }
}