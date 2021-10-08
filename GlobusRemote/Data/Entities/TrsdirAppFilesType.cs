using System;
using System.Collections.Generic;

#nullable disable

namespace GlobusRemote.Data.Entities
{
    public partial class TrsdirAppFilesType : BaseEntity
    {
        public TrsdirAppFilesType()
        {
            TrsappFiles = new HashSet<TrsappFile>();
        }

        public byte Fid { get; set; }
        public string Fname { get; set; }
        public string Ffilter { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }

        public virtual ICollection<TrsappFile> TrsappFiles { get; set; }

        public override object GetId()
        {
            if (Fid == default(byte))
            {
                return null;
            }
            return Fid;
        }

        public override bool IsEqual(object Id)
        {
            if (Id == null)
            {
                return false;
            }
            return Fid == (long)Id;
        }
    }
}
