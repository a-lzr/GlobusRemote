using GlobusRemote.Data.Const;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Services
{
    public class LocalizeMidlleware
    {
        private readonly RequestDelegate _next;

        public LocalizeMidlleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var accountService = context
                .RequestServices.GetService(typeof(AccountService)) as AccountService;

            const string langCookieName = "lang";
            var langCookieValue = context.Request.Cookies[langCookieName];
            var language = Langs.Ru;
            var account = accountService.GetCurrent();

            if (langCookieValue != null)
            {
                language = langCookieValue;
                if (account != null && language != account.FkLanguage)
                {
                    accountService.ChangeLanguage(account, language);
                }
            }
            else if (account != null)
            {
                language = account.FkLanguage;
                if (language != langCookieValue)
                {
                    context.Response.Cookies.Append(langCookieName, language);
                }
            }

            switch (language)
            {
                case Langs.Ru:
                    CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("ru-RU");
                    break;
                case Langs.En:
                    CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-EN");
                    break;
            }

            await _next(context);
        }
    }
}
