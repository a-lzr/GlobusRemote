using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappScenariosGroupsItem
    {
        public TrsappScenariosGroupsItem()
        {
            InverseFkParentItemNavigation = new HashSet<TrsappScenariosGroupsItem>();
        }

        public long Fid { get; set; }
        public int FkParent { get; set; }
        public long? FkParentItem { get; set; }
        public byte FkType { get; set; }
        public short? FkLink { get; set; }
        public long? FkImage { get; set; }
        public string Fname { get; set; }
        public short? Fposition { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual TrsappFile FkImageNavigation { get; set; }
        public virtual TrsappScenario FkLinkNavigation { get; set; }
        public virtual TrsappScenariosGroupsItem FkParentItemNavigation { get; set; }
        public virtual TrsappScenariosGroup FkParentNavigation { get; set; }
        public virtual TrsdirAppScenariosItemsType FkTypeNavigation { get; set; }
        public virtual ICollection<TrsappScenariosGroupsItem> InverseFkParentItemNavigation { get; set; }
    }
}
