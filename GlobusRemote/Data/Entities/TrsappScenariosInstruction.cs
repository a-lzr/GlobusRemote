using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappScenariosInstruction
    {
        public int Fid { get; set; }
        public short FkParent { get; set; }
        public long FkLink { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual TrsappFile FkLinkNavigation { get; set; }
        public virtual TrsappScenario FkParentNavigation { get; set; }
    }
}
