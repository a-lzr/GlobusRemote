using AutoMapper;
using AutoMapper.Configuration;
using GlobusRemote.Areas.Admin.Models;
using GlobusRemote.Areas.Mobile.Models;
using GlobusRemote.Areas.MobileBooks.Models;
using GlobusRemote.Data;
using GlobusRemote.Data.Entities;
using GlobusRemote.Data.Repositories;
using GlobusRemote.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.HttpOverrides;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace GlobusRemote
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public const string AuthName = "GlobusRemoteCoockie";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Scaffold-DbContext "Data Source=192.168.12.1;Initial Catalog=SrvService;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data\Entities2 -Context MainDbContext -Force
            var connectString = Configuration.GetValue<string>("ConnectString");
            services.AddDbContext<MainDbContext>(optionsBuilder => optionsBuilder.UseSqlServer(connectString));

            services.AddAuthentication(AuthName)
                .AddCookie(AuthName, config =>
                {
                    config.LoginPath = "/Home/Index";
                    config.LogoutPath = "/Account/Logout";
                    config.AccessDeniedPath = "/User/Denied";
                    //                    options.ReturnUrlParameter = cookiesConfig.ReturnUrlParameter;
                    config.Cookie.Name = "GlobusRemote";
                });

            services.AddLocalization(options => options.ResourcesPath = "Localize");
            services.AddControllersWithViews()
                .AddDataAnnotationsLocalization() // добавляем локализацию аннотаций;
                .AddViewLocalization();

            registerRepositories(services);

            registerMapper(services);

            registerServices(services);

            services.AddControllersWithViews()
                .AddViewLocalization();

            services.AddHttpContextAccessor();
//            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.GetRequiredService

            //services.AddScoped(serviceProvider => {
            //    var httpContext = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;

            //    if (httpContext == null)
            //    {
            //        // Разрешение сервиса происходит не в рамках HTTP запроса
            //        return null;
            //    }

            //    // Можно использовать любые данные запроса
            //    var queryString = httpContext.Request.Query;
            //    var requestHeaders = httpContext.Request.Headers;

            //    return requestHeaders.ContainsKey("Use-local")
            //        ? serviceProvider.GetService<LocalhostService>() as IService
            //        : serviceProvider.GetService<CloudService>() as IService;
            //});

            //services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            //services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<LocalService>();
            //services.AddScoped<CloudService>();

            //services.AddScoped<IService>(serviceProvider => {
            //    var httpContext = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            //    httpContext.HttpContext.Request.HttpContext

            //    return httpContext.IsLocalRequest() // IsLocalRequest() is a custom extension method, not a part of ASP.NET Core
            //        ? serviceProvider.GetService<LocalService>()
            //        : serviceProvider.GetService<CloudService>();
            //});
        }

        private void registerRepositories(IServiceCollection services)
        {
            var assembly = Assembly.GetAssembly(typeof(BaseRepository<>));

            var repositories = assembly.GetTypes()
                .Where(x =>
                    x.IsClass
                    && !x.IsAbstract
                    && x.BaseType.IsGenericType
                    && (x.BaseType.GetGenericTypeDefinition() == typeof(BaseRepository<>) || x.BaseType.GetGenericTypeDefinition() == typeof(BaseSyncRepository<>)));

            foreach (var repositoryType in repositories)
            {
                services.RegisterScoped(repositoryType);
            }
        }

        private void registerMapper(IServiceCollection services)
        {
            var provider = new MapperConfigurationExpression();

            // admin area
            provider.CreateMap<TrsaccUser, OperatorsListViewModel>();
            provider.CreateMap<TrsaccTemplate, OperatorsTemplatesListViewModel>();

            // mobile area
            provider.CreateMap<TrsappUser, UsersListViewModel>();

            // mobile scenarios area

            // mobile books area

            provider.CreateMap<TrsdirAppContactsLink, ContactsLinksItemViewModel>();

            provider.CreateMap<TrsdirAppContact, ContactsItemViewModel>()
                .ForMember(
                    nameof(ContactsItemViewModel.ContactsLinks),
                    config => config.MapFrom(item => item.TrsdirAppContactsLinks));

            provider.CreateMap<TrsappFile, FilesItemViewModel>()
                .ForMember(
                    nameof(FilesItemViewModel.FtypeName),
                    config => config.MapFrom(item => item.FkTypeNavigation.Fname))
                .ForMember(
                    nameof(FilesItemViewModel.FsizeInKb),
                    config => config.MapFrom(item => Math.Round((double) item.Fsize / 1024, 2)));

            provider.CreateMap<TrsappFile, FilesEditViewModel>()
                .ForMember(
                    nameof(FilesItemViewModel.FsizeInKb),
                    config => config.MapFrom(item => Math.Round((double)item.Fsize / 1024, 2)));

            provider.CreateMap<FilesEditViewModel, TrsappFile>();
                //.ForMember(
                //    nameof(TrsappFile.FtypeName),
                //    config => config.MapFrom(item => item.FkTypeNavigation.Fname))
                //.ForMember(
                //    nameof(TrsappFile.FsizeInKb),
                //    config => config.MapFrom(item => Math.Round((double)item.Fsize / 1024, 2)));

            var mapperConfiguration = new MapperConfiguration(provider);
            var mapper = new Mapper(mapperConfiguration);

            services.AddScoped<IMapper>(x => mapper);
        }

        private void registerServices(IServiceCollection services)
        {
            services.RegisterScoped<AccountService>();

            //services.AddTransient<IAccountService, AccountService>();

            //services.AddScoped<AccountService>(container =>
            //    new AccountService(
            //        container.GetService<AccountRepository>(),
            //        container.GetService<IHttpContextAccessor>()
            //    )
            //);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var pathAll = Path.Combine(path, "Logs", $"{DateTime.Today.ToString("yyyy-MM-dd")}.log");
            var pathErrors = Path.Combine(path, "Errors", $"{DateTime.Today.ToString("yyyy-MM-dd")}.log");
            loggerFactory.AddFile(pathAll);
            loggerFactory.AddFile(pathErrors, LogLevel.Error);

            app.UseMiddleware<GlobalExceptionHandlerMidlleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-2.1&tabs=visual-studio#http-strict-transport-security-protocol-hsts
                app.UseHsts();
            }

            //var supportedCultures = new[]
            //{
            //    new CultureInfo("en-EN"),
            //    new CultureInfo("ru-RU"),
            //};
            //app.UseRequestLocalization(new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture("ru-RU"),
            //    SupportedCultures = supportedCultures,
            //    SupportedUICultures = supportedCultures
            //});

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<LocalizeMidlleware>();

            app.UseEndpoints(endpoints =>
            {
                // https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/areas?view=aspnetcore-5.0 Areas in ASP.NET Core

                // https://metanit.com/sharp/mvc/4.5.php частичные представления
                endpoints.MapAreaControllerRoute(
                    name: "admin-default",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "mobile-default",
                    areaName: "Mobile",
                    pattern: "Mobile/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "mobilescenarios-default",
                    areaName: "MobileScenarios",
                    pattern: "MobileScenarios/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "mobilebooks-default",
                    areaName: "MobileBooks",
                    pattern: "MobileBooks/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
