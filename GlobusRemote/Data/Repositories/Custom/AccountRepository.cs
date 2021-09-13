using GlobusRemote.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Data.Repositories.Custom
{
    public class AccountRepository : BaseRepository<TrsaccUser>
    {
        public AccountRepository(MainDbContext dbContext)
            : base(dbContext)
        {

        }

        public TrsaccUser Get(long id)
        {
            return _dbSet
                .SingleOrDefault(x => x.Fid == id);
        }

        public TrsaccUser Get(string login, string password)
        {
            return _dbSet
                .SingleOrDefault(x => x.Fname == login && x.Fpassword == password);
        }
    }
}
