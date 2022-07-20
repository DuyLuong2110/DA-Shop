using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace ADLVstore.Models.BUS
{
    public class ThongKeBUS
    {
        public DataTable getBangThongKeThang()
        {
            DataTable bangThongKe = GetDataFromQuery("select (Sum(T)) as soluongbanra,(CAST(MONTH(N) AS VARCHAR(3)) + '-' + CAST(YEAR(N) AS VARCHAR(4))) as thang ,(SUM(tongtien)) as doanhthu from (SELECT dbo.HoaDon.NgayTao as N, dbo.HoaDon.TongTien as TongHoaDon, dbo.ChiTietHoaDon.TenSanPham, dbo.ChiTietHoaDon.SoLuong as T, dbo.ChiTietHoaDon.TongTien as tongtien, dbo.HoaDon.ID FROM  dbo.HoaDon INNER JOIN dbo.ChiTietHoaDon ON dbo.HoaDon.ID = dbo.ChiTietHoaDon.OrderID) a group by CAST(MONTH(N) AS VARCHAR(3)) +'-' + CAST(YEAR(N) AS VARCHAR(4))");
            return bangThongKe;
        }

        public DataTable getTop5SanPhamTheoThang(DateTime date)
        {
            int thang = date.Month;
            int nam = date.Year;
            DataTable top5SanPham = GetDataFromQuery("SELECT top 5 * from (SELECT   SUM(ChiTietHoaDon.SoLuong) as soluongbanra, dbo.ChiTietHoaDon.TenSanPham FROM  dbo.HoaDon INNER JOIN dbo.ChiTietHoaDon ON dbo.HoaDon.ID = dbo.ChiTietHoaDon.OrderID where MONTH(dbo.HoaDon.NgayTao) = "+ thang + " AND YEAR(dbo.HoaDon.NgayTao) = " +  nam +" Group by ChiTietHoaDon.TenSanPham) a order by soluongbanra Desc ");
            return top5SanPham;
        }

        DataTable GetDataFromQuery(string query)
        {
            SqlDataAdapter adap = new SqlDataAdapter(query, "Data Source=DESKTOP-RKLUVDD;Initial Catalog=ShopOnline;Integrated Security=True");
            DataTable data = new DataTable();
            adap.Fill(data);
            return data;
        }
       
    }
}