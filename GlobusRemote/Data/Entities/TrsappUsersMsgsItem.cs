using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappUsersMsgsItem
    {
        public long Fid { get; set; }
        public long FkParent { get; set; }
        public short FkType { get; set; }
        public int Fsize { get; set; }
        public string Fcomment { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual TrsappUsersMsg FkParentNavigation { get; set; }
        public virtual TrsdirAppUsersMsgsItemsType FkTypeNavigation { get; set; }
        public virtual TrsappUsersMsgsItemsDatum TrsappUsersMsgsItemsDatum { get; set; }
    }
}
