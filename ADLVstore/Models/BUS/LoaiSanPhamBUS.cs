using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADLVstore.Models.BUS
{
    public class LoaiSanPhamBUS
    {
        //----------------KhachHang---------------
        public static IEnumerable<LoaiSanPham> DanhSach()
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<LoaiSanPham>("select * from LoaiSanPham where TinhTrang =0");
        }
        public static IEnumerable<SanPham> ChiTiet(String id)
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<SanPham>("select * from SanPham where MaloaiSanPham ='" + id + "'");
        }


        //--------------Admin---------------------
        public static IEnumerable<LoaiSanPham> DanhSachAdmin()
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<LoaiSanPham>("select * from LoaiSanPham");
        }
        public static void  InsertLSP(LoaiSanPham lsp)
        {
            var db = new ShopOnlineConnectionDB();
            db.Insert(lsp);

        }
        public static LoaiSanPham ChiTietAdmin(String id)
        {
            var db = new ShopOnlineConnectionDB();
            return db.SingleOrDefault<LoaiSanPham>("select * from LoaiSanPham where MaloaiSanPham ='" + id + "'");
        }
        public static void UpdateLSP(String id, LoaiSanPham lsp)
        {
            var db = new ShopOnlineConnectionDB();
            db.Update(lsp, id);
        }
    
    }

    }