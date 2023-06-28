using System;
using System.Collections.Generic;

#nullable disable

namespace WpfAppQLCF.Model
{
    public partial class CtSpSize
    {
        public int Ctsizeid { get; set; }
        public string IdSp { get; set; }
        public int? IdSize { get; set; }

        public virtual Size IdSizeNavigation { get; set; }
        public virtual Sanpham IdSpNavigation { get; set; }
    }
}
