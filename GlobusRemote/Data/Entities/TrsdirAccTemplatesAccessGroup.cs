using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsdirAccTemplatesAccessGroup
    {
        public TrsdirAccTemplatesAccessGroup()
        {
            TrsdirAccTemplatesAccessTypes = new HashSet<TrsdirAccTemplatesAccessType>();
        }

        public byte Fid { get; set; }
        public string Fname { get; set; }

        public virtual ICollection<TrsdirAccTemplatesAccessType> TrsdirAccTemplatesAccessTypes { get; set; }
    }
}
