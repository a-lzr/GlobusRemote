using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappUsersMissionsFile
    {
        public long Fid { get; set; }
        public long FkParent { get; set; }
        public long FkLink { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual TrsappFile FkLinkNavigation { get; set; }
        public virtual TrsappUsersMission FkParentNavigation { get; set; }
    }
}
