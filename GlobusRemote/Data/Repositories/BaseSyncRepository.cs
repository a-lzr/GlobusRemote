using GlobusRemote.Data.Entities;
using System;

namespace GlobusRemote.Data.Repositories
{
    public abstract class BaseSyncRepository<Entity> : BaseRepository<Entity>
        where Entity : BaseSyncEntity
    {
        public BaseSyncRepository(MainDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
