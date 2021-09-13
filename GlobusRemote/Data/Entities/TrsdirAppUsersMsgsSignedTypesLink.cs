using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsdirAppUsersMsgsSignedTypesLink
    {
        public byte FkParent { get; set; }
        public byte FkLink { get; set; }
        public bool FflagExpire { get; set; }

        public virtual TrsdirAppUsersMsgsSignedType FkLinkNavigation { get; set; }
        public virtual TrsdirAppUsersMsgsType FkParentNavigation { get; set; }
    }
}
