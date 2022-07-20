using ADLVstore.Models.BUS;
using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PagedList;

namespace ADLVstore.Controllers
{
    public class ThongTinDonHangController : Controller
    {
        // GET: ThongTinDonHang
        public ActionResult Donhang(int page = 1, int pagesize = 10)
        {
            string mataikhoan = User.Identity.GetUserId().ToString();
            var ds = ThanhToanBUS.ThongTinDonHang(mataikhoan).ToPagedList(page, pagesize);
            return View(ds);
        }
    }
}