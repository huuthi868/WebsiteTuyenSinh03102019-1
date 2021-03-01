namespace WebsiteTuyenSinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class DangKyTrungCap2NamViewModel
    {
        public long ID { get; set; }

        public int NgheID { get; set; }

        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public bool? GioiTinh { get; set; }

        public string HKTT { get; set; }

        public string DiaChi { get; set; }

        public string SoDienThoai { get; set; }

        public string Email { get; set; }

        public string Facebook { get; set; }

        public string TruongTotNghiep { get; set; }

        public float DiemLop6 { get; set; }
        public float DiemLop7 { get; set; }
        public float DiemLop8 { get; set; }
        public float DiemLop9 { get; set; }
        public bool? TrangThai { get; set; }
        public bool? DangKyOnline { get; set; }
        public bool? HoanThienHoSo { get; set; }
        public bool? KichHoat { get; set; }
        public string NgayTao { get; set; }

        public string NguoiTao { get; set; }

        public string NgaySua { get; set; }

        public string NguoiSua { get; set; }

        public bool? DaXoa { get; set; }

        public string NgayXoa { get; set; }

        public string NguoiXoa { get; set; }

        public virtual PhongKhoa_NgheViewModel PhongKhoa_Nghe { get; set; }

    }
}
