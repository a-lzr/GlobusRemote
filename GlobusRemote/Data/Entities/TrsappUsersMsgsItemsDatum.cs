using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappUsersMsgsItemsDatum
    {
        public long FkParent { get; set; }
        public byte[] Fbody { get; set; }
        public byte[] Fhash { get; set; }

        public virtual TrsappUsersMsgsItem FkParentNavigation { get; set; }
    }
}
