using System;
using System.Collections.Generic;

#nullable disable

namespace WpfAppQLCF.Model
{
    public partial class Size
    {
        public Size()
        {
            CtSpSizes = new HashSet<CtSpSize>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CtSpSize> CtSpSizes { get; set; }
    }
}
