using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappUsersMissionsItemsSigned
    {
        public long Fid { get; set; }
        public long FkParent { get; set; }
        public long FkLink { get; set; }
        public int FkScenarioGroup { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual TrsappUsersMsg FkLinkNavigation { get; set; }
        public virtual TrsappUsersMissionsItem FkParentNavigation { get; set; }
        public virtual TrsappScenariosGroup FkScenarioGroupNavigation { get; set; }
    }
}
