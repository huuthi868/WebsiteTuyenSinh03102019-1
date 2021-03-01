using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteTuyenSinh.Models
{
    public class KetQuaViewModel
    {
        public string HoTen { get; set; }

        public string NgaySinh { get; set; }

        public PhongKhoa_NgheViewModel PhongKhoa_Nghe { get; set; }

        public string TrangThai { get; set; }


    }
}