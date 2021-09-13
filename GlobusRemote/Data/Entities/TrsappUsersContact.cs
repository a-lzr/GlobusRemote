using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappUsersContact : BaseEntity
    {
        public long Fid { get; set; }
        public int FkParent { get; set; }
        public int FkLink { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual TrsdirAppContact FkLinkNavigation { get; set; }
        public virtual TrsappUser FkParentNavigation { get; set; }
    }
}
