using ADLVstore.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace ADLVstore.Areas.Admin.Controllers
{
    public class HoaDonAdminController : Controller
    {
        // GET: Admin/HoaDonAdmin
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            var ds = ThanhToanBUS.DanhSachHoaDon().ToPagedList(page, pagesize);
            return View(ds);
        }
        [HttpGet]
        public ActionResult CapNhat(long mahoadon, int trangthai)
        {
            try
            {
                ThanhToanBUS.SuaDonHang(mahoadon, trangthai);
                return RedirectToAction("../HoaDonAdmin/index");
            }
            catch
            {
                return RedirectToAction("../HoaDonAdmin/index");
            }

        }

        public JsonResult ChiTiet(long id)
        {
            var chitiethoadon = ThanhToanBUS.ChiTietHoaDon(id);

            return Json(new
            {
                data = chitiethoadon
            }, JsonRequestBehavior.AllowGet);
        }

    }
}