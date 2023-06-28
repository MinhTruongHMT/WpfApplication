using System;
using System.Collections.Generic;

#nullable disable

namespace WpfAppQLCF.Model
{
    public partial class Ctdonhang
    {
        public int CtdonHangId { get; set; }
        public string DonHangId { get; set; }
        public string SanPhamId { get; set; }
        public int? SoLuong { get; set; }
        public double Gia { get; set; }
        public string Size { get; set; }

        public virtual DonHang DonHang { get; set; }
        public virtual Sanpham SanPham { get; set; }
    }
}
