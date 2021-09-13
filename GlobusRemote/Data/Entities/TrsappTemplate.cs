using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappTemplate : BaseEntity
    {
        public TrsappTemplate()
        {
            TrsappScenariosCustoms = new HashSet<TrsappScenariosCustom>();
            TrsappTemplatesLinksAccesses = new HashSet<TrsappTemplatesLinksAccess>();
            TrsappTemplatesLinksScenariosGroups = new HashSet<TrsappTemplatesLinksScenariosGroup>();
            TrsappUsersTemplatesLinks = new HashSet<TrsappUsersTemplatesLink>();
        }

        public short Fid { get; set; }
        public string Fname { get; set; }
        public string FphoneBase { get; set; }
        public int FperiodDataExchanges { get; set; }
        public int FperiodLockWithoutDataExchange { get; set; }
        public bool FflagExpire { get; set; }
        public string Fcomment { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual ICollection<TrsappScenariosCustom> TrsappScenariosCustoms { get; set; }
        public virtual ICollection<TrsappTemplatesLinksAccess> TrsappTemplatesLinksAccesses { get; set; }
        public virtual ICollection<TrsappTemplatesLinksScenariosGroup> TrsappTemplatesLinksScenariosGroups { get; set; }
        public virtual ICollection<TrsappUsersTemplatesLink> TrsappUsersTemplatesLinks { get; set; }
    }
}
