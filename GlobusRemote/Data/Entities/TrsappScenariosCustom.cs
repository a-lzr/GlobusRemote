using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappScenariosCustom
    {
        public short FkParent { get; set; }
        public short FkLink { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual TrsdirAppScenariosType FkLinkNavigation { get; set; }
        public virtual TrsappTemplate FkParentNavigation { get; set; }
    }
}
