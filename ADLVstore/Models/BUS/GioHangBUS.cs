using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADLVstore.Models.BUS
{
    public class GioHangBUS
    {
        public static void Them(string masanpham, string mataikhoan, int soluong, int gia, string tensanpham, int Khuyenmai)
        {

            using (var db = new ShopOnlineConnectionDB())
            {
                var x = db.Query<GioHang>("select * from GioHang Where MaTaiKhoan = '" + mataikhoan + "' and MaSanPham = '" + masanpham + "'").ToList();
                if (x.Count() > 0)
                {
                    // gọi hàm update so lượng
                    int a = (int)x.ElementAt(0).SoLuong + soluong;
                    CapNhat(masanpham, mataikhoan, a, gia, tensanpham, Khuyenmai);
                }
                else
                {
                    var tiengiam = (gia / 100) * Khuyenmai;
                    GioHang giohang = new GioHang()
                    {
                        MaSanPham = masanpham,
                        MaTaiKhoan = mataikhoan,
                        SoLuong = soluong,
                        Gia = gia,
                        TenSanPham = tensanpham,
                        Khuyenmai = Khuyenmai,
                        TongTien = ((gia - tiengiam) * soluong)
                    };
                    db.Insert(giohang);
                }

            }
        }

        public static IEnumerable<GioHang> DanhSach(string mataikhoan)
        {
            using (var db = new ShopOnlineConnectionDB())
            {
                return db.Query<GioHang>("select * from GioHang where MaTaiKhoan = '" + mataikhoan + "'");
            }
        }
        public static void CapNhat(string masanpham, string mataikhoan, int soluong, int gia, string tensanpham, int Khuyenmai)
        {
            using (var db = new ShopOnlineConnectionDB())
            {
                var tiengiam = (gia / 100) * Khuyenmai;
                GioHang giohang = new GioHang()
                {
                    MaSanPham = masanpham,
                    MaTaiKhoan = mataikhoan,
                    SoLuong = soluong,
                    Gia = gia,
                    TenSanPham = tensanpham,
                    Khuyenmai = Khuyenmai,
                    TongTien = ((gia - tiengiam) * soluong)
                };
                var tamp = db.Query<GioHang>("Select idGH from GioHang Where MaTaiKhoan = '" + mataikhoan + "' and MaSanPham = '" + masanpham + "'").FirstOrDefault();
                db.Update(giohang, tamp.IdGH);
            }
        }
        public static void Xoa(string masanpham, string mataikhoan)
        {
            using (var db = new ShopOnlineConnectionDB())
            {
                var a = db.Query<GioHang>("select * from GioHang where MaSanPham = '" + masanpham + "' and MaTaiKhoan ='" + mataikhoan + "'").FirstOrDefault();
                db.Delete(a);
            }
        }
        public static int TongTien(string mataikhoan)
        {
            using (var db = new ShopOnlineConnectionDB())
            {
                List<GioHang> a = DanhSach(mataikhoan).ToList();
                if (a.Count() == 0)
                {
                    return 0;
                }
                return db.Query<int>("select sum(TongTien) from GioHang where MaTaiKhoan = '" + mataikhoan + "' ").FirstOrDefault();

            }
        }
        public static int Tietkiem(string mataikhoan)
        {
            using (var db = new ShopOnlineConnectionDB())
            {
                List<GioHang> gioHang = DanhSach(mataikhoan).ToList();
                if (gioHang.Count() == 0)
                {
                    return 0;
                }
                var tienChuaGiam = 0;
                foreach (var sanPham in gioHang)
                {
                    var gia = (int)sanPham.Gia;
                    var soLuong = (int)sanPham.SoLuong;
                    tienChuaGiam = tienChuaGiam + (gia * soLuong);
                }
                var tienDaGiam = db.Query<int>("select sum(TongTien) from GioHang where MaTaiKhoan = '" + mataikhoan + "' ").FirstOrDefault();
                return tienChuaGiam - tienDaGiam;

            }
        }
    }
}