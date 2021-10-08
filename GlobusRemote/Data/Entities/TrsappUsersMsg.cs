using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappUsersMsg : BaseEntity
    {
        public TrsappUsersMsg()
        {
            TrsappUsersMissionsItemsSigneds = new HashSet<TrsappUsersMissionsItemsSigned>();
            TrsappUsersMsgsItems = new HashSet<TrsappUsersMsgsItem>();
            TrsappUsersMsgsSigneds = new HashSet<TrsappUsersMsgsSigned>();
        }

        public long Fid { get; set; }
        public int FkParent { get; set; }
        public int FkScenario { get; set; }
        public byte FkType { get; set; }
        public string FcodeResponse { get; set; }
        public DateTime Fdate { get; set; }
        public string Ftext { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual TrsappUser FkParentNavigation { get; set; }
        public virtual TrsappScenariosGroup FkScenarioNavigation { get; set; }
        public virtual TrsdirAppUsersMsgsType FkTypeNavigation { get; set; }
        public virtual ICollection<TrsappUsersMissionsItemsSigned> TrsappUsersMissionsItemsSigneds { get; set; }
        public virtual ICollection<TrsappUsersMsgsItem> TrsappUsersMsgsItems { get; set; }
        public virtual ICollection<TrsappUsersMsgsSigned> TrsappUsersMsgsSigneds { get; set; }

        public override object GetId()
        {
            return Fid;
        }

        public override bool IsEqual(object Id)
        {
            return Fid == (long)Id;
        }
    }
}
