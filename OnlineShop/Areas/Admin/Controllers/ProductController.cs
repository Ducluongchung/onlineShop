using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(int page = 1, int PageSize = 10)
        {
            var dao = new ProductDao();
            var model = dao.ListAll(page, PageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetView();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                long result = dao.Insert(product);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công");
                }
            }
            return RedirectToAction("Index", "Create");
        }
        public void SetView(int? SelectedId = null)
        {
            var dao = new ProductCategoryDao();
            ViewBag.CategoryID = new SelectList(dao.List(), "ID", "Name", SelectedId);
        }

        public ActionResult Delete(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductDao dao = new ProductDao();
                var result = dao.Delete(product);
                if (result)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Xóa thành công ");
                }

            }
            return View("Index");
        }
        public ActionResult Edit(int id)
        {
            
            var model = new ProductDao().ViewDetail(id);
            SetView();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                 var result = dao.Update(product);
                if (result)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return RedirectToAction("Index");
        }
    }
}