using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappUsersTemplatesLink
    {
        public int FkParent { get; set; }
        public short FkLink { get; set; }
        public bool FflagExpire { get; set; }

        public virtual TrsappTemplate FkLinkNavigation { get; set; }
        public virtual TrsappUser FkParentNavigation { get; set; }
    }
}
