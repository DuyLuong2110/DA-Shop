using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ADLVstore.Models.BUS
{
    public class ShopOnlineBUS
    { 
  
            public static IEnumerable<SanPham> DanhSach()
            {
                var db = new ShopOnlineConnectionDB();
                return db.Query<SanPham>("select * from SanPham where TinhTrang =0");
            }
            public static SanPham Chitiet(String a)
            {
                var db = new ShopOnlineConnectionDB();
                return db.SingleOrDefault<SanPham>("select * from SanPham where MaSanPham =@0", a);
            }
            public static IEnumerable<SanPham> Top4New()
            {
                var db = new ShopOnlineConnectionDB();
                return db.Query<SanPham>("select Top 4 * from SanPham where GhiChu = 'top4'");
            }
            public static IEnumerable<SanPham> TopHot()
            {
                var db = new ShopOnlineConnectionDB();
                return db.Query<SanPham>("select Top 4 * from SanPham where GhiChu = 'tophot'");
            }
        public static IEnumerable<SanPham> SelectLoaiSanPham(string masp)
        {
            var db = new ShopOnlineConnectionDB();
            var a = Chitiet(masp);
            return db.Query<SanPham>("select Top 4 * from SanPham Where MaLoaiSanPham = '" + a.MaLoaiSanPham+"'");
        }
        //---------------------------------------\
        public static IEnumerable<SanPham> DanhSachSP()
            {
                var db = new ShopOnlineConnectionDB();
                return db.Query<SanPham>("select * from SanPham");
            }
            public static void InsertSP(SanPham sp)
            {
                var db = new ShopOnlineConnectionDB();
                db.Insert(sp);
            }
            public static void UpdateSP(SanPham sp)
            {
                var db = new ShopOnlineConnectionDB();
                db.Update(sp);
            }
            public static void DeleteSP(SanPham sp)
            {
                var db = new ShopOnlineConnectionDB();
                db.Delete(sp);
            }
       

        internal static void UPdateLSP(LoaiSanPham lsp)
            {
                throw new NotImplementedException();
            }
        public static void CapNhatLuotView(string masp)
        {
            var db = new ShopOnlineConnectionDB();
            var a = Chitiet(masp);
            a.LuotView = a.LuotView + 1;
            db.Update(a, masp);
        }


        //----------------------------------update images---------------
        public static void UpdateImages(string id, string images)
        {
            var db = new ShopOnlineConnectionDB();
            var sp = ShopOnlineBUS.Chitiet(id);
            sp.HinhChinh = images;
            db.Update(sp, id);
        }
        //------------------------Loai ảnh đại diện cho hình ảnh-------------
        public static string LoadAvartaImg(string id)
        {
            var sp = Chitiet(id);

            var product = ShopOnlineBUS.Chitiet(id);
            var images = product.HinhChinh;
            string imagesURL = "/Asset/images/" + images;
            /*List<string> listImageReturn = new List<string>();*/

            /*foreach (XElement element in xImages.Elements())
            {
                listImageReturn.Add(element.Value);
            }
            if (listImageReturn.Count() == 0)
            {
                return "/Asset/images/default.png";
            }
            return listImageReturn.ElementAt(0).ToString();*/
            return imagesURL;
        } 

        internal static void DEleteSP(SanPham sp)
        {
            throw new NotImplementedException();
        }
    }
}