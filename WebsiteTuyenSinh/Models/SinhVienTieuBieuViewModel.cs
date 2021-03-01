using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteTuyenSinh.Models
{
    public class SinhVienTieuBieuViewModel
    {
        public IList<TinSinhVienViewModel> TinSinhVien;
        public IList<TinTuyenSinhViewModel> TinLienQuanTuyenSinh;
        public IList<TinLienQuanViewModel> TinLienQuan;
        public TinSinhVienViewModel ChiTietTinSV;
    }
}