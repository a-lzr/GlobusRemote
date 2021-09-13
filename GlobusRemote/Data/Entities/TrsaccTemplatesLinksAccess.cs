using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsaccTemplatesLinksAccess
    {
        public short FkParent { get; set; }
        public short FkLink { get; set; }
        public bool FflagExpire { get; set; }

        public virtual TrsdirAccTemplatesAccessType FkLinkNavigation { get; set; }
        public virtual TrsaccTemplate FkParentNavigation { get; set; }
    }
}
