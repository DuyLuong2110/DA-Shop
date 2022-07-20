using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Diagnostics;
namespace ADLVstore.Models.BUS
{
    public class BinhLuanBUS
    {
        public static void ThemBT(BinhLuan bl)
        {
            // truy vấn thiếu hoặc sai gì đó
            var db = new ShopOnlineConnectionDB();
            //string a = "insert into BinhLuan(MaSanPham,MaTaiKhoan,NoiDung) values('" + MaSanPham + "','" + MaTaiKhoan + "','" + NoiDung + "')";
            db.Insert(bl);
        }
        public static IEnumerable<BinhLuan> LoadBinhLuan(string msp,int page = 1, int pagesize = 1)
        {
            var db = new ShopOnlineConnectionDB();
            var rs = db.Query<BinhLuan>("select * from BinhLuan where MaSanPham =@0 ORDER BY Ngay desc",msp).ToPagedList(page, pagesize);
            return rs;
        }
    }
}