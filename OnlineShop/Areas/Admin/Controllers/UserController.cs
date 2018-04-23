using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(int page =1,int PageSize=10)
        {
            var dao = new UserDao();
            var model = dao.ListAll(page, PageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var dao = new UserDao().ViewDetail(id);
            return View(dao);
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                UserDao dao = new UserDao();
                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công ");
                }
                
            }
            return View("Index");
        }
       
        public ActionResult Update(User user)
        {
            if (ModelState.IsValid)
            {
                UserDao dao = new UserDao();
                var result = dao.Update(user);
                if (result)                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công ");
                }

            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                UserDao dao = new UserDao();
                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công ");
                }

            }
            return View("Index");
        }
        public ActionResult Delete(User user)
        {
            if (ModelState.IsValid)
            {
                UserDao dao = new UserDao();
                var result = dao.Delete(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công ");
                }

            }
            return View("Index");
        }

    }
}