namespace WebsiteTuyenSinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TinTuyenSinhViewModel
    {
        public long ID { get; set; }

        public string TieuDe { get; set; }

        public string TieuDeNotUnikey { get; set; }

        public string TinTucLink { get; set; }

        public bool? HienThiTieuDe { get; set; }

        public string TomTat { get; set; }

        public bool? HienThiTomTat { get; set; }

        public string NoiDung { get; set; }

        public string TuKhoa { get; set; }

        public string HinhThuNho { get; set; }

        public bool? HienThiHinhThuNho { get; set; }

        public int? LuotXem { get; set; }

        public bool? ThongTinNong { get; set; }

        public string FileDinhKem { get; set; }

        public bool? HienThiFile { get; set; }

        public bool? KichHoat { get; set; }

        public string NgayTao { get; set; }

        public string NguoiTao { get; set; }

        public string NgaySua { get; set; }

        public string NguoiSua { get; set; }

        public bool? DaXoa { get; set; }

        public string NgayXoa { get; set; }

        public string NguoiXoa { get; set; }
    }
}
