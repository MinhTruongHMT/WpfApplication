using System;
using System.Collections.Generic;

#nullable disable

namespace WpfAppQLCF.Model
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            CtSpSizes = new HashSet<CtSpSize>();
            Ctdonhangs = new HashSet<Ctdonhang>();
        }

        public string Sanphamid { get; set; }
        public string TenSp { get; set; }
        public double Gia { get; set; }
        public DateTime? HanSuDung { get; set; }
        public int? IdSize { get; set; }
        public int? IdLoai { get; set; }
        public string Anh { get; set; }

        public virtual Loai IdLoaiNavigation { get; set; }
        public virtual ICollection<CtSpSize> CtSpSizes { get; set; }
        public virtual ICollection<Ctdonhang> Ctdonhangs { get; set; }
    }
}
