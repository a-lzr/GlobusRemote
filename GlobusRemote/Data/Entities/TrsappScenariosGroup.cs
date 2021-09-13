using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappScenariosGroup : BaseEntity
    {
        public TrsappScenariosGroup()
        {
            TrsappScenariosGroupsItems = new HashSet<TrsappScenariosGroupsItem>();
            TrsappTemplatesLinksScenariosGroups = new HashSet<TrsappTemplatesLinksScenariosGroup>();
            TrsappUsersMissionsItems = new HashSet<TrsappUsersMissionsItem>();
            TrsappUsersMissionsItemsSigneds = new HashSet<TrsappUsersMissionsItemsSigned>();
            TrsappUsersMsgs = new HashSet<TrsappUsersMsg>();
        }

        public int Fid { get; set; }
        public short FkType { get; set; }
        public string Fname { get; set; }
        public bool FflagDefault { get; set; }
        public bool FflagExpire { get; set; }
        public string Fcomment { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual TrsdirAppScenariosGroupsType FkTypeNavigation { get; set; }
        public virtual ICollection<TrsappScenariosGroupsItem> TrsappScenariosGroupsItems { get; set; }
        public virtual ICollection<TrsappTemplatesLinksScenariosGroup> TrsappTemplatesLinksScenariosGroups { get; set; }
        public virtual ICollection<TrsappUsersMissionsItem> TrsappUsersMissionsItems { get; set; }
        public virtual ICollection<TrsappUsersMissionsItemsSigned> TrsappUsersMissionsItemsSigneds { get; set; }
        public virtual ICollection<TrsappUsersMsg> TrsappUsersMsgs { get; set; }
    }
}
