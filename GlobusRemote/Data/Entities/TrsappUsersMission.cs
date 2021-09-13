using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappUsersMission : BaseEntity
    {
        public TrsappUsersMission()
        {
            TrsappUsersMissionsFiles = new HashSet<TrsappUsersMissionsFile>();
            TrsappUsersMissionsItems = new HashSet<TrsappUsersMissionsItem>();
        }

        public long Fid { get; set; }
        public int FkParent { get; set; }
        public bool FflagCurrent { get; set; }
        public bool FflagNext { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual TrsappUser FkParentNavigation { get; set; }
        public virtual ICollection<TrsappUsersMissionsFile> TrsappUsersMissionsFiles { get; set; }
        public virtual ICollection<TrsappUsersMissionsItem> TrsappUsersMissionsItems { get; set; }
    }
}
