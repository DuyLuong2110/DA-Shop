using ADLVstore.Models.BUS;
using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ADLVstore.Controllers
{
    [Authorize]
    public class ThongTinCaNhanController : Controller
    {
        // GET: ThongTinCaNhan
        public ActionResult Index()
        {
            var ds = ThongTinCaNhanBUS.LoadThongTin(User.Identity.GetUserId());
            return View(ds);
        }
        public ActionResult Them()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Them(ThongTinCaNhan ttcn)
        {
            try
            {
                // TODO: Add update logic here
                ThongTinCaNhanBUS.ThemThongTin(ttcn);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult SuaThongtin()
        {
            return View(ThongTinCaNhanBUS.LoadThongTin(User.Identity.GetUserId()));
        }

        // POST: Admin/TaiKhoanAdmin/Create
        [HttpPost]
        public ActionResult SuaThongtin(ThongTinCaNhan ttcn)
        {
            try
            {
               // TODO: Add insert logic here
                ThongTinCaNhanBUS.SuaThongTin(ttcn);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}