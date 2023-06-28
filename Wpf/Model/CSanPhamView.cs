using WpfAppQLCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppQLCF.Model
{
    internal class CSanPhamView
    {
        public string Sanphamid { get; set; }
        public string TenSp { get; set; }
        public double Gia { get; set; }
        public DateTime? HanSuDung { get; set; }
        public string Name { get; set; }
        public string Anh { get; set; }

        public static List<CSanPhamView> getDSHocvienView(List<Sanpham> dsSanPham, List<Loai> dsLoai)
        {
            
            List<CSanPhamView> x = dsSanPham.Join(dsLoai, x => x.IdLoai, y => y.Id, (x, y) => new CSanPhamView
            {
                Sanphamid = x.Sanphamid,
                TenSp = x.TenSp,
                Gia =x.Gia,
                HanSuDung = x.HanSuDung,
                Name = y.Name,
                Anh=x.Anh
            }).ToList();
            return x;
        }
    }
}
