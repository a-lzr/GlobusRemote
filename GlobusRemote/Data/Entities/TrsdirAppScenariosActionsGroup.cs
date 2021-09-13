using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsdirAppScenariosActionsGroup
    {
        public TrsdirAppScenariosActionsGroup()
        {
            TrsappScenariosActions = new HashSet<TrsappScenariosAction>();
        }

        public short Fid { get; set; }
        public string Fname { get; set; }
        public bool FflagExpire { get; set; }

        public virtual ICollection<TrsappScenariosAction> TrsappScenariosActions { get; set; }
    }
}
