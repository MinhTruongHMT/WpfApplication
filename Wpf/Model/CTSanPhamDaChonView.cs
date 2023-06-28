using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppQLCF.Model;

namespace Wpf.Model
{
    internal class CTSanPhamDaChonView
    {
        public static int st = 0;
        public int CtdonHangId { get; set; }
        public int? SoLuong { get; set; }
        public double Gia { get; set; }
        public double Thanhtien { get; set; }
        public string Size { get; set; }
        public string TenSp { get; set; }

        public string Sanphamid { get; set; }


        public CTSanPhamDaChonView(){
            st += 1;
        }
        public static List<CTSanPhamDaChonView> getDSSpdaChonView(List<Sanpham> dsSanPham, List<Ctdonhang> dsCtDh)
        {

            List<CTSanPhamDaChonView> x = dsSanPham.Join(dsCtDh, x => x.Sanphamid, y => y.SanPhamId, (x, y) => new CTSanPhamDaChonView
            {
                CtdonHangId = y.CtdonHangId,
                SoLuong = y.SoLuong,
                Gia = x.Gia,
                Size= y.Size,
                TenSp=x.TenSp,
                Thanhtien = (double)(x.Gia * y.SoLuong),
                Sanphamid= x.Sanphamid
            }).ToList();
            return x;
        }
    }
}
