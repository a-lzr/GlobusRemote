using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsdirAppUsersMsgsItemsType
    {
        public TrsdirAppUsersMsgsItemsType()
        {
            TrsappUsersMsgsItems = new HashSet<TrsappUsersMsgsItem>();
        }

        public short Fid { get; set; }
        public string Fname { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual ICollection<TrsappUsersMsgsItem> TrsappUsersMsgsItems { get; set; }
    }
}
