using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappScenariosItem
    {
        public int Fid { get; set; }
        public short FkParent { get; set; }
        public int FkLink { get; set; }
        public int? FkStep { get; set; }
        public string Fcode { get; set; }
        public short? Fposition { get; set; }
        public bool FflagRequired { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual TrsappScenariosAction FkLinkNavigation { get; set; }
        public virtual TrsappScenario FkParentNavigation { get; set; }
        public virtual TrsappScenariosItemsStep FkStepNavigation { get; set; }
    }
}
