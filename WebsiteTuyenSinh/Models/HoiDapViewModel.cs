namespace WebsiteTuyenSinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class HoiDapViewModel
    {
        public long ID { get; set; }
        public string HoTen { get; set; }
        public string NamSinh { get; set; }
        public string DiaChi { get; set; }
        public string EmailNguoiHoi { get; set; }
        public string SoDienThoai { get; set; }

        public string CauHoi { get; set; }
        public string TraLoi { get; set; }
        public string NguoiTraLoi { get; set; }
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
