using System;

namespace GlobusRemote.Data.Entities
{
    public abstract class BaseSyncEntity : BaseEntity
    {
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }
    }
}
