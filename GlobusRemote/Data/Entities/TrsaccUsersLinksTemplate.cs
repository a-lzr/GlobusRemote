using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsaccUsersLinksTemplate
    {
        public int FkParent { get; set; }
        public short FkLink { get; set; }
        public bool FflagExpire { get; set; }

        public virtual TrsaccTemplate FkLinkNavigation { get; set; }
        public virtual TrsaccUser FkParentNavigation { get; set; }
    }
}
