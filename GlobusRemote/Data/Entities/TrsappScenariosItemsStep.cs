using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappScenariosItemsStep
    {
        public TrsappScenariosItemsStep()
        {
            TrsappScenariosItems = new HashSet<TrsappScenariosItem>();
        }

        public int Fid { get; set; }
        public short FkParent { get; set; }
        public string Fname { get; set; }
        public byte Fposition { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual TrsappScenario FkParentNavigation { get; set; }
        public virtual ICollection<TrsappScenariosItem> TrsappScenariosItems { get; set; }
    }
}
