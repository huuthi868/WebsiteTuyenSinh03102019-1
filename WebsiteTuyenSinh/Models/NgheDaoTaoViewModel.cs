using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteTuyenSinh.Models
{
    public class NgheDaoTaoViewModel
    {
        public IList<PhongKhoa_NgheViewModel> NgheDaoTao;
        public IList<TinLienQuanViewModel> TinLienQuan;
        public IList<TinTuyenSinhViewModel> TinTuyenSinh;
    }
}