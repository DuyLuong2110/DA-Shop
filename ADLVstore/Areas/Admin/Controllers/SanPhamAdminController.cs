using ADLVstore.Models.BUS;
using PagedList;
using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace ADLVstore.Areas.Admin.Controllers
{
    public class SanPhamAdminController : Controller
    {
        // GET: Admin/SanPhamAdmin
        [Authorize(Roles = "Admin")]
        public ActionResult Index(int page = 1, int pagesize = 10)
        {

            return View(ShopOnlineBUS.DanhSachSP().ToPagedList(page, pagesize));
        }

        public JsonResult LoadImages(string id)
        {
            var product = ShopOnlineBUS.Chitiet(id);
            var images = product.HinhChinh;
            XElement xImages = XElement.Parse((string)images);
            List<string> listImageReturn = new List<string>();

            foreach (XElement element in xImages.Elements())
            {
                listImageReturn.Add(element.Value);
            }
            return Json(new
            {
                data = listImageReturn
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveImages(string id, string images)
        {
            JavaScriptSerializer serizlizer = new JavaScriptSerializer();
            var listImages = serizlizer.Deserialize<List<string>>(images);

            XElement xElement = new XElement("Images");

            foreach (var item in listImages)
            {
                var subStringItem = item.Substring(22);
                xElement.Add(new XElement("Images", subStringItem));
            }
            if (listImages.Count() == 0)
            {

                xElement.Add(new XElement("Images", "/Asset/data/images/default.png"));
            }
            try
            {
                ShopOnlineBUS.UpdateImages(id, xElement.ToString());
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false
                });
            }

        }
        // GET: Admin/SanPhamAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/SanPhamAdmin/Create
        public ActionResult Create()
        {
            ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNhaSanXuat", "TenNhaSanXuat");
            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham");

            return View();
        }

        // POST: Admin/SanPhamAdmin/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SanPham sp)
        {
            try
            {
               
                // TODO: Add insert logic here
                ShopOnlineBUS.InsertSP(sp);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Admin/SanPhamAdmin/Edit/5
        public ActionResult Edit(String id)
        {
            ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNhaSanXuat", "TenNhaSanXuat");
            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham");
            return View(ShopOnlineBUS.Chitiet(id));
        }

        // POST: Admin/SanPhamAdmin/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(string id, SanPham sp)
        {
            try
            {

                // TODO: Add update logic here
                ShopOnlineBUS.UpdateSP(sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPhamAdmin/Delete/5
        public ActionResult Delete(String id)
        {
            ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNhaSanXuat", "TenNhaSanXuat");
            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham");
            return View(ShopOnlineBUS.Chitiet(id));
         
        }

        // POST: Admin/SanPhamAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, SanPham sp)
        {
            try
            {
                // TODO: Add delete logic here
                ShopOnlineBUS.DeleteSP(sp);
                return RedirectToAction("Index"); 
            }
            catch
            {
                return View();
            }
        }
    }
}
