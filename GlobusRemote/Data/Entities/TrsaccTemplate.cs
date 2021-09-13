using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsaccTemplate : BaseEntity
    {
        public TrsaccTemplate()
        {
            TrsaccTemplatesLinksAccesses = new HashSet<TrsaccTemplatesLinksAccess>();
            TrsaccUsersLinksTemplates = new HashSet<TrsaccUsersLinksTemplate>();
        }

        public short Fid { get; set; }
        public string Fname { get; set; }
        public bool FflagExpire { get; set; }

        public virtual ICollection<TrsaccTemplatesLinksAccess> TrsaccTemplatesLinksAccesses { get; set; }
        public virtual ICollection<TrsaccUsersLinksTemplate> TrsaccUsersLinksTemplates { get; set; }
    }
}
