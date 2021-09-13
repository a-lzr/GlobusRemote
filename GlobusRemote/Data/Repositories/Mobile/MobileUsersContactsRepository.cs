using GlobusRemote.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Data.Repositories.Mobile
{
    public class MobileUsersContactsRepository : BaseRepository<TrsappUsersContact>
    {
        public MobileUsersContactsRepository(MainDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}