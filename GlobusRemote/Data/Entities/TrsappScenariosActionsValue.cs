using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappScenariosActionsValue
    {
        public int Fid { get; set; }
        public int FkParent { get; set; }
        public string Fname { get; set; }
        public short Fvalue { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual TrsappScenariosAction FkParentNavigation { get; set; }
    }
}
