using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using ADLVstore.Models;
using ADLVstore.Models.BUS;

namespace ADLVstore.Areas.Admin.Controllers
{
    public class MainAdminController : Controller
    {
        // GET: Admin/MainAdmin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {


            /*  DataTable data = GetDataFromQuery("select (Sum(T)) as soluongbanra,(CAST(MONTH(N) AS VARCHAR(3)) + '-' + CAST(YEAR(N) AS VARCHAR(4))) as thang ,(SUM(tongtien)) as doanhthu from (SELECT dbo.HoaDon.NgayTao as N, dbo.HoaDon.TongTien as TongHoaDon, dbo.ChiTietHoaDon.TenSanPham, dbo.ChiTietHoaDon.SoLuong as T, dbo.ChiTietHoaDon.TongTien as tongtien, dbo.HoaDon.ID FROM  dbo.HoaDon INNER JOIN dbo.ChiTietHoaDon ON dbo.HoaDon.ID = dbo.ChiTietHoaDon.OrderID) a group by CAST(MONTH(N) AS VARCHAR(3)) +'-' + CAST(YEAR(N) AS VARCHAR(4))");
              DataTable data1 = GetDataFromQuery("SELECT top 5 * from (SELECT   SUM(ChiTietHoaDon.SoLuong) as soluongbanra, dbo.ChiTietHoaDon.TenSanPham FROM  dbo.HoaDon INNER JOIN dbo.ChiTietHoaDon ON dbo.HoaDon.ID = dbo.ChiTietHoaDon.OrderID where MONTH(dbo.HoaDon.NgayTao) = 1 Group by ChiTietHoaDon.TenSanPham) a order by soluongbanra Desc ");
              return View(data);*/
            var thongKeBUS = new ThongKeBUS();
            DateTime date = DateTime.Now;
            ThongkeViewModels vm = new ThongkeViewModels();
            vm.BangThongKeThang = thongKeBUS.getBangThongKeThang();
            vm.BangTopSanPham = thongKeBUS.getTop5SanPhamTheoThang(date);
            return View(vm);
        }

        public ActionResult Top5SanPham(string date)
        {
            var thongKeBUS = new ThongKeBUS();
            DateTime ngay = DateTime.Parse(date);
            DataTable data = thongKeBUS.getTop5SanPhamTheoThang(ngay);
            return PartialView("~/Areas/Views/Shared/_Top5SanPham", data);
        }



        // GET: Admin/MainAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/MainAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MainAdmin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/MainAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/MainAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/MainAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/MainAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
