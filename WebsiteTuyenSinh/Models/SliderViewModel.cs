namespace WebsiteTuyenSinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SliderViewModel
    {
        public long ID { get; set; }

        public string TenHinh { get; set; }

        public string TenHinhNho { get; set; }

        public string Link { get; set; }

        public int? STT { get; set; }

        public bool? KichHoat { get; set; }

        public string NgayTao { get; set; }

        public string NguoiTao { get; set; }

        public string NgaySua { get; set; }

        public string NguoiSua { get; set; }

        public bool? DaXoa { get; set; }

        [StringLength(50)]
        public string NgayXoa { get; set; }

        [StringLength(50)]
        public string NguoiXoa { get; set; }
    }
}
