using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsdirAppContact : BaseEntity
    {
        public TrsdirAppContact()
        {
            TrsdirAppContactsLinks = new HashSet<TrsdirAppContactsLink>();
            TrsappUsersContacts = new HashSet<TrsappUsersContact>();
        }

        public int Fid { get; set; }
        public string Fcode { get; set; }
        public string Fname { get; set; }
        public string Fcomment { get; set; }
        public byte FlinkGroup { get; set; }
        public long FlinkId { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual ICollection<TrsdirAppContactsLink> TrsdirAppContactsLinks { get; set; }
        public virtual ICollection<TrsappUsersContact> TrsappUsersContacts { get; set; }
    }
}
