namespace WebsiteTuyenSinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PhongKhoaViewModel
    {
        public long ID { get; set; }

        public string TenPhongKhoa { get; set; }
        public string PhongKhoaLink { get; set; }
        
        public string TruongPhong { get; set; }

        public string PhoTruongPhong { get; set; }

        public string HinhAnh { get; set; }

        public bool? isPhong { get; set; }

        public string NoiDung { get; set; }

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
