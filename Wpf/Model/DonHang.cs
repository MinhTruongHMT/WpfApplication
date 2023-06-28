using System;
using System.Collections.Generic;

#nullable disable

namespace WpfAppQLCF.Model
{
    public partial class DonHang
    {
        public DonHang()
        {
            Ctdonhangs = new HashSet<Ctdonhang>();
        }

        public string DonHangId { get; set; }
        public string KhachHangId { get; set; }
        public string NhanVienId { get; set; }
        public DateTime NgayTaoDon { get; set; }
        public double TongTien { get; set; }
        public string TinhTrang { get; set; }

        public virtual Khachhang KhachHang { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual ICollection<Ctdonhang> Ctdonhangs { get; set; }
    }
}
