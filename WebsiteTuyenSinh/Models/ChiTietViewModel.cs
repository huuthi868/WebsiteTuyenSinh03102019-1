using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteTuyenSinh.Models
{
    public class ChiTietViewModel
    {
        public TinTuyenSinhViewModel TinTuyenSinh;
        public IList<TinTuyenSinhViewModel> TinMoi;
        public IList<TinLienQuanViewModel> TinLienQuan;
        public IList<TinLienQuanViewModel> tin;
    }
}