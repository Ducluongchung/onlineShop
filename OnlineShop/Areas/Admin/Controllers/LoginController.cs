using Models.DAO;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.Username, model.Password);
                if (result==1)
                {
                    var user = dao.GetById(model.Username);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(Contant.User_Session, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if(result == 0)
                    {
                        ModelState.AddModelError("", "Tài khoản không tồn tại");
                    }
                    else
                    {
                        if (result == -1)
                        {
                            ModelState.AddModelError("", "Tài khoản bị khóa");
                        }
                        else
                        {
                            if (result==-2)
                            {
                                ModelState.AddModelError("", "Tài khoản mật khẩu không đúng");
                            }
                        }
                    }
                }
            }
            return View("Index");

        }
        
    }
}