using GlobusRemote.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Data.Repositories.Admin
{
    public class OperatorsRepository : BaseRepository<TrsaccUser>
    {
        public OperatorsRepository(MainDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}