using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;


namespace ADLVstore.Models
{
    public class ThongkeViewModels
    {
        public DataTable BangThongKeThang { get; set; }
        public DataTable BangTopSanPham { get; set; }
    }
    
}