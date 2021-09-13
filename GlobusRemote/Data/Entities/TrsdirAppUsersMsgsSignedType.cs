using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsdirAppUsersMsgsSignedType
    {
        public TrsdirAppUsersMsgsSignedType()
        {
            TrsappUsersMsgsSigneds = new HashSet<TrsappUsersMsgsSigned>();
        }

        public byte Fid { get; set; }
        public string Fname { get; set; }
        public bool FflagIn { get; set; }
        public bool FflagExpire { get; set; }

        public virtual ICollection<TrsappUsersMsgsSigned> TrsappUsersMsgsSigneds { get; set; }
    }
}
