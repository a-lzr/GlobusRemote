using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappTemplatesLinksScenariosGroup
    {
        public short FkParent { get; set; }
        public int FkLink { get; set; }
        public bool FflagExpire { get; set; }

        public virtual TrsappScenariosGroup FkLinkNavigation { get; set; }
        public virtual TrsappTemplate FkParentNavigation { get; set; }
    }
}
