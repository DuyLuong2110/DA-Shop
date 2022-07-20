using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADLVstore.Models.BUS;
using Microsoft.AspNet.Identity;
using ADLVstore.Models;
using ShopOnlineConnection;
namespace ADLVstore.Controllers
{
    [Authorize]
    public class ThanhToanController : Controller
    {
        // GET: ThanhToan
        public ActionResult Index()
        {
            List<GioHang> ds = GioHangBUS.DanhSach(User.Identity.GetUserId()).ToList();
            if (ds.Count() == 0)
            {
                return RedirectToAction("../Shop/index");
            }
            ViewBag.TongTien = GioHangBUS.TongTien(User.Identity.GetUserId());
            return View(ds);
        }
        [HttpPost]
        public ActionResult Them(string nguoinhan, string sdt, string diachi,string ShipEmail)
        {
            try
            {
                ThanhToanBUS.ThemOrder(nguoinhan, sdt, diachi, ShipEmail, User.Identity.GetUserId());
                

                string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/template/neworder.html"));

                content = content.Replace("{{CustomerName}}", nguoinhan);
                content = content.Replace("{{Phone}}", sdt);
                content = content.Replace("{{Email}}", ShipEmail);
                content = content.Replace("{{Address}}", diachi);
               /* content = content.Replace("{{Quanlity}}", ThanhToanBUS.Soluong(User.Identity.GetUserId()).ToString());*/
                content = content.Replace("{{Total}}", ThanhToanBUS.TongTien(User.Identity.GetUserId()).ToString());

                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(ShipEmail, "Đơn hàng mới từ DASHOP", content);
                new MailHelper().SendMail(toEmail, "Đơn hàng mới từ DASHOP", content);
                return RedirectToAction("../ThanhToan/Checkout_Success");
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult Checkout_Success()
        {
            return View();
        }
    }
}