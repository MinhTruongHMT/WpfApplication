using System;
using System.Collections.Generic;

#nullable disable

namespace WpfAppQLCF.Model
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public double? Luong { get; set; }
        public string Anh { get; set; }

        public virtual ICollection<DonHang> DonHangs { get; set; }

        public string toString()
        {
            return this.Fullname;
        }
    }
}
