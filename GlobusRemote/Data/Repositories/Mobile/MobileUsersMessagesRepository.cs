using GlobusRemote.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Data.Repositories.Mobile
{
    public class MobileUsersMessagesRepository : BaseRepository<TrsappUsersMsg>
    {
        public MobileUsersMessagesRepository(MainDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}