using System;
using System.Collections.Generic;

#nullable disable

namespace WpfAppQLCF.Model
{
    public partial class Loai
    {
        public Loai()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
