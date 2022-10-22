using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using SinDarElaMobile.Data;

using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;

namespace SinDarElaMobile
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        partial void OnConfigureServices(IServiceCollection services);

        partial void OnConfiguringServices(IServiceCollection services);

        public void ConfigureServices(IServiceCollection services)
        {
            OnConfiguringServices(services);

            services.AddHttpContextAccessor();
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowAny",
                    x =>
                    {
                        x.AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(isOriginAllowed: _ => true)
                        .AllowCredentials();
                    });
            });
            var oDataBuilder = new ODataConventionModelBuilder();

            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.AbrechnungBasis>("AbrechnungBases");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.AbrechnungKundenReststunden>("AbrechnungKundenReststundens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.Aufgaben>("Aufgabens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.AuswahlJahr>("AuswahlJahrs");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.AuswahlMonat>("AuswahlMonats");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.Base>("Bases");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.BaseAnreden>("BaseAnredens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.BaseKontakte>("BaseKontaktes");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.Benutzer>("Benutzers");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.BenutzerModule>("BenutzerModules");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.BenutzerProtokoll>("BenutzerProtokolls");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.Debugg>("Debuggs");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.DeviceCode>("DeviceCodes");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.Dokumente>("Dokumentes");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.DokumenteKategorien>("DokumenteKategoriens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.Ereignisse>("Ereignisses");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.EreignisseArten>("EreignisseArtens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.EreignisseSonderurlaubArten>("EreignisseSonderurlaubArtens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmer>("EreignisseTeilnehmers");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmerStatus>("EreignisseTeilnehmerStatuses");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.Feedback>("Feedbacks");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.Firmen>("Firmens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten>("FirmenMitarbeiterTaetigkeitens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml>("InfotexteHtmls");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.Kunden>("Kundens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.KundenKontakte>("KundenKontaktes");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.KundenKontakteArten>("KundenKontakteArtens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungArten>("KundenLeistungArtens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungen>("KundenLeistungens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheide>("KundenLeistungenBescheides");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideKontingente>("KundenLeistungenBescheideKontingentes");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideStatus>("KundenLeistungenBescheideStatuses");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuer>("KundenLeistungenBetreuers");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuerArten>("KundenLeistungenBetreuerArtens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.KundenStatus>("KundenStatuses");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.Mitarbeiter>("Mitarbeiters");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterArten>("MitarbeiterArtens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFirmen>("MitarbeiterFirmens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungen>("MitarbeiterFortbildungens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungenArten>("MitarbeiterFortbildungenArtens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudget>("MitarbeiterKundenbudgets");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien>("MitarbeiterKundenbudgetKategoriens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterStatus>("MitarbeiterStatuses");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeiten>("MitarbeiterTaetigkeitens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeitenArten>("MitarbeiterTaetigkeitenArtens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaub>("MitarbeiterUrlaubs");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubDetail>("MitarbeiterUrlaubDetails");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch>("MitarbeiterUrlaubKumuliertAnspruches");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten>("MitarbeiterUrlaubKumuliertDienstzeitens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten>("MitarbeiterVerlaufDienstzeitens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten>("MitarbeiterVerlaufDienstzeitenArtens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufGehalt>("MitarbeiterVerlaufGehalts");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit>("MitarbeiterVerlaufNormalarbeitszeits");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.Mitteilungen>("Mitteilungens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.MitteilungenVerteiler>("MitteilungenVerteilers");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.Module>("Modules");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.Notizen>("Notizens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.Protokoll>("Protokolls");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.RegelnAbwesenheiten>("RegelnAbwesenheitens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.VwBaseAlle>("VwBaseAlles");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.VwBaseKontakte>("VwBaseKontaktes");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.VwBaseOrte>("VwBaseOrtes");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.VwBasePlz>("VwBasePlzs");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.VwBenutzerBase>("VwBenutzerBases");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.VwKundenBetreuer>("VwKundenBetreuers");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.VwKundenUndBetreuerAuswahl>("VwKundenUndBetreuerAuswahls");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiter>("VwMitarbeiters");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterFirmen>("VwMitarbeiterFirmens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterKunden>("VwMitarbeiterKundens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterNeu>("VwMitarbeiterNeus");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterSuchen>("VwMitarbeiterSuchens");
            oDataBuilder.EntitySet<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterTaetigkeiten>("VwMitarbeiterTaetigkeitens");

            this.OnConfigureOData(oDataBuilder);


            var model = oDataBuilder.GetEdmModel();
            services.AddControllers().AddOData(opt => { 
              opt.AddRouteComponents("odata/dbSinDarEla", model).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
            });

            

            services.AddDbContext<SinDarElaMobile.Data.DbSinDarElaContext>(options =>
            {
              options.UseMySql(Configuration.GetConnectionString("dbSinDarElaConnection"), ServerVersion.AutoDetect(Configuration.GetConnectionString("dbSinDarElaConnection")));
            });

            services.AddRazorPages();

            OnConfigureServices(services);
        }

        partial void OnConfigure(IApplicationBuilder app, IWebHostEnvironment env);
        partial void OnConfigureOData(ODataConventionModelBuilder builder);
        partial void OnConfiguring(IApplicationBuilder app, IWebHostEnvironment env);

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            OnConfiguring(app, env);
            if (env.IsDevelopment())
            {
                Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.Use((ctx, next) =>
                {
                    ctx.Request.Scheme = "https";
                    return next();
                });
            }
            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            IServiceProvider provider = app.ApplicationServices.GetRequiredService<IServiceProvider>();
            app.UseCors("AllowAny");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });

            OnConfigure(app, env);
        }
    }


}
