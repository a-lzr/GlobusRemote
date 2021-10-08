using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappScenariosAction : BaseEntity
    {
        public TrsappScenariosAction()
        {
            TrsappScenariosActionsValues = new HashSet<TrsappScenariosActionsValue>();
            TrsappScenariosItems = new HashSet<TrsappScenariosItem>();
        }

        public int Fid { get; set; }
        public short? FkGroup { get; set; }
        public short FkType { get; set; }
        public string Fname { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual TrsdirAppScenariosActionsGroup FkGroupNavigation { get; set; }
        public virtual TrsdirAppScenariosActionsType FkTypeNavigation { get; set; }
        public virtual ICollection<TrsappScenariosActionsValue> TrsappScenariosActionsValues { get; set; }
        public virtual ICollection<TrsappScenariosItem> TrsappScenariosItems { get; set; }

        public override object GetId()
        {
            return Fid;
        }

        public override bool IsEqual(object Id)
        {
            return Fid == (int)Id;
        }
    }
}
