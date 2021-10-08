using GlobusRemote.Data.Entities;
using System.Linq;

namespace GlobusRemote.Data.Repositories.MobileBooks
{
    public class MobileFilesRepository : BaseSyncRepository<TrsappFile>
    {
        public MobileFilesRepository(MainDbContext dbContext)
            : base(dbContext)
        {

        }

        public override TrsappFile Get(object id)
        {
            return _dbSet.SingleOrDefault(x => x.Fid == (long)id);
        }

        protected override IQueryable<TrsappFile> ApplyFiltering(IQueryable<TrsappFile> query, string search)
        {
            return query.Where(x => x.Fname.Contains(search) || x.FkTypeNavigation.Fname.Contains(search));
        }
    }
}