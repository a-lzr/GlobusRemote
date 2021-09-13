using GlobusRemote.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Data.Repositories.Custom
{
    public class OperatorsTemplatesRepository : BaseRepository<TrsaccTemplate>
    {
        public OperatorsTemplatesRepository(MainDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
