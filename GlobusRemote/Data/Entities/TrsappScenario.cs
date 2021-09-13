using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappScenario : BaseEntity
    {
        public TrsappScenario()
        {
            TrsappScenariosGroupsItems = new HashSet<TrsappScenariosGroupsItem>();
            TrsappScenariosInstructions = new HashSet<TrsappScenariosInstruction>();
            TrsappScenariosItems = new HashSet<TrsappScenariosItem>();
            TrsappScenariosItemsSteps = new HashSet<TrsappScenariosItemsStep>();
        }

        public short Fid { get; set; }
        public short FkType { get; set; }
        public string Fname { get; set; }
        public bool FflagInputDateManual { get; set; }
        public bool FflagSendConfirm { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual TrsdirAppScenariosType FkTypeNavigation { get; set; }
        public virtual ICollection<TrsappScenariosGroupsItem> TrsappScenariosGroupsItems { get; set; }
        public virtual ICollection<TrsappScenariosInstruction> TrsappScenariosInstructions { get; set; }
        public virtual ICollection<TrsappScenariosItem> TrsappScenariosItems { get; set; }
        public virtual ICollection<TrsappScenariosItemsStep> TrsappScenariosItemsSteps { get; set; }
    }
}
