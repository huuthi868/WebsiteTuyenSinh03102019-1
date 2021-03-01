namespace WebsiteTuyenSinh.Models
{
    public class GioiThieuTruongViewModel
    {
        public int ID { get; set; }

        public string TomTat { get; set; }

        public string NoiDung { get; set; }

        public string Video { get; set; }

        public string NgayTao { get; set; }

        public string NguoiTao { get; set; }

        public string NgaySua { get; set; }

        public string NguoiSua { get; set; }

        public bool? DaXoa { get; set; }

        public string NgayXoa { get; set; }

        public string NguoiXoa { get; set; }
    }
}