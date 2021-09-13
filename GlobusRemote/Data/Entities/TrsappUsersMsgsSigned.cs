using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappUsersMsgsSigned
    {
        public long FkParent { get; set; }
        public byte FkType { get; set; }
        public bool FflagExpire { get; set; }

        public virtual TrsappUsersMsg FkParentNavigation { get; set; }
        public virtual TrsdirAppUsersMsgsSignedType FkTypeNavigation { get; set; }
    }
}
