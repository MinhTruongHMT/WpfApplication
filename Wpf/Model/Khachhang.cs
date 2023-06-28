using System;
using System.Collections.Generic;

#nullable disable

namespace WpfAppQLCF.Model
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
