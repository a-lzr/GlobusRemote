using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsdirAccTemplatesAccessType
    {
        public TrsdirAccTemplatesAccessType()
        {
            TrsaccTemplatesLinksAccesses = new HashSet<TrsaccTemplatesLinksAccess>();
        }

        public short Fid { get; set; }
        public byte FkGroup { get; set; }
        public string Fname { get; set; }
        public bool FflagExpire { get; set; }

        public virtual TrsdirAccTemplatesAccessGroup FkGroupNavigation { get; set; }
        public virtual ICollection<TrsaccTemplatesLinksAccess> TrsaccTemplatesLinksAccesses { get; set; }
    }
}
