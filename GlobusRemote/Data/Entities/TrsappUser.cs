using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsappUser : BaseEntity
    {
        public TrsappUser()
        {
            TrsappUsersContacts = new HashSet<TrsappUsersContact>();
            TrsappUsersMsgs = new HashSet<TrsappUsersMsg>();
        }

        public int Fid { get; set; }
        public string Fcode { get; set; }
        public string Fphone { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual TrsappUsersMission TrsappUsersMission { get; set; }
        public virtual TrsappUsersTemplatesLink TrsappUsersTemplatesLink { get; set; }
        public virtual ICollection<TrsappUsersContact> TrsappUsersContacts { get; set; }
        public virtual ICollection<TrsappUsersMsg> TrsappUsersMsgs { get; set; }
    }
}
