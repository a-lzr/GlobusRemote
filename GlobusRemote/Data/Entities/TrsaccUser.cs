using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsaccUser : BaseEntity
    {
        public TrsaccUser()
        {
            TrsaccUsersLinksTemplates = new HashSet<TrsaccUsersLinksTemplate>();
        }

        public int Fid { get; set; }
        public string FkLanguage { get; set; }
        public string Fname { get; set; }
        public string Fpassword { get; set; }
        public bool FflagAdmin { get; set; }
        public DateTime FdateStart { get; set; }
        public DateTime? FdateFinish { get; set; }
        public bool FflagExpire { get; set; }

        public virtual TrsdirLanguage FkLanguageNavigation { get; set; }
        public virtual ICollection<TrsaccUsersLinksTemplate> TrsaccUsersLinksTemplates { get; set; }
    }
}
