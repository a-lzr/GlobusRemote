using GlobusRemote.Data.Entities;
using GlobusRemote.Data.Repositories.Custom;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace GlobusRemote.Services
{
    public class AccountService
    {
        private AccountRepository _accountRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public AccountService(AccountRepository accountRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _accountRepository = accountRepository;
            _httpContextAccessor = httpContextAccessor;           
        }

        public TrsaccUser GetCurrent()
        {
            var idStr = _httpContextAccessor
                .HttpContext
                .User
                .Claims
                .SingleOrDefault(x => x.Type == "Id")
                ?.Value;

            if (string.IsNullOrEmpty(idStr))
            {
                return null;
            }

            var id = int.Parse(idStr);
            return _accountRepository.Get(id);
        }

        public void ChangeLanguage(TrsaccUser target, string language)
        {
            target.FkLanguage = language;
            _accountRepository.Save(target);            
        }
    }
}
