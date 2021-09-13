using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsdirLanguage
    {
        public TrsdirLanguage()
        {
            TrsaccUsers = new HashSet<TrsaccUser>();
        }

        public string Fid { get; set; }
        public bool FflagDefault { get; set; }
        public bool FflagExpire { get; set; }

        public virtual ICollection<TrsaccUser> TrsaccUsers { get; set; }
    }
}
