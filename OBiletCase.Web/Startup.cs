using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OBiletCase.Business.Concrete;
using OBiletCase.Business.Interfaces;
using OBiletCase.Web.Facade.Interfaces;
using OBiletCase.Web.Middlewares;
using OBiletCase.Web.Tools;
using OBiletCase.Web.Tools.Facade.Concrete;
using OBiletCase.Web.Tools.Session;

namespace OBiletCase.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            services.AddMemoryCache();
            services.AddHttpClient<ISessionApiService, SessionApiManager>();
            services.AddHttpClient<IBusLocationApiService, BusLocationApiManager>();
            services.AddHttpClient<IBusJourneyApiService, BusJourneyApiManager>();
            services.AddSingleton<IClientData, ClientData>();
            services.AddSingleton<IApiFacade, ApiFacade>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseRouting();
            app.UseSession();
            app.UseStaticFiles();

            //ilgili servisten device ve session idleri elde edilip, session olarak kayýt edilir. Bu bilgiler app içinde yapýlacak api call'larda body içerisinde post edilecek.
            app.UseMiddleware<SessionMw>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
