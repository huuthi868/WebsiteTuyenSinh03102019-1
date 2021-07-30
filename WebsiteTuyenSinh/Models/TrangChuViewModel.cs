using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteTuyenSinh.Models
{
    public class TrangChuViewModel
    {
        public IList<SliderViewModel> Slider;
        public IList<TinTuyenSinhViewModel> Top3TinTuyenSinh;
        public IList<TinTuyenSinhViewModel> TinLienQuanTuyenSinh;
        public IList<TinLienQuanViewModel> TinLienQuan;
        public TinTuyenSinhViewModel TinTuyenSinh;
        public IList<HoiDapViewModel> lstHoiDap;
    }
}