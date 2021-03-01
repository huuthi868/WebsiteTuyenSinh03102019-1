namespace WebsiteTuyenSinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PhongKhoa_NgheViewModel
    {
        public long ID { get; set; }

        public int PhongKhoaID { get; set; }
        
        public string TenNghe { get; set; }
        public string NgheLink { get; set; }

        public string MoTa { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        public string HinhAnh { get; set; }
        public string Video { get; set; }
        public bool? KichHoat { get; set; }
        public bool isCaoDang { get; set; }
        public bool isTrungCap { get; set; }

        public string NgayTao { get; set; }

        public string NguoiTao { get; set; }

        public string NgaySua { get; set; }

        public string NguoiSua { get; set; }

        public bool? DaXoa { get; set; }

        public string NgayXoa { get; set; }

        public string NguoiXoa { get; set; }
        
        public virtual PhongKhoaViewModel PhongKhoa { get; set; }
        
    }
}
