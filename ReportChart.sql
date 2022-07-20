SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Sp_GetReportProduceByYear 
    @Year INT


AS
BEGIN
    select YEAR(ord.NgayTao) as years , pro.TenSanPham, COUNT(pro.MaSanPham) as total
    from HoaDon ord join ChiTietHoaDon od on od.OrderID=ord.ID
    join SanPham pro on pro.MaSanPham = od.MaSanPham

    where YEAR(ord.NgayTao)= @Year
    GROUP BY YEAR(ord.NgayTao), pro.TenSanPham
    ORDER By YEAR(ord.NgayTao)


END
GO
