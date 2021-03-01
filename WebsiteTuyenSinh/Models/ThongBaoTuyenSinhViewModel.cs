using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteTuyenSinh.Models
{
    public class ThongBaoTuyenSinhViewModel
    {
        public IList<TinTuyenSinhViewModel> TinTuyenSinh;
        public IList<TinTuyenSinhViewModel> TinLienQuanTuyenSinh;
        public IList<TinLienQuanViewModel> TinLienQuan;
        public TinTuyenSinhViewModel ChiTietTinTS;
    }
}