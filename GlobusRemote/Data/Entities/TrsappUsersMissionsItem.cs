using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappUsersMissionsItem
    {
        public TrsappUsersMissionsItem()
        {
            TrsappUsersMissionsItemsSigneds = new HashSet<TrsappUsersMissionsItemsSigned>();
        }

        public long Fid { get; set; }
        public long FkParent { get; set; }
        public int FkLink { get; set; }
        public string Fname { get; set; }
        public string Fdescription { get; set; }
        public short? Fposition { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual TrsappScenariosGroup FkLinkNavigation { get; set; }
        public virtual TrsappUsersMission FkParentNavigation { get; set; }
        public virtual ICollection<TrsappUsersMissionsItemsSigned> TrsappUsersMissionsItemsSigneds { get; set; }
    }
}
