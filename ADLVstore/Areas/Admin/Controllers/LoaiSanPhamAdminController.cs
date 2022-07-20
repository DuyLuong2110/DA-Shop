using ADLVstore.Models.BUS;
using PagedList;
using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADLVstore.Areas.Admin.Controllers
{
    public class LoaiSanPhamAdminController : Controller
    {
        // GET: Admin/LoaiSanPhamAdmin
        [Authorize(Roles = "Admin")]
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            var db = LoaiSanPhamBUS.DanhSachAdmin().ToPagedList(page, pagesize);
            return View(db);
        }

        // GET: Admin/LoaiSanPhamAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/LoaiSanPhamAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSanPhamAdmin/Create
        [HttpPost]
        public ActionResult Create(LoaiSanPham lsp )
        {
            try
            {
                // TODO: Add insert logic here
                LoaiSanPhamBUS.InsertLSP(lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoaiSanPhamAdmin/Edit/5
        public ActionResult Edit(String id)
        {
            //load db theo id
            var db = LoaiSanPhamBUS.ChiTietAdmin(id);
            return View(db);
        }

        // POST: Admin/LoaiSanPhamAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(String id, LoaiSanPham lsp)
        {
            try
            {
                // TODO: Add update logic here
                LoaiSanPhamBUS.UpdateLSP(id, lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult XoaTamThoi(String id)
        {
            var db = LoaiSanPhamBUS.ChiTietAdmin(id);
            return View(db);
        }

        // POST: Admin/NhaSanXuatAdmin/Delete/5
        [HttpPost]
        public ActionResult XoaTamThoi(String id, LoaiSanPham lsp)
        {
            try
            {
                // TODO: Add delete logic here
                lsp.TinhTrang = "1";
                LoaiSanPhamBUS.UpdateLSP(id, lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(lsp);
            }
        }
        // GET: Admin/LoaiSanPhamAdmin/Delete/5
        public ActionResult Delete(String id)
        {
            return View();
        }

        // POST: Admin/LoaiSanPhamAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
