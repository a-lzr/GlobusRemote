using GlobusRemote.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Data.Repositories.MobileScenarios
{
    public class MobileScenariosGroupsRepository : BaseRepository<TrsappScenariosGroup>
    {
        public MobileScenariosGroupsRepository(MainDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}