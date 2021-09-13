using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsdirAppUsersMsgsType
    {
        public TrsdirAppUsersMsgsType()
        {
            TrsappUsersMsgs = new HashSet<TrsappUsersMsg>();
        }

        public byte Fid { get; set; }
        public string Fname { get; set; }
        public bool FflagExpire { get; set; }

        public virtual ICollection<TrsappUsersMsg> TrsappUsersMsgs { get; set; }
    }
}
