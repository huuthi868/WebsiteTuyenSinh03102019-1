namespace WebsiteTuyenSinh.Models
{
    public partial class DangKyTuVanViewModel
    {
        public long ID { get; set; }

        public string HoTen { get; set; }

        public string Email { get; set; }

        public string SoDienThoai { get; set; }

        public string NgheTuVan { get; set; }

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
