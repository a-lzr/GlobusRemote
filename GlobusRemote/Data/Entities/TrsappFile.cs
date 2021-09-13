using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappFile : BaseEntity
    {
        public TrsappFile()
        {
            //TrsappScenariosGroupsItems = new HashSet<TrsappScenariosGroupsItem>();
            //TrsappScenariosInstructions = new HashSet<TrsappScenariosInstruction>();
            //TrsappUsersMissionsFiles = new HashSet<TrsappUsersMissionsFile>();
        }

        public long Fid { get; set; }
        public byte FkType { get; set; }
        public string Fname { get; set; }
        public string Fextention { get; set; }
        public int Fsize { get; set; }
        public byte[] Fbody { get; set; }
        public byte[] Fhash { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual TrsdirAppFilesType FkTypeNavigation { get; set; }
        //public virtual ICollection<TrsappScenariosGroupsItem> TrsappScenariosGroupsItems { get; set; }
        //public virtual ICollection<TrsappScenariosInstruction> TrsappScenariosInstructions { get; set; }
        //public virtual ICollection<TrsappUsersMissionsFile> TrsappUsersMissionsFiles { get; set; }
    }
}
