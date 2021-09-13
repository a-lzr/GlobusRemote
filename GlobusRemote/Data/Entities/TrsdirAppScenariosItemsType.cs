using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsdirAppScenariosItemsType
    {
        public TrsdirAppScenariosItemsType()
        {
            TrsappScenariosGroupsItems = new HashSet<TrsappScenariosGroupsItem>();
        }

        public byte Fid { get; set; }
        public string Fname { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual ICollection<TrsappScenariosGroupsItem> TrsappScenariosGroupsItems { get; set; }
    }
}
