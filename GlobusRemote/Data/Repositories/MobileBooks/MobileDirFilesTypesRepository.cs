using GlobusRemote.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Data.Repositories.MobileBooks
{
    public class MobileDirFilesTypesRepository : BaseRepository<TrsdirAppFilesType>
    {
        public MobileDirFilesTypesRepository(MainDbContext dbContext)
            : base(dbContext)
        {

        }

        public List<SelectListItem> GetTypes()
        {
            return _dbSet
                .Where(x => !x.FflagExpire)
                .ToList()
                .Select(x => new SelectListItem()
                {
                    Text = x.Fname,
                    Value = x.Fid.ToString()
                })
                .ToList();
        }
    }
}
