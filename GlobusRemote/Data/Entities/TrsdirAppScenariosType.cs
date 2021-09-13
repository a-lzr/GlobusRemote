using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsdirAppScenariosType
    {
        public TrsdirAppScenariosType()
        {
            TrsappScenarios = new HashSet<TrsappScenario>();
            TrsappScenariosCustoms = new HashSet<TrsappScenariosCustom>();
        }

        public short Fid { get; set; }
        public string Fname { get; set; }
        public bool FflagCustom { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual ICollection<TrsappScenario> TrsappScenarios { get; set; }
        public virtual ICollection<TrsappScenariosCustom> TrsappScenariosCustoms { get; set; }
    }
}
