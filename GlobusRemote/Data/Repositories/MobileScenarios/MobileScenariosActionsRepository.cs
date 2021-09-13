using GlobusRemote.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Data.Repositories.MobileScenarios
{
    public class MobileScenariosActionsRepository : BaseRepository<TrsappScenariosAction>
    {
        public MobileScenariosActionsRepository(MainDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}