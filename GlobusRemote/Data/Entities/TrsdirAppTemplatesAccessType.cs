using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsdirAppTemplatesAccessType
    {
        public TrsdirAppTemplatesAccessType()
        {
            TrsappTemplatesLinksAccesses = new HashSet<TrsappTemplatesLinksAccess>();
        }

        public short Fid { get; set; }
        public string Fcomment { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual ICollection<TrsappTemplatesLinksAccess> TrsappTemplatesLinksAccesses { get; set; }
    }
}
