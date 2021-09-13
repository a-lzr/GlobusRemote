using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsdirAppContactsLink
    {
        public int Fid { get; set; }
        public int FkParent { get; set; }
        public string Fcontact { get; set; }
        public bool FflagPrimary { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual TrsdirAppContact FkParentNavigation { get; set; }
    }
}
