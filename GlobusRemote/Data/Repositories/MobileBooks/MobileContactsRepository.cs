using GlobusRemote.Data.Entities;
using System.Linq;

namespace GlobusRemote.Data.Repositories.MobileBooks
{
    public class MobileContactsRepository : BaseRepository<TrsdirAppContact>
    {
        public MobileContactsRepository(MainDbContext dbContext)
            : base(dbContext)
        {
        
        }

        protected override IQueryable<TrsdirAppContact> ApplyFiltering(IQueryable<TrsdirAppContact> query, string search)
        {
            return query.Where(x => x.Fname.Contains(search) || x.Fcomment.Contains(search));
        }
    }
}