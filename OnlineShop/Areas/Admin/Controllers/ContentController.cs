
using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ContentController : Controller
    {
        // GET: Admin/Content
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Content content)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new ContentDao();
                    var result = dao.Insert(content);
                    if (result > 0)
                    {
                        return RedirectToAction("Index", "Content");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm mới không thành công");
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return RedirectToAction("Index","Create");
        }
    }
}