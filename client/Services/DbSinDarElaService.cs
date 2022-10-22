
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;
using SinDarElaMobile.Models.DbSinDarEla;

namespace SinDarElaMobile
{
    public partial class DbSinDarElaService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;
        public DbSinDarElaService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/dbSinDarEla/");
        }

        public async System.Threading.Tasks.Task ExportAbrechnungBasesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/abrechnungbases/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/abrechnungbases/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportAbrechnungBasesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/abrechnungbases/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/abrechnungbases/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetAbrechnungBases(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.AbrechnungBasis>> GetAbrechnungBases(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"AbrechnungBases");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAbrechnungBases(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.AbrechnungBasis>>(response);
        }
        partial void OnCreateAbrechnungBasis(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.AbrechnungBasis> CreateAbrechnungBasis(SinDarElaMobile.Models.DbSinDarEla.AbrechnungBasis abrechnungBasis = default(SinDarElaMobile.Models.DbSinDarEla.AbrechnungBasis))
        {
            var uri = new Uri(baseUri, $"AbrechnungBases");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(abrechnungBasis), Encoding.UTF8, "application/json");

            OnCreateAbrechnungBasis(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.AbrechnungBasis>(response);
        }

        public async System.Threading.Tasks.Task ExportAbrechnungKundenReststundensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/abrechnungkundenreststundens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/abrechnungkundenreststundens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportAbrechnungKundenReststundensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/abrechnungkundenreststundens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/abrechnungkundenreststundens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetAbrechnungKundenReststundens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.AbrechnungKundenReststunden>> GetAbrechnungKundenReststundens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"AbrechnungKundenReststundens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAbrechnungKundenReststundens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.AbrechnungKundenReststunden>>(response);
        }
        partial void OnCreateAbrechnungKundenReststunden(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.AbrechnungKundenReststunden> CreateAbrechnungKundenReststunden(SinDarElaMobile.Models.DbSinDarEla.AbrechnungKundenReststunden abrechnungKundenReststunden = default(SinDarElaMobile.Models.DbSinDarEla.AbrechnungKundenReststunden))
        {
            var uri = new Uri(baseUri, $"AbrechnungKundenReststundens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(abrechnungKundenReststunden), Encoding.UTF8, "application/json");

            OnCreateAbrechnungKundenReststunden(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.AbrechnungKundenReststunden>(response);
        }

        public async System.Threading.Tasks.Task ExportAufgabensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/aufgabens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/aufgabens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportAufgabensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/aufgabens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/aufgabens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetAufgabens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Aufgaben>> GetAufgabens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Aufgabens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAufgabens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Aufgaben>>(response);
        }
        partial void OnCreateAufgaben(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Aufgaben> CreateAufgaben(SinDarElaMobile.Models.DbSinDarEla.Aufgaben aufgaben = default(SinDarElaMobile.Models.DbSinDarEla.Aufgaben))
        {
            var uri = new Uri(baseUri, $"Aufgabens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(aufgaben), Encoding.UTF8, "application/json");

            OnCreateAufgaben(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Aufgaben>(response);
        }

        public async System.Threading.Tasks.Task ExportAuswahlJahrsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/auswahljahrs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/auswahljahrs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportAuswahlJahrsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/auswahljahrs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/auswahljahrs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetAuswahlJahrs(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.AuswahlJahr>> GetAuswahlJahrs(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"AuswahlJahrs");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAuswahlJahrs(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.AuswahlJahr>>(response);
        }
        partial void OnCreateAuswahlJahr(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.AuswahlJahr> CreateAuswahlJahr(SinDarElaMobile.Models.DbSinDarEla.AuswahlJahr auswahlJahr = default(SinDarElaMobile.Models.DbSinDarEla.AuswahlJahr))
        {
            var uri = new Uri(baseUri, $"AuswahlJahrs");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(auswahlJahr), Encoding.UTF8, "application/json");

            OnCreateAuswahlJahr(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.AuswahlJahr>(response);
        }

        public async System.Threading.Tasks.Task ExportAuswahlMonatsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/auswahlmonats/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/auswahlmonats/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportAuswahlMonatsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/auswahlmonats/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/auswahlmonats/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetAuswahlMonats(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.AuswahlMonat>> GetAuswahlMonats(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"AuswahlMonats");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAuswahlMonats(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.AuswahlMonat>>(response);
        }
        partial void OnCreateAuswahlMonat(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.AuswahlMonat> CreateAuswahlMonat(SinDarElaMobile.Models.DbSinDarEla.AuswahlMonat auswahlMonat = default(SinDarElaMobile.Models.DbSinDarEla.AuswahlMonat))
        {
            var uri = new Uri(baseUri, $"AuswahlMonats");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(auswahlMonat), Encoding.UTF8, "application/json");

            OnCreateAuswahlMonat(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.AuswahlMonat>(response);
        }

        public async System.Threading.Tasks.Task ExportBasesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/bases/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/bases/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportBasesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/bases/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/bases/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetBases(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Base>> GetBases(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Bases");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetBases(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Base>>(response);
        }
        partial void OnCreateBase(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Base> CreateBase(SinDarElaMobile.Models.DbSinDarEla.Base _base = default(SinDarElaMobile.Models.DbSinDarEla.Base))
        {
            var uri = new Uri(baseUri, $"Bases");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(_base), Encoding.UTF8, "application/json");

            OnCreateBase(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Base>(response);
        }

        public async System.Threading.Tasks.Task ExportBaseAnredensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/baseanredens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/baseanredens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportBaseAnredensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/baseanredens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/baseanredens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetBaseAnredens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.BaseAnreden>> GetBaseAnredens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"BaseAnredens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetBaseAnredens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.BaseAnreden>>(response);
        }
        partial void OnCreateBaseAnreden(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.BaseAnreden> CreateBaseAnreden(SinDarElaMobile.Models.DbSinDarEla.BaseAnreden baseAnreden = default(SinDarElaMobile.Models.DbSinDarEla.BaseAnreden))
        {
            var uri = new Uri(baseUri, $"BaseAnredens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(baseAnreden), Encoding.UTF8, "application/json");

            OnCreateBaseAnreden(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.BaseAnreden>(response);
        }

        public async System.Threading.Tasks.Task ExportBaseKontaktesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/basekontaktes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/basekontaktes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportBaseKontaktesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/basekontaktes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/basekontaktes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetBaseKontaktes(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.BaseKontakte>> GetBaseKontaktes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"BaseKontaktes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetBaseKontaktes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.BaseKontakte>>(response);
        }
        partial void OnCreateBaseKontakte(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.BaseKontakte> CreateBaseKontakte(SinDarElaMobile.Models.DbSinDarEla.BaseKontakte baseKontakte = default(SinDarElaMobile.Models.DbSinDarEla.BaseKontakte))
        {
            var uri = new Uri(baseUri, $"BaseKontaktes");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(baseKontakte), Encoding.UTF8, "application/json");

            OnCreateBaseKontakte(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.BaseKontakte>(response);
        }

        public async System.Threading.Tasks.Task ExportBenutzersToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/benutzers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/benutzers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportBenutzersToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/benutzers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/benutzers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetBenutzers(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Benutzer>> GetBenutzers(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Benutzers");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetBenutzers(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Benutzer>>(response);
        }
        partial void OnCreateBenutzer(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Benutzer> CreateBenutzer(SinDarElaMobile.Models.DbSinDarEla.Benutzer benutzer = default(SinDarElaMobile.Models.DbSinDarEla.Benutzer))
        {
            var uri = new Uri(baseUri, $"Benutzers");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(benutzer), Encoding.UTF8, "application/json");

            OnCreateBenutzer(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Benutzer>(response);
        }

        public async System.Threading.Tasks.Task ExportBenutzerModulesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/benutzermodules/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/benutzermodules/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportBenutzerModulesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/benutzermodules/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/benutzermodules/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetBenutzerModules(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.BenutzerModule>> GetBenutzerModules(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"BenutzerModules");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetBenutzerModules(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.BenutzerModule>>(response);
        }
        partial void OnCreateBenutzerModule(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.BenutzerModule> CreateBenutzerModule(SinDarElaMobile.Models.DbSinDarEla.BenutzerModule benutzerModule = default(SinDarElaMobile.Models.DbSinDarEla.BenutzerModule))
        {
            var uri = new Uri(baseUri, $"BenutzerModules");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(benutzerModule), Encoding.UTF8, "application/json");

            OnCreateBenutzerModule(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.BenutzerModule>(response);
        }

        public async System.Threading.Tasks.Task ExportBenutzerProtokollsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/benutzerprotokolls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/benutzerprotokolls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportBenutzerProtokollsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/benutzerprotokolls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/benutzerprotokolls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetBenutzerProtokolls(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.BenutzerProtokoll>> GetBenutzerProtokolls(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"BenutzerProtokolls");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetBenutzerProtokolls(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.BenutzerProtokoll>>(response);
        }
        partial void OnCreateBenutzerProtokoll(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.BenutzerProtokoll> CreateBenutzerProtokoll(SinDarElaMobile.Models.DbSinDarEla.BenutzerProtokoll benutzerProtokoll = default(SinDarElaMobile.Models.DbSinDarEla.BenutzerProtokoll))
        {
            var uri = new Uri(baseUri, $"BenutzerProtokolls");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(benutzerProtokoll), Encoding.UTF8, "application/json");

            OnCreateBenutzerProtokoll(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.BenutzerProtokoll>(response);
        }

        public async System.Threading.Tasks.Task ExportDebuggsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/debuggs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/debuggs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDebuggsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/debuggs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/debuggs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetDebuggs(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Debugg>> GetDebuggs(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Debuggs");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDebuggs(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Debugg>>(response);
        }
        partial void OnCreateDebugg(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Debugg> CreateDebugg(SinDarElaMobile.Models.DbSinDarEla.Debugg debugg = default(SinDarElaMobile.Models.DbSinDarEla.Debugg))
        {
            var uri = new Uri(baseUri, $"Debuggs");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(debugg), Encoding.UTF8, "application/json");

            OnCreateDebugg(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Debugg>(response);
        }

        public async System.Threading.Tasks.Task ExportDeviceCodesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/devicecodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/devicecodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDeviceCodesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/devicecodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/devicecodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetDeviceCodes(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.DeviceCode>> GetDeviceCodes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"DeviceCodes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDeviceCodes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.DeviceCode>>(response);
        }
        partial void OnCreateDeviceCode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.DeviceCode> CreateDeviceCode(SinDarElaMobile.Models.DbSinDarEla.DeviceCode deviceCode = default(SinDarElaMobile.Models.DbSinDarEla.DeviceCode))
        {
            var uri = new Uri(baseUri, $"DeviceCodes");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(deviceCode), Encoding.UTF8, "application/json");

            OnCreateDeviceCode(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.DeviceCode>(response);
        }

        public async System.Threading.Tasks.Task ExportDokumentesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/dokumentes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/dokumentes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDokumentesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/dokumentes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/dokumentes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetDokumentes(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Dokumente>> GetDokumentes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Dokumentes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDokumentes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Dokumente>>(response);
        }
        partial void OnCreateDokumente(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Dokumente> CreateDokumente(SinDarElaMobile.Models.DbSinDarEla.Dokumente dokumente = default(SinDarElaMobile.Models.DbSinDarEla.Dokumente))
        {
            var uri = new Uri(baseUri, $"Dokumentes");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(dokumente), Encoding.UTF8, "application/json");

            OnCreateDokumente(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Dokumente>(response);
        }

        public async System.Threading.Tasks.Task ExportDokumenteKategoriensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/dokumentekategoriens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/dokumentekategoriens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDokumenteKategoriensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/dokumentekategoriens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/dokumentekategoriens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetDokumenteKategoriens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.DokumenteKategorien>> GetDokumenteKategoriens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"DokumenteKategoriens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDokumenteKategoriens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.DokumenteKategorien>>(response);
        }
        partial void OnCreateDokumenteKategorien(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.DokumenteKategorien> CreateDokumenteKategorien(SinDarElaMobile.Models.DbSinDarEla.DokumenteKategorien dokumenteKategorien = default(SinDarElaMobile.Models.DbSinDarEla.DokumenteKategorien))
        {
            var uri = new Uri(baseUri, $"DokumenteKategoriens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(dokumenteKategorien), Encoding.UTF8, "application/json");

            OnCreateDokumenteKategorien(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.DokumenteKategorien>(response);
        }

        public async System.Threading.Tasks.Task ExportEreignissesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/ereignisses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/ereignisses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportEreignissesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/ereignisses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/ereignisses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetEreignisses(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Ereignisse>> GetEreignisses(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Ereignisses");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEreignisses(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Ereignisse>>(response);
        }
        partial void OnCreateEreignisse(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Ereignisse> CreateEreignisse(SinDarElaMobile.Models.DbSinDarEla.Ereignisse ereignisse = default(SinDarElaMobile.Models.DbSinDarEla.Ereignisse))
        {
            var uri = new Uri(baseUri, $"Ereignisses");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(ereignisse), Encoding.UTF8, "application/json");

            OnCreateEreignisse(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Ereignisse>(response);
        }

        public async System.Threading.Tasks.Task ExportEreignisseArtensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/ereignisseartens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/ereignisseartens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportEreignisseArtensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/ereignisseartens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/ereignisseartens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetEreignisseArtens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.EreignisseArten>> GetEreignisseArtens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"EreignisseArtens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEreignisseArtens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.EreignisseArten>>(response);
        }
        partial void OnCreateEreignisseArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.EreignisseArten> CreateEreignisseArten(SinDarElaMobile.Models.DbSinDarEla.EreignisseArten ereignisseArten = default(SinDarElaMobile.Models.DbSinDarEla.EreignisseArten))
        {
            var uri = new Uri(baseUri, $"EreignisseArtens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(ereignisseArten), Encoding.UTF8, "application/json");

            OnCreateEreignisseArten(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.EreignisseArten>(response);
        }

        public async System.Threading.Tasks.Task ExportEreignisseSonderurlaubArtensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/ereignissesonderurlaubartens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/ereignissesonderurlaubartens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportEreignisseSonderurlaubArtensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/ereignissesonderurlaubartens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/ereignissesonderurlaubartens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetEreignisseSonderurlaubArtens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.EreignisseSonderurlaubArten>> GetEreignisseSonderurlaubArtens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"EreignisseSonderurlaubArtens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEreignisseSonderurlaubArtens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.EreignisseSonderurlaubArten>>(response);
        }
        partial void OnCreateEreignisseSonderurlaubArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.EreignisseSonderurlaubArten> CreateEreignisseSonderurlaubArten(SinDarElaMobile.Models.DbSinDarEla.EreignisseSonderurlaubArten ereignisseSonderurlaubArten = default(SinDarElaMobile.Models.DbSinDarEla.EreignisseSonderurlaubArten))
        {
            var uri = new Uri(baseUri, $"EreignisseSonderurlaubArtens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(ereignisseSonderurlaubArten), Encoding.UTF8, "application/json");

            OnCreateEreignisseSonderurlaubArten(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.EreignisseSonderurlaubArten>(response);
        }

        public async System.Threading.Tasks.Task ExportEreignisseTeilnehmersToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/ereignisseteilnehmers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/ereignisseteilnehmers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportEreignisseTeilnehmersToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/ereignisseteilnehmers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/ereignisseteilnehmers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetEreignisseTeilnehmers(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmer>> GetEreignisseTeilnehmers(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"EreignisseTeilnehmers");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEreignisseTeilnehmers(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmer>>(response);
        }
        partial void OnCreateEreignisseTeilnehmer(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmer> CreateEreignisseTeilnehmer(SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmer ereignisseTeilnehmer = default(SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmer))
        {
            var uri = new Uri(baseUri, $"EreignisseTeilnehmers");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(ereignisseTeilnehmer), Encoding.UTF8, "application/json");

            OnCreateEreignisseTeilnehmer(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmer>(response);
        }

        public async System.Threading.Tasks.Task ExportEreignisseTeilnehmerStatusesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/ereignisseteilnehmerstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/ereignisseteilnehmerstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportEreignisseTeilnehmerStatusesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/ereignisseteilnehmerstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/ereignisseteilnehmerstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetEreignisseTeilnehmerStatuses(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmerStatus>> GetEreignisseTeilnehmerStatuses(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"EreignisseTeilnehmerStatuses");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEreignisseTeilnehmerStatuses(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmerStatus>>(response);
        }
        partial void OnCreateEreignisseTeilnehmerStatus(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmerStatus> CreateEreignisseTeilnehmerStatus(SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmerStatus ereignisseTeilnehmerStatus = default(SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmerStatus))
        {
            var uri = new Uri(baseUri, $"EreignisseTeilnehmerStatuses");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(ereignisseTeilnehmerStatus), Encoding.UTF8, "application/json");

            OnCreateEreignisseTeilnehmerStatus(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmerStatus>(response);
        }

        public async System.Threading.Tasks.Task ExportFeedbacksToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/feedbacks/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/feedbacks/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportFeedbacksToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/feedbacks/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/feedbacks/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetFeedbacks(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Feedback>> GetFeedbacks(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Feedbacks");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetFeedbacks(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Feedback>>(response);
        }
        partial void OnCreateFeedback(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Feedback> CreateFeedback(SinDarElaMobile.Models.DbSinDarEla.Feedback feedback = default(SinDarElaMobile.Models.DbSinDarEla.Feedback))
        {
            var uri = new Uri(baseUri, $"Feedbacks");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(feedback), Encoding.UTF8, "application/json");

            OnCreateFeedback(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Feedback>(response);
        }

        public async System.Threading.Tasks.Task ExportFirmensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/firmens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/firmens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportFirmensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/firmens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/firmens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetFirmens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Firmen>> GetFirmens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Firmens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetFirmens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Firmen>>(response);
        }
        partial void OnCreateFirmen(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Firmen> CreateFirmen(SinDarElaMobile.Models.DbSinDarEla.Firmen firmen = default(SinDarElaMobile.Models.DbSinDarEla.Firmen))
        {
            var uri = new Uri(baseUri, $"Firmens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(firmen), Encoding.UTF8, "application/json");

            OnCreateFirmen(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Firmen>(response);
        }

        public async System.Threading.Tasks.Task ExportFirmenMitarbeiterTaetigkeitensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/firmenmitarbeitertaetigkeitens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/firmenmitarbeitertaetigkeitens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportFirmenMitarbeiterTaetigkeitensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/firmenmitarbeitertaetigkeitens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/firmenmitarbeitertaetigkeitens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetFirmenMitarbeiterTaetigkeitens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten>> GetFirmenMitarbeiterTaetigkeitens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"FirmenMitarbeiterTaetigkeitens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetFirmenMitarbeiterTaetigkeitens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten>>(response);
        }
        partial void OnCreateFirmenMitarbeiterTaetigkeiten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten> CreateFirmenMitarbeiterTaetigkeiten(SinDarElaMobile.Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten firmenMitarbeiterTaetigkeiten = default(SinDarElaMobile.Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten))
        {
            var uri = new Uri(baseUri, $"FirmenMitarbeiterTaetigkeitens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(firmenMitarbeiterTaetigkeiten), Encoding.UTF8, "application/json");

            OnCreateFirmenMitarbeiterTaetigkeiten(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten>(response);
        }

        public async System.Threading.Tasks.Task ExportInfotexteHtmlsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/infotextehtmls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/infotextehtmls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportInfotexteHtmlsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/infotextehtmls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/infotextehtmls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetInfotexteHtmls(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml>> GetInfotexteHtmls(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"InfotexteHtmls");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetInfotexteHtmls(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml>>(response);
        }
        partial void OnCreateInfotexteHtml(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml> CreateInfotexteHtml(SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml infotexteHtml = default(SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml))
        {
            var uri = new Uri(baseUri, $"InfotexteHtmls");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(infotexteHtml), Encoding.UTF8, "application/json");

            OnCreateInfotexteHtml(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml>(response);
        }

        public async System.Threading.Tasks.Task ExportKundensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportKundensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetKundens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Kunden>> GetKundens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Kundens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Kunden>>(response);
        }
        partial void OnCreateKunden(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Kunden> CreateKunden(SinDarElaMobile.Models.DbSinDarEla.Kunden kunden = default(SinDarElaMobile.Models.DbSinDarEla.Kunden))
        {
            var uri = new Uri(baseUri, $"Kundens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kunden), Encoding.UTF8, "application/json");

            OnCreateKunden(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Kunden>(response);
        }

        public async System.Threading.Tasks.Task ExportKundenKontaktesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenkontaktes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenkontaktes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportKundenKontaktesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenkontaktes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenkontaktes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetKundenKontaktes(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenKontakte>> GetKundenKontaktes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"KundenKontaktes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenKontaktes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenKontakte>>(response);
        }
        partial void OnCreateKundenKontakte(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenKontakte> CreateKundenKontakte(SinDarElaMobile.Models.DbSinDarEla.KundenKontakte kundenKontakte = default(SinDarElaMobile.Models.DbSinDarEla.KundenKontakte))
        {
            var uri = new Uri(baseUri, $"KundenKontaktes");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenKontakte), Encoding.UTF8, "application/json");

            OnCreateKundenKontakte(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenKontakte>(response);
        }

        public async System.Threading.Tasks.Task ExportKundenKontakteArtensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenkontakteartens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenkontakteartens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportKundenKontakteArtensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenkontakteartens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenkontakteartens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetKundenKontakteArtens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenKontakteArten>> GetKundenKontakteArtens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"KundenKontakteArtens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenKontakteArtens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenKontakteArten>>(response);
        }
        partial void OnCreateKundenKontakteArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenKontakteArten> CreateKundenKontakteArten(SinDarElaMobile.Models.DbSinDarEla.KundenKontakteArten kundenKontakteArten = default(SinDarElaMobile.Models.DbSinDarEla.KundenKontakteArten))
        {
            var uri = new Uri(baseUri, $"KundenKontakteArtens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenKontakteArten), Encoding.UTF8, "application/json");

            OnCreateKundenKontakteArten(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenKontakteArten>(response);
        }

        public async System.Threading.Tasks.Task ExportKundenLeistungArtensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenleistungartens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenleistungartens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportKundenLeistungArtensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenleistungartens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenleistungartens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetKundenLeistungArtens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungArten>> GetKundenLeistungArtens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"KundenLeistungArtens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenLeistungArtens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungArten>>(response);
        }
        partial void OnCreateKundenLeistungArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungArten> CreateKundenLeistungArten(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungArten kundenLeistungArten = default(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungArten))
        {
            var uri = new Uri(baseUri, $"KundenLeistungArtens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenLeistungArten), Encoding.UTF8, "application/json");

            OnCreateKundenLeistungArten(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungArten>(response);
        }

        public async System.Threading.Tasks.Task ExportKundenLeistungensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenleistungens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenleistungens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportKundenLeistungensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenleistungens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenleistungens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetKundenLeistungens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungen>> GetKundenLeistungens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"KundenLeistungens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenLeistungens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungen>>(response);
        }
        partial void OnCreateKundenLeistungen(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungen> CreateKundenLeistungen(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungen kundenLeistungen = default(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungen))
        {
            var uri = new Uri(baseUri, $"KundenLeistungens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenLeistungen), Encoding.UTF8, "application/json");

            OnCreateKundenLeistungen(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungen>(response);
        }

        public async System.Threading.Tasks.Task ExportKundenLeistungenBescheidesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenleistungenbescheides/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenleistungenbescheides/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportKundenLeistungenBescheidesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenleistungenbescheides/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenleistungenbescheides/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetKundenLeistungenBescheides(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheide>> GetKundenLeistungenBescheides(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBescheides");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenLeistungenBescheides(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheide>>(response);
        }
        partial void OnCreateKundenLeistungenBescheide(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheide> CreateKundenLeistungenBescheide(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheide kundenLeistungenBescheide = default(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheide))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBescheides");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenLeistungenBescheide), Encoding.UTF8, "application/json");

            OnCreateKundenLeistungenBescheide(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheide>(response);
        }

        public async System.Threading.Tasks.Task ExportKundenLeistungenBescheideKontingentesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenleistungenbescheidekontingentes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenleistungenbescheidekontingentes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportKundenLeistungenBescheideKontingentesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenleistungenbescheidekontingentes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenleistungenbescheidekontingentes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetKundenLeistungenBescheideKontingentes(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideKontingente>> GetKundenLeistungenBescheideKontingentes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBescheideKontingentes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenLeistungenBescheideKontingentes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideKontingente>>(response);
        }
        partial void OnCreateKundenLeistungenBescheideKontingente(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideKontingente> CreateKundenLeistungenBescheideKontingente(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideKontingente kundenLeistungenBescheideKontingente = default(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideKontingente))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBescheideKontingentes");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenLeistungenBescheideKontingente), Encoding.UTF8, "application/json");

            OnCreateKundenLeistungenBescheideKontingente(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideKontingente>(response);
        }

        public async System.Threading.Tasks.Task ExportKundenLeistungenBescheideStatusesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenleistungenbescheidestatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenleistungenbescheidestatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportKundenLeistungenBescheideStatusesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenleistungenbescheidestatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenleistungenbescheidestatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetKundenLeistungenBescheideStatuses(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideStatus>> GetKundenLeistungenBescheideStatuses(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBescheideStatuses");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenLeistungenBescheideStatuses(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideStatus>>(response);
        }
        partial void OnCreateKundenLeistungenBescheideStatus(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideStatus> CreateKundenLeistungenBescheideStatus(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideStatus kundenLeistungenBescheideStatus = default(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideStatus))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBescheideStatuses");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenLeistungenBescheideStatus), Encoding.UTF8, "application/json");

            OnCreateKundenLeistungenBescheideStatus(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideStatus>(response);
        }

        public async System.Threading.Tasks.Task ExportKundenLeistungenBetreuersToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenleistungenbetreuers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenleistungenbetreuers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportKundenLeistungenBetreuersToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenleistungenbetreuers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenleistungenbetreuers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetKundenLeistungenBetreuers(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuer>> GetKundenLeistungenBetreuers(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBetreuers");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenLeistungenBetreuers(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuer>>(response);
        }
        partial void OnCreateKundenLeistungenBetreuer(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuer> CreateKundenLeistungenBetreuer(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuer kundenLeistungenBetreuer = default(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuer))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBetreuers");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenLeistungenBetreuer), Encoding.UTF8, "application/json");

            OnCreateKundenLeistungenBetreuer(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuer>(response);
        }

        public async System.Threading.Tasks.Task ExportKundenLeistungenBetreuerArtensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenleistungenbetreuerartens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenleistungenbetreuerartens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportKundenLeistungenBetreuerArtensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenleistungenbetreuerartens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenleistungenbetreuerartens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetKundenLeistungenBetreuerArtens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuerArten>> GetKundenLeistungenBetreuerArtens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBetreuerArtens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenLeistungenBetreuerArtens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuerArten>>(response);
        }
        partial void OnCreateKundenLeistungenBetreuerArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuerArten> CreateKundenLeistungenBetreuerArten(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuerArten kundenLeistungenBetreuerArten = default(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuerArten))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBetreuerArtens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenLeistungenBetreuerArten), Encoding.UTF8, "application/json");

            OnCreateKundenLeistungenBetreuerArten(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuerArten>(response);
        }

        public async System.Threading.Tasks.Task ExportKundenStatusesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportKundenStatusesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/kundenstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/kundenstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetKundenStatuses(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenStatus>> GetKundenStatuses(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"KundenStatuses");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenStatuses(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.KundenStatus>>(response);
        }
        partial void OnCreateKundenStatus(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenStatus> CreateKundenStatus(SinDarElaMobile.Models.DbSinDarEla.KundenStatus kundenStatus = default(SinDarElaMobile.Models.DbSinDarEla.KundenStatus))
        {
            var uri = new Uri(baseUri, $"KundenStatuses");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenStatus), Encoding.UTF8, "application/json");

            OnCreateKundenStatus(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenStatus>(response);
        }

        public async System.Threading.Tasks.Task ExportMitarbeitersToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiters/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiters/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitarbeitersToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiters/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiters/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitarbeiters(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Mitarbeiter>> GetMitarbeiters(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Mitarbeiters");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiters(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Mitarbeiter>>(response);
        }
        partial void OnCreateMitarbeiter(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Mitarbeiter> CreateMitarbeiter(SinDarElaMobile.Models.DbSinDarEla.Mitarbeiter mitarbeiter = default(SinDarElaMobile.Models.DbSinDarEla.Mitarbeiter))
        {
            var uri = new Uri(baseUri, $"Mitarbeiters");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiter), Encoding.UTF8, "application/json");

            OnCreateMitarbeiter(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Mitarbeiter>(response);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterArtensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterartens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterartens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterArtensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterartens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterartens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitarbeiterArtens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterArten>> GetMitarbeiterArtens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MitarbeiterArtens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterArtens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterArten>>(response);
        }
        partial void OnCreateMitarbeiterArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterArten> CreateMitarbeiterArten(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterArten mitarbeiterArten = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterArten))
        {
            var uri = new Uri(baseUri, $"MitarbeiterArtens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterArten), Encoding.UTF8, "application/json");

            OnCreateMitarbeiterArten(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterArten>(response);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterFirmensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterfirmens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterfirmens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterFirmensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterfirmens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterfirmens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitarbeiterFirmens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFirmen>> GetMitarbeiterFirmens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MitarbeiterFirmens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterFirmens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFirmen>>(response);
        }
        partial void OnCreateMitarbeiterFirmen(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFirmen> CreateMitarbeiterFirmen(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFirmen mitarbeiterFirmen = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFirmen))
        {
            var uri = new Uri(baseUri, $"MitarbeiterFirmens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterFirmen), Encoding.UTF8, "application/json");

            OnCreateMitarbeiterFirmen(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFirmen>(response);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterFortbildungensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterfortbildungens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterfortbildungens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterFortbildungensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterfortbildungens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterfortbildungens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitarbeiterFortbildungens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungen>> GetMitarbeiterFortbildungens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MitarbeiterFortbildungens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterFortbildungens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungen>>(response);
        }
        partial void OnCreateMitarbeiterFortbildungen(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungen> CreateMitarbeiterFortbildungen(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungen mitarbeiterFortbildungen = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungen))
        {
            var uri = new Uri(baseUri, $"MitarbeiterFortbildungens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterFortbildungen), Encoding.UTF8, "application/json");

            OnCreateMitarbeiterFortbildungen(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungen>(response);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterFortbildungenArtensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterfortbildungenartens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterfortbildungenartens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterFortbildungenArtensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterfortbildungenartens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterfortbildungenartens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitarbeiterFortbildungenArtens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungenArten>> GetMitarbeiterFortbildungenArtens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MitarbeiterFortbildungenArtens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterFortbildungenArtens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungenArten>>(response);
        }
        partial void OnCreateMitarbeiterFortbildungenArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungenArten> CreateMitarbeiterFortbildungenArten(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungenArten mitarbeiterFortbildungenArten = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungenArten))
        {
            var uri = new Uri(baseUri, $"MitarbeiterFortbildungenArtens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterFortbildungenArten), Encoding.UTF8, "application/json");

            OnCreateMitarbeiterFortbildungenArten(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungenArten>(response);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterKundenbudgetsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterkundenbudgets/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterkundenbudgets/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterKundenbudgetsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterkundenbudgets/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterkundenbudgets/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitarbeiterKundenbudgets(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudget>> GetMitarbeiterKundenbudgets(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MitarbeiterKundenbudgets");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterKundenbudgets(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudget>>(response);
        }
        partial void OnCreateMitarbeiterKundenbudget(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudget> CreateMitarbeiterKundenbudget(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudget mitarbeiterKundenbudget = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudget))
        {
            var uri = new Uri(baseUri, $"MitarbeiterKundenbudgets");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterKundenbudget), Encoding.UTF8, "application/json");

            OnCreateMitarbeiterKundenbudget(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudget>(response);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterKundenbudgetKategoriensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterkundenbudgetkategoriens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterkundenbudgetkategoriens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterKundenbudgetKategoriensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterkundenbudgetkategoriens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterkundenbudgetkategoriens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitarbeiterKundenbudgetKategoriens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien>> GetMitarbeiterKundenbudgetKategoriens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MitarbeiterKundenbudgetKategoriens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterKundenbudgetKategoriens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien>>(response);
        }
        partial void OnCreateMitarbeiterKundenbudgetKategorien(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien> CreateMitarbeiterKundenbudgetKategorien(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien mitarbeiterKundenbudgetKategorien = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien))
        {
            var uri = new Uri(baseUri, $"MitarbeiterKundenbudgetKategoriens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterKundenbudgetKategorien), Encoding.UTF8, "application/json");

            OnCreateMitarbeiterKundenbudgetKategorien(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien>(response);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterStatusesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterStatusesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitarbeiterStatuses(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterStatus>> GetMitarbeiterStatuses(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MitarbeiterStatuses");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterStatuses(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterStatus>>(response);
        }
        partial void OnCreateMitarbeiterStatus(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterStatus> CreateMitarbeiterStatus(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterStatus mitarbeiterStatus = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterStatus))
        {
            var uri = new Uri(baseUri, $"MitarbeiterStatuses");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterStatus), Encoding.UTF8, "application/json");

            OnCreateMitarbeiterStatus(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterStatus>(response);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterTaetigkeitensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeitertaetigkeitens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeitertaetigkeitens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterTaetigkeitensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeitertaetigkeitens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeitertaetigkeitens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitarbeiterTaetigkeitens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeiten>> GetMitarbeiterTaetigkeitens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MitarbeiterTaetigkeitens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterTaetigkeitens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeiten>>(response);
        }
        partial void OnCreateMitarbeiterTaetigkeiten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeiten> CreateMitarbeiterTaetigkeiten(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeiten mitarbeiterTaetigkeiten = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeiten))
        {
            var uri = new Uri(baseUri, $"MitarbeiterTaetigkeitens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterTaetigkeiten), Encoding.UTF8, "application/json");

            OnCreateMitarbeiterTaetigkeiten(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeiten>(response);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterTaetigkeitenArtensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeitertaetigkeitenartens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeitertaetigkeitenartens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterTaetigkeitenArtensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeitertaetigkeitenartens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeitertaetigkeitenartens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitarbeiterTaetigkeitenArtens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeitenArten>> GetMitarbeiterTaetigkeitenArtens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MitarbeiterTaetigkeitenArtens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterTaetigkeitenArtens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeitenArten>>(response);
        }
        partial void OnCreateMitarbeiterTaetigkeitenArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeitenArten> CreateMitarbeiterTaetigkeitenArten(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeitenArten mitarbeiterTaetigkeitenArten = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeitenArten))
        {
            var uri = new Uri(baseUri, $"MitarbeiterTaetigkeitenArtens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterTaetigkeitenArten), Encoding.UTF8, "application/json");

            OnCreateMitarbeiterTaetigkeitenArten(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeitenArten>(response);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterUrlaubsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterurlaubs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterurlaubs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterUrlaubsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterurlaubs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterurlaubs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitarbeiterUrlaubs(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaub>> GetMitarbeiterUrlaubs(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubs");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterUrlaubs(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaub>>(response);
        }
        partial void OnCreateMitarbeiterUrlaub(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaub> CreateMitarbeiterUrlaub(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaub mitarbeiterUrlaub = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaub))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubs");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterUrlaub), Encoding.UTF8, "application/json");

            OnCreateMitarbeiterUrlaub(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaub>(response);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterUrlaubDetailsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterurlaubdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterurlaubdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterUrlaubDetailsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterurlaubdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterurlaubdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitarbeiterUrlaubDetails(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubDetail>> GetMitarbeiterUrlaubDetails(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubDetails");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterUrlaubDetails(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubDetail>>(response);
        }
        partial void OnCreateMitarbeiterUrlaubDetail(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubDetail> CreateMitarbeiterUrlaubDetail(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubDetail mitarbeiterUrlaubDetail = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubDetail))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubDetails");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterUrlaubDetail), Encoding.UTF8, "application/json");

            OnCreateMitarbeiterUrlaubDetail(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubDetail>(response);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterUrlaubKumuliertAnspruchesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterurlaubkumuliertanspruches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterurlaubkumuliertanspruches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterUrlaubKumuliertAnspruchesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterurlaubkumuliertanspruches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterurlaubkumuliertanspruches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitarbeiterUrlaubKumuliertAnspruches(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch>> GetMitarbeiterUrlaubKumuliertAnspruches(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubKumuliertAnspruches");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterUrlaubKumuliertAnspruches(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch>>(response);
        }
        partial void OnCreateMitarbeiterUrlaubKumuliertAnspruch(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch> CreateMitarbeiterUrlaubKumuliertAnspruch(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch mitarbeiterUrlaubKumuliertAnspruch = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubKumuliertAnspruches");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterUrlaubKumuliertAnspruch), Encoding.UTF8, "application/json");

            OnCreateMitarbeiterUrlaubKumuliertAnspruch(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch>(response);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterUrlaubKumuliertDienstzeitensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterurlaubkumuliertdienstzeitens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterurlaubkumuliertdienstzeitens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterUrlaubKumuliertDienstzeitensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterurlaubkumuliertdienstzeitens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterurlaubkumuliertdienstzeitens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitarbeiterUrlaubKumuliertDienstzeitens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten>> GetMitarbeiterUrlaubKumuliertDienstzeitens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubKumuliertDienstzeitens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterUrlaubKumuliertDienstzeitens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten>>(response);
        }
        partial void OnCreateMitarbeiterUrlaubKumuliertDienstzeiten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten> CreateMitarbeiterUrlaubKumuliertDienstzeiten(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten mitarbeiterUrlaubKumuliertDienstzeiten = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubKumuliertDienstzeitens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterUrlaubKumuliertDienstzeiten), Encoding.UTF8, "application/json");

            OnCreateMitarbeiterUrlaubKumuliertDienstzeiten(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten>(response);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterVerlaufDienstzeitensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterverlaufdienstzeitens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterverlaufdienstzeitens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterVerlaufDienstzeitensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterverlaufdienstzeitens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterverlaufdienstzeitens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitarbeiterVerlaufDienstzeitens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten>> GetMitarbeiterVerlaufDienstzeitens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufDienstzeitens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterVerlaufDienstzeitens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten>>(response);
        }
        partial void OnCreateMitarbeiterVerlaufDienstzeiten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten> CreateMitarbeiterVerlaufDienstzeiten(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten mitarbeiterVerlaufDienstzeiten = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufDienstzeitens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterVerlaufDienstzeiten), Encoding.UTF8, "application/json");

            OnCreateMitarbeiterVerlaufDienstzeiten(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten>(response);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterVerlaufDienstzeitenArtensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterverlaufdienstzeitenartens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterverlaufdienstzeitenartens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterVerlaufDienstzeitenArtensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterverlaufdienstzeitenartens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterverlaufdienstzeitenartens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitarbeiterVerlaufDienstzeitenArtens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten>> GetMitarbeiterVerlaufDienstzeitenArtens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufDienstzeitenArtens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterVerlaufDienstzeitenArtens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten>>(response);
        }
        partial void OnCreateMitarbeiterVerlaufDienstzeitenArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten> CreateMitarbeiterVerlaufDienstzeitenArten(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten mitarbeiterVerlaufDienstzeitenArten = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufDienstzeitenArtens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterVerlaufDienstzeitenArten), Encoding.UTF8, "application/json");

            OnCreateMitarbeiterVerlaufDienstzeitenArten(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten>(response);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterVerlaufGehaltsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterverlaufgehalts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterverlaufgehalts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterVerlaufGehaltsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterverlaufgehalts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterverlaufgehalts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitarbeiterVerlaufGehalts(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufGehalt>> GetMitarbeiterVerlaufGehalts(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufGehalts");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterVerlaufGehalts(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufGehalt>>(response);
        }
        partial void OnCreateMitarbeiterVerlaufGehalt(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufGehalt> CreateMitarbeiterVerlaufGehalt(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufGehalt mitarbeiterVerlaufGehalt = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufGehalt))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufGehalts");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterVerlaufGehalt), Encoding.UTF8, "application/json");

            OnCreateMitarbeiterVerlaufGehalt(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufGehalt>(response);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterVerlaufNormalarbeitszeitsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterverlaufnormalarbeitszeits/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterverlaufnormalarbeitszeits/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitarbeiterVerlaufNormalarbeitszeitsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitarbeiterverlaufnormalarbeitszeits/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitarbeiterverlaufnormalarbeitszeits/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitarbeiterVerlaufNormalarbeitszeits(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit>> GetMitarbeiterVerlaufNormalarbeitszeits(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufNormalarbeitszeits");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterVerlaufNormalarbeitszeits(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit>>(response);
        }
        partial void OnCreateMitarbeiterVerlaufNormalarbeitszeit(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit> CreateMitarbeiterVerlaufNormalarbeitszeit(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit mitarbeiterVerlaufNormalarbeitszeit = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufNormalarbeitszeits");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterVerlaufNormalarbeitszeit), Encoding.UTF8, "application/json");

            OnCreateMitarbeiterVerlaufNormalarbeitszeit(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit>(response);
        }

        public async System.Threading.Tasks.Task ExportMitteilungensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitteilungens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitteilungens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitteilungensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitteilungens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitteilungens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitteilungens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Mitteilungen>> GetMitteilungens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Mitteilungens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitteilungens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Mitteilungen>>(response);
        }
        partial void OnCreateMitteilungen(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Mitteilungen> CreateMitteilungen(SinDarElaMobile.Models.DbSinDarEla.Mitteilungen mitteilungen = default(SinDarElaMobile.Models.DbSinDarEla.Mitteilungen))
        {
            var uri = new Uri(baseUri, $"Mitteilungens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitteilungen), Encoding.UTF8, "application/json");

            OnCreateMitteilungen(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Mitteilungen>(response);
        }

        public async System.Threading.Tasks.Task ExportMitteilungenVerteilersToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitteilungenverteilers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitteilungenverteilers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMitteilungenVerteilersToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/mitteilungenverteilers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/mitteilungenverteilers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMitteilungenVerteilers(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitteilungenVerteiler>> GetMitteilungenVerteilers(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MitteilungenVerteilers");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitteilungenVerteilers(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.MitteilungenVerteiler>>(response);
        }
        partial void OnCreateMitteilungenVerteiler(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitteilungenVerteiler> CreateMitteilungenVerteiler(SinDarElaMobile.Models.DbSinDarEla.MitteilungenVerteiler mitteilungenVerteiler = default(SinDarElaMobile.Models.DbSinDarEla.MitteilungenVerteiler))
        {
            var uri = new Uri(baseUri, $"MitteilungenVerteilers");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitteilungenVerteiler), Encoding.UTF8, "application/json");

            OnCreateMitteilungenVerteiler(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitteilungenVerteiler>(response);
        }

        public async System.Threading.Tasks.Task ExportModulesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/modules/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/modules/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportModulesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/modules/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/modules/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetModules(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Module>> GetModules(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Modules");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetModules(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Module>>(response);
        }
        partial void OnCreateModule(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Module> CreateModule(SinDarElaMobile.Models.DbSinDarEla.Module module = default(SinDarElaMobile.Models.DbSinDarEla.Module))
        {
            var uri = new Uri(baseUri, $"Modules");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(module), Encoding.UTF8, "application/json");

            OnCreateModule(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Module>(response);
        }

        public async System.Threading.Tasks.Task ExportNotizensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/notizens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/notizens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportNotizensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/notizens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/notizens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetNotizens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Notizen>> GetNotizens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Notizens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetNotizens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Notizen>>(response);
        }
        partial void OnCreateNotizen(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Notizen> CreateNotizen(SinDarElaMobile.Models.DbSinDarEla.Notizen notizen = default(SinDarElaMobile.Models.DbSinDarEla.Notizen))
        {
            var uri = new Uri(baseUri, $"Notizens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(notizen), Encoding.UTF8, "application/json");

            OnCreateNotizen(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Notizen>(response);
        }

        public async System.Threading.Tasks.Task ExportProtokollsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/protokolls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/protokolls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProtokollsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/protokolls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/protokolls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetProtokolls(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Protokoll>> GetProtokolls(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Protokolls");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProtokolls(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.Protokoll>>(response);
        }
        partial void OnCreateProtokoll(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Protokoll> CreateProtokoll(SinDarElaMobile.Models.DbSinDarEla.Protokoll protokoll = default(SinDarElaMobile.Models.DbSinDarEla.Protokoll))
        {
            var uri = new Uri(baseUri, $"Protokolls");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(protokoll), Encoding.UTF8, "application/json");

            OnCreateProtokoll(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Protokoll>(response);
        }

        public async System.Threading.Tasks.Task ExportRegelnAbwesenheitensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/regelnabwesenheitens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/regelnabwesenheitens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportRegelnAbwesenheitensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/regelnabwesenheitens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/regelnabwesenheitens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetRegelnAbwesenheitens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.RegelnAbwesenheiten>> GetRegelnAbwesenheitens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"RegelnAbwesenheitens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetRegelnAbwesenheitens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.RegelnAbwesenheiten>>(response);
        }
        partial void OnCreateRegelnAbwesenheiten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.RegelnAbwesenheiten> CreateRegelnAbwesenheiten(SinDarElaMobile.Models.DbSinDarEla.RegelnAbwesenheiten regelnAbwesenheiten = default(SinDarElaMobile.Models.DbSinDarEla.RegelnAbwesenheiten))
        {
            var uri = new Uri(baseUri, $"RegelnAbwesenheitens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(regelnAbwesenheiten), Encoding.UTF8, "application/json");

            OnCreateRegelnAbwesenheiten(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.RegelnAbwesenheiten>(response);
        }

        public async System.Threading.Tasks.Task ExportVwBaseAllesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwbasealles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwbasealles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportVwBaseAllesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwbasealles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwbasealles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetVwBaseAlles(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwBaseAlle>> GetVwBaseAlles(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"VwBaseAlles");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetVwBaseAlles(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwBaseAlle>>(response);
        }

        public async System.Threading.Tasks.Task ExportVwBaseKontaktesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwbasekontaktes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwbasekontaktes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportVwBaseKontaktesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwbasekontaktes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwbasekontaktes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetVwBaseKontaktes(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwBaseKontakte>> GetVwBaseKontaktes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"VwBaseKontaktes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetVwBaseKontaktes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwBaseKontakte>>(response);
        }

        public async System.Threading.Tasks.Task ExportVwBaseOrtesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwbaseortes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwbaseortes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportVwBaseOrtesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwbaseortes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwbaseortes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetVwBaseOrtes(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwBaseOrte>> GetVwBaseOrtes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"VwBaseOrtes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetVwBaseOrtes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwBaseOrte>>(response);
        }

        public async System.Threading.Tasks.Task ExportVwBasePlzsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwbaseplzs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwbaseplzs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportVwBasePlzsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwbaseplzs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwbaseplzs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetVwBasePlzs(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwBasePlz>> GetVwBasePlzs(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"VwBasePlzs");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetVwBasePlzs(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwBasePlz>>(response);
        }

        public async System.Threading.Tasks.Task ExportVwBenutzerBasesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwbenutzerbases/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwbenutzerbases/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportVwBenutzerBasesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwbenutzerbases/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwbenutzerbases/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetVwBenutzerBases(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwBenutzerBase>> GetVwBenutzerBases(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"VwBenutzerBases");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetVwBenutzerBases(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwBenutzerBase>>(response);
        }

        public async System.Threading.Tasks.Task ExportVwKundenBetreuersToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwkundenbetreuers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwkundenbetreuers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportVwKundenBetreuersToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwkundenbetreuers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwkundenbetreuers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetVwKundenBetreuers(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwKundenBetreuer>> GetVwKundenBetreuers(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"VwKundenBetreuers");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetVwKundenBetreuers(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwKundenBetreuer>>(response);
        }

        public async System.Threading.Tasks.Task ExportVwKundenUndBetreuerAuswahlsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwkundenundbetreuerauswahls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwkundenundbetreuerauswahls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportVwKundenUndBetreuerAuswahlsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwkundenundbetreuerauswahls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwkundenundbetreuerauswahls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetVwKundenUndBetreuerAuswahls(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwKundenUndBetreuerAuswahl>> GetVwKundenUndBetreuerAuswahls(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"VwKundenUndBetreuerAuswahls");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetVwKundenUndBetreuerAuswahls(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwKundenUndBetreuerAuswahl>>(response);
        }

        public async System.Threading.Tasks.Task ExportVwMitarbeitersToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwmitarbeiters/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwmitarbeiters/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportVwMitarbeitersToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwmitarbeiters/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwmitarbeiters/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetVwMitarbeiters(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiter>> GetVwMitarbeiters(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"VwMitarbeiters");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetVwMitarbeiters(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiter>>(response);
        }

        public async System.Threading.Tasks.Task ExportVwMitarbeiterFirmensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwmitarbeiterfirmens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwmitarbeiterfirmens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportVwMitarbeiterFirmensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwmitarbeiterfirmens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwmitarbeiterfirmens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetVwMitarbeiterFirmens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterFirmen>> GetVwMitarbeiterFirmens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"VwMitarbeiterFirmens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetVwMitarbeiterFirmens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterFirmen>>(response);
        }

        public async System.Threading.Tasks.Task ExportVwMitarbeiterKundensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwmitarbeiterkundens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwmitarbeiterkundens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportVwMitarbeiterKundensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwmitarbeiterkundens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwmitarbeiterkundens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetVwMitarbeiterKundens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterKunden>> GetVwMitarbeiterKundens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"VwMitarbeiterKundens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetVwMitarbeiterKundens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterKunden>>(response);
        }

        public async System.Threading.Tasks.Task ExportVwMitarbeiterNeusToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwmitarbeiterneus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwmitarbeiterneus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportVwMitarbeiterNeusToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwmitarbeiterneus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwmitarbeiterneus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetVwMitarbeiterNeus(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterNeu>> GetVwMitarbeiterNeus(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"VwMitarbeiterNeus");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetVwMitarbeiterNeus(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterNeu>>(response);
        }

        public async System.Threading.Tasks.Task ExportVwMitarbeiterSuchensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwmitarbeitersuchens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwmitarbeitersuchens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportVwMitarbeiterSuchensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwmitarbeitersuchens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwmitarbeitersuchens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetVwMitarbeiterSuchens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterSuchen>> GetVwMitarbeiterSuchens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"VwMitarbeiterSuchens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetVwMitarbeiterSuchens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterSuchen>>(response);
        }

        public async System.Threading.Tasks.Task ExportVwMitarbeiterTaetigkeitensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwmitarbeitertaetigkeitens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwmitarbeitertaetigkeitens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportVwMitarbeiterTaetigkeitensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dbsindarela/vwmitarbeitertaetigkeitens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dbsindarela/vwmitarbeitertaetigkeitens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetVwMitarbeiterTaetigkeitens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterTaetigkeiten>> GetVwMitarbeiterTaetigkeitens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"VwMitarbeiterTaetigkeitens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetVwMitarbeiterTaetigkeitens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterTaetigkeiten>>(response);
        }
        partial void OnDeleteAbrechnungBasis(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteAbrechnungBasis(int? abrechnungBasisId = default(int?))
        {
            var uri = new Uri(baseUri, $"AbrechnungBases({abrechnungBasisId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteAbrechnungBasis(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetAbrechnungBasisByAbrechnungBasisId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.AbrechnungBasis> GetAbrechnungBasisByAbrechnungBasisId(string expand = default(string), int? abrechnungBasisId = default(int?))
        {
            var uri = new Uri(baseUri, $"AbrechnungBases({abrechnungBasisId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAbrechnungBasisByAbrechnungBasisId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.AbrechnungBasis>(response);
        }
        partial void OnUpdateAbrechnungBasis(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateAbrechnungBasis(int? abrechnungBasisId = default(int?), SinDarElaMobile.Models.DbSinDarEla.AbrechnungBasis abrechnungBasis = default(SinDarElaMobile.Models.DbSinDarEla.AbrechnungBasis))
        {
            var uri = new Uri(baseUri, $"AbrechnungBases({abrechnungBasisId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(abrechnungBasis), Encoding.UTF8, "application/json");

            OnUpdateAbrechnungBasis(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteAbrechnungKundenReststunden(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteAbrechnungKundenReststunden(int? abrechnungKundenReststundenId = default(int?))
        {
            var uri = new Uri(baseUri, $"AbrechnungKundenReststundens({abrechnungKundenReststundenId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteAbrechnungKundenReststunden(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetAbrechnungKundenReststundenByAbrechnungKundenReststundenId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.AbrechnungKundenReststunden> GetAbrechnungKundenReststundenByAbrechnungKundenReststundenId(string expand = default(string), int? abrechnungKundenReststundenId = default(int?))
        {
            var uri = new Uri(baseUri, $"AbrechnungKundenReststundens({abrechnungKundenReststundenId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAbrechnungKundenReststundenByAbrechnungKundenReststundenId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.AbrechnungKundenReststunden>(response);
        }
        partial void OnUpdateAbrechnungKundenReststunden(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateAbrechnungKundenReststunden(int? abrechnungKundenReststundenId = default(int?), SinDarElaMobile.Models.DbSinDarEla.AbrechnungKundenReststunden abrechnungKundenReststunden = default(SinDarElaMobile.Models.DbSinDarEla.AbrechnungKundenReststunden))
        {
            var uri = new Uri(baseUri, $"AbrechnungKundenReststundens({abrechnungKundenReststundenId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(abrechnungKundenReststunden), Encoding.UTF8, "application/json");

            OnUpdateAbrechnungKundenReststunden(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteAufgaben(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteAufgaben(int? aufgabeId = default(int?))
        {
            var uri = new Uri(baseUri, $"Aufgabens({aufgabeId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteAufgaben(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetAufgabenByAufgabeId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Aufgaben> GetAufgabenByAufgabeId(string expand = default(string), int? aufgabeId = default(int?))
        {
            var uri = new Uri(baseUri, $"Aufgabens({aufgabeId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAufgabenByAufgabeId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Aufgaben>(response);
        }
        partial void OnUpdateAufgaben(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateAufgaben(int? aufgabeId = default(int?), SinDarElaMobile.Models.DbSinDarEla.Aufgaben aufgaben = default(SinDarElaMobile.Models.DbSinDarEla.Aufgaben))
        {
            var uri = new Uri(baseUri, $"Aufgabens({aufgabeId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(aufgaben), Encoding.UTF8, "application/json");

            OnUpdateAufgaben(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteAuswahlJahr(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteAuswahlJahr(int? auswahlJahrId = default(int?))
        {
            var uri = new Uri(baseUri, $"AuswahlJahrs({auswahlJahrId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteAuswahlJahr(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetAuswahlJahrByAuswahlJahrId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.AuswahlJahr> GetAuswahlJahrByAuswahlJahrId(string expand = default(string), int? auswahlJahrId = default(int?))
        {
            var uri = new Uri(baseUri, $"AuswahlJahrs({auswahlJahrId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAuswahlJahrByAuswahlJahrId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.AuswahlJahr>(response);
        }
        partial void OnUpdateAuswahlJahr(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateAuswahlJahr(int? auswahlJahrId = default(int?), SinDarElaMobile.Models.DbSinDarEla.AuswahlJahr auswahlJahr = default(SinDarElaMobile.Models.DbSinDarEla.AuswahlJahr))
        {
            var uri = new Uri(baseUri, $"AuswahlJahrs({auswahlJahrId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(auswahlJahr), Encoding.UTF8, "application/json");

            OnUpdateAuswahlJahr(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteAuswahlMonat(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteAuswahlMonat(int? auswahlMonatId = default(int?))
        {
            var uri = new Uri(baseUri, $"AuswahlMonats({auswahlMonatId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteAuswahlMonat(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetAuswahlMonatByAuswahlMonatId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.AuswahlMonat> GetAuswahlMonatByAuswahlMonatId(string expand = default(string), int? auswahlMonatId = default(int?))
        {
            var uri = new Uri(baseUri, $"AuswahlMonats({auswahlMonatId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAuswahlMonatByAuswahlMonatId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.AuswahlMonat>(response);
        }
        partial void OnUpdateAuswahlMonat(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateAuswahlMonat(int? auswahlMonatId = default(int?), SinDarElaMobile.Models.DbSinDarEla.AuswahlMonat auswahlMonat = default(SinDarElaMobile.Models.DbSinDarEla.AuswahlMonat))
        {
            var uri = new Uri(baseUri, $"AuswahlMonats({auswahlMonatId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(auswahlMonat), Encoding.UTF8, "application/json");

            OnUpdateAuswahlMonat(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteBase(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteBase(int? baseId = default(int?))
        {
            var uri = new Uri(baseUri, $"Bases({baseId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteBase(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetBaseByBaseId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Base> GetBaseByBaseId(string expand = default(string), int? baseId = default(int?))
        {
            var uri = new Uri(baseUri, $"Bases({baseId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetBaseByBaseId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Base>(response);
        }
        partial void OnUpdateBase(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateBase(int? baseId = default(int?), SinDarElaMobile.Models.DbSinDarEla.Base _base = default(SinDarElaMobile.Models.DbSinDarEla.Base))
        {
            var uri = new Uri(baseUri, $"Bases({baseId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(_base), Encoding.UTF8, "application/json");

            OnUpdateBase(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteBaseAnreden(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteBaseAnreden(int? anredeId = default(int?))
        {
            var uri = new Uri(baseUri, $"BaseAnredens({anredeId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteBaseAnreden(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetBaseAnredenByAnredeId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.BaseAnreden> GetBaseAnredenByAnredeId(string expand = default(string), int? anredeId = default(int?))
        {
            var uri = new Uri(baseUri, $"BaseAnredens({anredeId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetBaseAnredenByAnredeId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.BaseAnreden>(response);
        }
        partial void OnUpdateBaseAnreden(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateBaseAnreden(int? anredeId = default(int?), SinDarElaMobile.Models.DbSinDarEla.BaseAnreden baseAnreden = default(SinDarElaMobile.Models.DbSinDarEla.BaseAnreden))
        {
            var uri = new Uri(baseUri, $"BaseAnredens({anredeId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(baseAnreden), Encoding.UTF8, "application/json");

            OnUpdateBaseAnreden(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteBaseKontakte(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteBaseKontakte(int? kontaktId = default(int?))
        {
            var uri = new Uri(baseUri, $"BaseKontaktes({kontaktId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteBaseKontakte(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetBaseKontakteByKontaktId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.BaseKontakte> GetBaseKontakteByKontaktId(string expand = default(string), int? kontaktId = default(int?))
        {
            var uri = new Uri(baseUri, $"BaseKontaktes({kontaktId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetBaseKontakteByKontaktId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.BaseKontakte>(response);
        }
        partial void OnUpdateBaseKontakte(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateBaseKontakte(int? kontaktId = default(int?), SinDarElaMobile.Models.DbSinDarEla.BaseKontakte baseKontakte = default(SinDarElaMobile.Models.DbSinDarEla.BaseKontakte))
        {
            var uri = new Uri(baseUri, $"BaseKontaktes({kontaktId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(baseKontakte), Encoding.UTF8, "application/json");

            OnUpdateBaseKontakte(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteBenutzer(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteBenutzer(int? benutzerId = default(int?))
        {
            var uri = new Uri(baseUri, $"Benutzers({benutzerId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteBenutzer(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetBenutzerByBenutzerId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Benutzer> GetBenutzerByBenutzerId(string expand = default(string), int? benutzerId = default(int?))
        {
            var uri = new Uri(baseUri, $"Benutzers({benutzerId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetBenutzerByBenutzerId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Benutzer>(response);
        }
        partial void OnUpdateBenutzer(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateBenutzer(int? benutzerId = default(int?), SinDarElaMobile.Models.DbSinDarEla.Benutzer benutzer = default(SinDarElaMobile.Models.DbSinDarEla.Benutzer))
        {
            var uri = new Uri(baseUri, $"Benutzers({benutzerId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(benutzer), Encoding.UTF8, "application/json");

            OnUpdateBenutzer(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteBenutzerModule(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteBenutzerModule(int? benutzerModuleId = default(int?))
        {
            var uri = new Uri(baseUri, $"BenutzerModules({benutzerModuleId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteBenutzerModule(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetBenutzerModuleByBenutzerModuleId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.BenutzerModule> GetBenutzerModuleByBenutzerModuleId(string expand = default(string), int? benutzerModuleId = default(int?))
        {
            var uri = new Uri(baseUri, $"BenutzerModules({benutzerModuleId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetBenutzerModuleByBenutzerModuleId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.BenutzerModule>(response);
        }
        partial void OnUpdateBenutzerModule(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateBenutzerModule(int? benutzerModuleId = default(int?), SinDarElaMobile.Models.DbSinDarEla.BenutzerModule benutzerModule = default(SinDarElaMobile.Models.DbSinDarEla.BenutzerModule))
        {
            var uri = new Uri(baseUri, $"BenutzerModules({benutzerModuleId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(benutzerModule), Encoding.UTF8, "application/json");

            OnUpdateBenutzerModule(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteBenutzerProtokoll(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteBenutzerProtokoll(int? benutzerProtokollId = default(int?))
        {
            var uri = new Uri(baseUri, $"BenutzerProtokolls({benutzerProtokollId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteBenutzerProtokoll(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetBenutzerProtokollByBenutzerProtokollId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.BenutzerProtokoll> GetBenutzerProtokollByBenutzerProtokollId(string expand = default(string), int? benutzerProtokollId = default(int?))
        {
            var uri = new Uri(baseUri, $"BenutzerProtokolls({benutzerProtokollId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetBenutzerProtokollByBenutzerProtokollId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.BenutzerProtokoll>(response);
        }
        partial void OnUpdateBenutzerProtokoll(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateBenutzerProtokoll(int? benutzerProtokollId = default(int?), SinDarElaMobile.Models.DbSinDarEla.BenutzerProtokoll benutzerProtokoll = default(SinDarElaMobile.Models.DbSinDarEla.BenutzerProtokoll))
        {
            var uri = new Uri(baseUri, $"BenutzerProtokolls({benutzerProtokollId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(benutzerProtokoll), Encoding.UTF8, "application/json");

            OnUpdateBenutzerProtokoll(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteDebugg(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteDebugg(int? debuggId = default(int?))
        {
            var uri = new Uri(baseUri, $"Debuggs({debuggId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteDebugg(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetDebuggByDebuggId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Debugg> GetDebuggByDebuggId(string expand = default(string), int? debuggId = default(int?))
        {
            var uri = new Uri(baseUri, $"Debuggs({debuggId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDebuggByDebuggId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Debugg>(response);
        }
        partial void OnUpdateDebugg(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateDebugg(int? debuggId = default(int?), SinDarElaMobile.Models.DbSinDarEla.Debugg debugg = default(SinDarElaMobile.Models.DbSinDarEla.Debugg))
        {
            var uri = new Uri(baseUri, $"Debuggs({debuggId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(debugg), Encoding.UTF8, "application/json");

            OnUpdateDebugg(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteDeviceCode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteDeviceCode(string userCode = default(string))
        {
            var uri = new Uri(baseUri, $"DeviceCodes('{HttpUtility.UrlEncode(userCode.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteDeviceCode(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetDeviceCodeByUserCode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.DeviceCode> GetDeviceCodeByUserCode(string expand = default(string), string userCode = default(string))
        {
            var uri = new Uri(baseUri, $"DeviceCodes('{HttpUtility.UrlEncode(userCode.Trim().Replace("'", "''"))}')");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDeviceCodeByUserCode(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.DeviceCode>(response);
        }
        partial void OnUpdateDeviceCode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateDeviceCode(string userCode = default(string), SinDarElaMobile.Models.DbSinDarEla.DeviceCode deviceCode = default(SinDarElaMobile.Models.DbSinDarEla.DeviceCode))
        {
            var uri = new Uri(baseUri, $"DeviceCodes('{HttpUtility.UrlEncode(userCode.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(deviceCode), Encoding.UTF8, "application/json");

            OnUpdateDeviceCode(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteDokumente(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteDokumente(int? dokumentId = default(int?))
        {
            var uri = new Uri(baseUri, $"Dokumentes({dokumentId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteDokumente(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetDokumenteByDokumentId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Dokumente> GetDokumenteByDokumentId(string expand = default(string), int? dokumentId = default(int?))
        {
            var uri = new Uri(baseUri, $"Dokumentes({dokumentId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDokumenteByDokumentId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Dokumente>(response);
        }
        partial void OnUpdateDokumente(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateDokumente(int? dokumentId = default(int?), SinDarElaMobile.Models.DbSinDarEla.Dokumente dokumente = default(SinDarElaMobile.Models.DbSinDarEla.Dokumente))
        {
            var uri = new Uri(baseUri, $"Dokumentes({dokumentId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(dokumente), Encoding.UTF8, "application/json");

            OnUpdateDokumente(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteDokumenteKategorien(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteDokumenteKategorien(int? dokumenteKategorieId = default(int?))
        {
            var uri = new Uri(baseUri, $"DokumenteKategoriens({dokumenteKategorieId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteDokumenteKategorien(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetDokumenteKategorienByDokumenteKategorieId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.DokumenteKategorien> GetDokumenteKategorienByDokumenteKategorieId(string expand = default(string), int? dokumenteKategorieId = default(int?))
        {
            var uri = new Uri(baseUri, $"DokumenteKategoriens({dokumenteKategorieId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDokumenteKategorienByDokumenteKategorieId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.DokumenteKategorien>(response);
        }
        partial void OnUpdateDokumenteKategorien(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateDokumenteKategorien(int? dokumenteKategorieId = default(int?), SinDarElaMobile.Models.DbSinDarEla.DokumenteKategorien dokumenteKategorien = default(SinDarElaMobile.Models.DbSinDarEla.DokumenteKategorien))
        {
            var uri = new Uri(baseUri, $"DokumenteKategoriens({dokumenteKategorieId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(dokumenteKategorien), Encoding.UTF8, "application/json");

            OnUpdateDokumenteKategorien(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteEreignisse(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteEreignisse(int? ereignisId = default(int?))
        {
            var uri = new Uri(baseUri, $"Ereignisses({ereignisId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteEreignisse(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetEreignisseByEreignisId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Ereignisse> GetEreignisseByEreignisId(string expand = default(string), int? ereignisId = default(int?))
        {
            var uri = new Uri(baseUri, $"Ereignisses({ereignisId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEreignisseByEreignisId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Ereignisse>(response);
        }
        partial void OnUpdateEreignisse(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateEreignisse(int? ereignisId = default(int?), SinDarElaMobile.Models.DbSinDarEla.Ereignisse ereignisse = default(SinDarElaMobile.Models.DbSinDarEla.Ereignisse))
        {
            var uri = new Uri(baseUri, $"Ereignisses({ereignisId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(ereignisse), Encoding.UTF8, "application/json");

            OnUpdateEreignisse(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteEreignisseArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteEreignisseArten(string ereignisArtCode = default(string))
        {
            var uri = new Uri(baseUri, $"EreignisseArtens('{HttpUtility.UrlEncode(ereignisArtCode.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteEreignisseArten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetEreignisseArtenByEreignisArtCode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.EreignisseArten> GetEreignisseArtenByEreignisArtCode(string expand = default(string), string ereignisArtCode = default(string))
        {
            var uri = new Uri(baseUri, $"EreignisseArtens('{HttpUtility.UrlEncode(ereignisArtCode.Trim().Replace("'", "''"))}')");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEreignisseArtenByEreignisArtCode(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.EreignisseArten>(response);
        }
        partial void OnUpdateEreignisseArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateEreignisseArten(string ereignisArtCode = default(string), SinDarElaMobile.Models.DbSinDarEla.EreignisseArten ereignisseArten = default(SinDarElaMobile.Models.DbSinDarEla.EreignisseArten))
        {
            var uri = new Uri(baseUri, $"EreignisseArtens('{HttpUtility.UrlEncode(ereignisArtCode.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(ereignisseArten), Encoding.UTF8, "application/json");

            OnUpdateEreignisseArten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteEreignisseSonderurlaubArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteEreignisseSonderurlaubArten(int? ereignisSonderurlaubArtId = default(int?))
        {
            var uri = new Uri(baseUri, $"EreignisseSonderurlaubArtens({ereignisSonderurlaubArtId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteEreignisseSonderurlaubArten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetEreignisseSonderurlaubArtenByEreignisSonderurlaubArtId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.EreignisseSonderurlaubArten> GetEreignisseSonderurlaubArtenByEreignisSonderurlaubArtId(string expand = default(string), int? ereignisSonderurlaubArtId = default(int?))
        {
            var uri = new Uri(baseUri, $"EreignisseSonderurlaubArtens({ereignisSonderurlaubArtId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEreignisseSonderurlaubArtenByEreignisSonderurlaubArtId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.EreignisseSonderurlaubArten>(response);
        }
        partial void OnUpdateEreignisseSonderurlaubArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateEreignisseSonderurlaubArten(int? ereignisSonderurlaubArtId = default(int?), SinDarElaMobile.Models.DbSinDarEla.EreignisseSonderurlaubArten ereignisseSonderurlaubArten = default(SinDarElaMobile.Models.DbSinDarEla.EreignisseSonderurlaubArten))
        {
            var uri = new Uri(baseUri, $"EreignisseSonderurlaubArtens({ereignisSonderurlaubArtId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(ereignisseSonderurlaubArten), Encoding.UTF8, "application/json");

            OnUpdateEreignisseSonderurlaubArten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteEreignisseTeilnehmer(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteEreignisseTeilnehmer(int? ereignisseTeilnehmerId = default(int?))
        {
            var uri = new Uri(baseUri, $"EreignisseTeilnehmers({ereignisseTeilnehmerId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteEreignisseTeilnehmer(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetEreignisseTeilnehmerByEreignisseTeilnehmerId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmer> GetEreignisseTeilnehmerByEreignisseTeilnehmerId(string expand = default(string), int? ereignisseTeilnehmerId = default(int?))
        {
            var uri = new Uri(baseUri, $"EreignisseTeilnehmers({ereignisseTeilnehmerId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEreignisseTeilnehmerByEreignisseTeilnehmerId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmer>(response);
        }
        partial void OnUpdateEreignisseTeilnehmer(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateEreignisseTeilnehmer(int? ereignisseTeilnehmerId = default(int?), SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmer ereignisseTeilnehmer = default(SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmer))
        {
            var uri = new Uri(baseUri, $"EreignisseTeilnehmers({ereignisseTeilnehmerId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(ereignisseTeilnehmer), Encoding.UTF8, "application/json");

            OnUpdateEreignisseTeilnehmer(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteEreignisseTeilnehmerStatus(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteEreignisseTeilnehmerStatus(string statusCode = default(string))
        {
            var uri = new Uri(baseUri, $"EreignisseTeilnehmerStatuses('{HttpUtility.UrlEncode(statusCode.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteEreignisseTeilnehmerStatus(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetEreignisseTeilnehmerStatusByStatusCode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmerStatus> GetEreignisseTeilnehmerStatusByStatusCode(string expand = default(string), string statusCode = default(string))
        {
            var uri = new Uri(baseUri, $"EreignisseTeilnehmerStatuses('{HttpUtility.UrlEncode(statusCode.Trim().Replace("'", "''"))}')");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEreignisseTeilnehmerStatusByStatusCode(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmerStatus>(response);
        }
        partial void OnUpdateEreignisseTeilnehmerStatus(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateEreignisseTeilnehmerStatus(string statusCode = default(string), SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmerStatus ereignisseTeilnehmerStatus = default(SinDarElaMobile.Models.DbSinDarEla.EreignisseTeilnehmerStatus))
        {
            var uri = new Uri(baseUri, $"EreignisseTeilnehmerStatuses('{HttpUtility.UrlEncode(statusCode.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(ereignisseTeilnehmerStatus), Encoding.UTF8, "application/json");

            OnUpdateEreignisseTeilnehmerStatus(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteFeedback(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteFeedback(int? feedbackId = default(int?))
        {
            var uri = new Uri(baseUri, $"Feedbacks({feedbackId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteFeedback(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetFeedbackByFeedbackId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Feedback> GetFeedbackByFeedbackId(string expand = default(string), int? feedbackId = default(int?))
        {
            var uri = new Uri(baseUri, $"Feedbacks({feedbackId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetFeedbackByFeedbackId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Feedback>(response);
        }
        partial void OnUpdateFeedback(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateFeedback(int? feedbackId = default(int?), SinDarElaMobile.Models.DbSinDarEla.Feedback feedback = default(SinDarElaMobile.Models.DbSinDarEla.Feedback))
        {
            var uri = new Uri(baseUri, $"Feedbacks({feedbackId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(feedback), Encoding.UTF8, "application/json");

            OnUpdateFeedback(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteFirmen(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteFirmen(int? firmaId = default(int?))
        {
            var uri = new Uri(baseUri, $"Firmens({firmaId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteFirmen(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetFirmenByFirmaId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Firmen> GetFirmenByFirmaId(string expand = default(string), int? firmaId = default(int?))
        {
            var uri = new Uri(baseUri, $"Firmens({firmaId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetFirmenByFirmaId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Firmen>(response);
        }
        partial void OnUpdateFirmen(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateFirmen(int? firmaId = default(int?), SinDarElaMobile.Models.DbSinDarEla.Firmen firmen = default(SinDarElaMobile.Models.DbSinDarEla.Firmen))
        {
            var uri = new Uri(baseUri, $"Firmens({firmaId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(firmen), Encoding.UTF8, "application/json");

            OnUpdateFirmen(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteFirmenMitarbeiterTaetigkeiten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteFirmenMitarbeiterTaetigkeiten(int? firmenMitarbeiterTaetigkeitenId = default(int?))
        {
            var uri = new Uri(baseUri, $"FirmenMitarbeiterTaetigkeitens({firmenMitarbeiterTaetigkeitenId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteFirmenMitarbeiterTaetigkeiten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetFirmenMitarbeiterTaetigkeitenByFirmenMitarbeiterTaetigkeitenId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten> GetFirmenMitarbeiterTaetigkeitenByFirmenMitarbeiterTaetigkeitenId(string expand = default(string), int? firmenMitarbeiterTaetigkeitenId = default(int?))
        {
            var uri = new Uri(baseUri, $"FirmenMitarbeiterTaetigkeitens({firmenMitarbeiterTaetigkeitenId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetFirmenMitarbeiterTaetigkeitenByFirmenMitarbeiterTaetigkeitenId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten>(response);
        }
        partial void OnUpdateFirmenMitarbeiterTaetigkeiten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateFirmenMitarbeiterTaetigkeiten(int? firmenMitarbeiterTaetigkeitenId = default(int?), SinDarElaMobile.Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten firmenMitarbeiterTaetigkeiten = default(SinDarElaMobile.Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten))
        {
            var uri = new Uri(baseUri, $"FirmenMitarbeiterTaetigkeitens({firmenMitarbeiterTaetigkeitenId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(firmenMitarbeiterTaetigkeiten), Encoding.UTF8, "application/json");

            OnUpdateFirmenMitarbeiterTaetigkeiten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteInfotexteHtml(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteInfotexteHtml(int? infotextId = default(int?))
        {
            var uri = new Uri(baseUri, $"InfotexteHtmls({infotextId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteInfotexteHtml(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetInfotexteHtmlByInfotextId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml> GetInfotexteHtmlByInfotextId(string expand = default(string), int? infotextId = default(int?))
        {
            var uri = new Uri(baseUri, $"InfotexteHtmls({infotextId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetInfotexteHtmlByInfotextId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml>(response);
        }
        partial void OnUpdateInfotexteHtml(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateInfotexteHtml(int? infotextId = default(int?), SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml infotexteHtml = default(SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml))
        {
            var uri = new Uri(baseUri, $"InfotexteHtmls({infotextId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(infotexteHtml), Encoding.UTF8, "application/json");

            OnUpdateInfotexteHtml(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteKunden(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteKunden(int? kundenId = default(int?))
        {
            var uri = new Uri(baseUri, $"Kundens({kundenId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteKunden(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetKundenByKundenId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Kunden> GetKundenByKundenId(string expand = default(string), int? kundenId = default(int?))
        {
            var uri = new Uri(baseUri, $"Kundens({kundenId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenByKundenId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Kunden>(response);
        }
        partial void OnUpdateKunden(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateKunden(int? kundenId = default(int?), SinDarElaMobile.Models.DbSinDarEla.Kunden kunden = default(SinDarElaMobile.Models.DbSinDarEla.Kunden))
        {
            var uri = new Uri(baseUri, $"Kundens({kundenId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kunden), Encoding.UTF8, "application/json");

            OnUpdateKunden(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteKundenKontakte(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteKundenKontakte(int? kundenKontaktId = default(int?))
        {
            var uri = new Uri(baseUri, $"KundenKontaktes({kundenKontaktId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteKundenKontakte(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetKundenKontakteByKundenKontaktId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenKontakte> GetKundenKontakteByKundenKontaktId(string expand = default(string), int? kundenKontaktId = default(int?))
        {
            var uri = new Uri(baseUri, $"KundenKontaktes({kundenKontaktId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenKontakteByKundenKontaktId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenKontakte>(response);
        }
        partial void OnUpdateKundenKontakte(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateKundenKontakte(int? kundenKontaktId = default(int?), SinDarElaMobile.Models.DbSinDarEla.KundenKontakte kundenKontakte = default(SinDarElaMobile.Models.DbSinDarEla.KundenKontakte))
        {
            var uri = new Uri(baseUri, $"KundenKontaktes({kundenKontaktId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenKontakte), Encoding.UTF8, "application/json");

            OnUpdateKundenKontakte(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteKundenKontakteArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteKundenKontakteArten(int? kundenKontaktArtId = default(int?))
        {
            var uri = new Uri(baseUri, $"KundenKontakteArtens({kundenKontaktArtId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteKundenKontakteArten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetKundenKontakteArtenByKundenKontaktArtId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenKontakteArten> GetKundenKontakteArtenByKundenKontaktArtId(string expand = default(string), int? kundenKontaktArtId = default(int?))
        {
            var uri = new Uri(baseUri, $"KundenKontakteArtens({kundenKontaktArtId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenKontakteArtenByKundenKontaktArtId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenKontakteArten>(response);
        }
        partial void OnUpdateKundenKontakteArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateKundenKontakteArten(int? kundenKontaktArtId = default(int?), SinDarElaMobile.Models.DbSinDarEla.KundenKontakteArten kundenKontakteArten = default(SinDarElaMobile.Models.DbSinDarEla.KundenKontakteArten))
        {
            var uri = new Uri(baseUri, $"KundenKontakteArtens({kundenKontaktArtId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenKontakteArten), Encoding.UTF8, "application/json");

            OnUpdateKundenKontakteArten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteKundenLeistungArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteKundenLeistungArten(int? kundenLeistungArtId = default(int?))
        {
            var uri = new Uri(baseUri, $"KundenLeistungArtens({kundenLeistungArtId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteKundenLeistungArten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetKundenLeistungArtenByKundenLeistungArtId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungArten> GetKundenLeistungArtenByKundenLeistungArtId(string expand = default(string), int? kundenLeistungArtId = default(int?))
        {
            var uri = new Uri(baseUri, $"KundenLeistungArtens({kundenLeistungArtId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenLeistungArtenByKundenLeistungArtId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungArten>(response);
        }
        partial void OnUpdateKundenLeistungArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateKundenLeistungArten(int? kundenLeistungArtId = default(int?), SinDarElaMobile.Models.DbSinDarEla.KundenLeistungArten kundenLeistungArten = default(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungArten))
        {
            var uri = new Uri(baseUri, $"KundenLeistungArtens({kundenLeistungArtId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenLeistungArten), Encoding.UTF8, "application/json");

            OnUpdateKundenLeistungArten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteKundenLeistungen(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteKundenLeistungen(int? kundenLeistungId = default(int?))
        {
            var uri = new Uri(baseUri, $"KundenLeistungens({kundenLeistungId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteKundenLeistungen(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetKundenLeistungenByKundenLeistungId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungen> GetKundenLeistungenByKundenLeistungId(string expand = default(string), int? kundenLeistungId = default(int?))
        {
            var uri = new Uri(baseUri, $"KundenLeistungens({kundenLeistungId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenLeistungenByKundenLeistungId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungen>(response);
        }
        partial void OnUpdateKundenLeistungen(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateKundenLeistungen(int? kundenLeistungId = default(int?), SinDarElaMobile.Models.DbSinDarEla.KundenLeistungen kundenLeistungen = default(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungen))
        {
            var uri = new Uri(baseUri, $"KundenLeistungens({kundenLeistungId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenLeistungen), Encoding.UTF8, "application/json");

            OnUpdateKundenLeistungen(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteKundenLeistungenBescheide(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteKundenLeistungenBescheide(int? kundenLeistungenBescheidId = default(int?))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBescheides({kundenLeistungenBescheidId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteKundenLeistungenBescheide(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetKundenLeistungenBescheideByKundenLeistungenBescheidId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheide> GetKundenLeistungenBescheideByKundenLeistungenBescheidId(string expand = default(string), int? kundenLeistungenBescheidId = default(int?))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBescheides({kundenLeistungenBescheidId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenLeistungenBescheideByKundenLeistungenBescheidId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheide>(response);
        }
        partial void OnUpdateKundenLeistungenBescheide(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateKundenLeistungenBescheide(int? kundenLeistungenBescheidId = default(int?), SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheide kundenLeistungenBescheide = default(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheide))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBescheides({kundenLeistungenBescheidId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenLeistungenBescheide), Encoding.UTF8, "application/json");

            OnUpdateKundenLeistungenBescheide(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteKundenLeistungenBescheideKontingente(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteKundenLeistungenBescheideKontingente(int? kundenLeistungenBescheideKontingentId = default(int?))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBescheideKontingentes({kundenLeistungenBescheideKontingentId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteKundenLeistungenBescheideKontingente(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetKundenLeistungenBescheideKontingenteByKundenLeistungenBescheideKontingentId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideKontingente> GetKundenLeistungenBescheideKontingenteByKundenLeistungenBescheideKontingentId(string expand = default(string), int? kundenLeistungenBescheideKontingentId = default(int?))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBescheideKontingentes({kundenLeistungenBescheideKontingentId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenLeistungenBescheideKontingenteByKundenLeistungenBescheideKontingentId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideKontingente>(response);
        }
        partial void OnUpdateKundenLeistungenBescheideKontingente(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateKundenLeistungenBescheideKontingente(int? kundenLeistungenBescheideKontingentId = default(int?), SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideKontingente kundenLeistungenBescheideKontingente = default(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideKontingente))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBescheideKontingentes({kundenLeistungenBescheideKontingentId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenLeistungenBescheideKontingente), Encoding.UTF8, "application/json");

            OnUpdateKundenLeistungenBescheideKontingente(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteKundenLeistungenBescheideStatus(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteKundenLeistungenBescheideStatus(string statusCode = default(string))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBescheideStatuses('{HttpUtility.UrlEncode(statusCode.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteKundenLeistungenBescheideStatus(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetKundenLeistungenBescheideStatusByStatusCode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideStatus> GetKundenLeistungenBescheideStatusByStatusCode(string expand = default(string), string statusCode = default(string))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBescheideStatuses('{HttpUtility.UrlEncode(statusCode.Trim().Replace("'", "''"))}')");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenLeistungenBescheideStatusByStatusCode(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideStatus>(response);
        }
        partial void OnUpdateKundenLeistungenBescheideStatus(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateKundenLeistungenBescheideStatus(string statusCode = default(string), SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideStatus kundenLeistungenBescheideStatus = default(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBescheideStatus))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBescheideStatuses('{HttpUtility.UrlEncode(statusCode.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenLeistungenBescheideStatus), Encoding.UTF8, "application/json");

            OnUpdateKundenLeistungenBescheideStatus(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteKundenLeistungenBetreuer(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteKundenLeistungenBetreuer(int? kundenLeistungenBetreuerId = default(int?))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBetreuers({kundenLeistungenBetreuerId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteKundenLeistungenBetreuer(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetKundenLeistungenBetreuerByKundenLeistungenBetreuerId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuer> GetKundenLeistungenBetreuerByKundenLeistungenBetreuerId(string expand = default(string), int? kundenLeistungenBetreuerId = default(int?))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBetreuers({kundenLeistungenBetreuerId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenLeistungenBetreuerByKundenLeistungenBetreuerId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuer>(response);
        }
        partial void OnUpdateKundenLeistungenBetreuer(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateKundenLeistungenBetreuer(int? kundenLeistungenBetreuerId = default(int?), SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuer kundenLeistungenBetreuer = default(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuer))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBetreuers({kundenLeistungenBetreuerId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenLeistungenBetreuer), Encoding.UTF8, "application/json");

            OnUpdateKundenLeistungenBetreuer(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteKundenLeistungenBetreuerArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteKundenLeistungenBetreuerArten(int? kundenLeistungenBetreuerArtId = default(int?))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBetreuerArtens({kundenLeistungenBetreuerArtId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteKundenLeistungenBetreuerArten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetKundenLeistungenBetreuerArtenByKundenLeistungenBetreuerArtId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuerArten> GetKundenLeistungenBetreuerArtenByKundenLeistungenBetreuerArtId(string expand = default(string), int? kundenLeistungenBetreuerArtId = default(int?))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBetreuerArtens({kundenLeistungenBetreuerArtId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenLeistungenBetreuerArtenByKundenLeistungenBetreuerArtId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuerArten>(response);
        }
        partial void OnUpdateKundenLeistungenBetreuerArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateKundenLeistungenBetreuerArten(int? kundenLeistungenBetreuerArtId = default(int?), SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuerArten kundenLeistungenBetreuerArten = default(SinDarElaMobile.Models.DbSinDarEla.KundenLeistungenBetreuerArten))
        {
            var uri = new Uri(baseUri, $"KundenLeistungenBetreuerArtens({kundenLeistungenBetreuerArtId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenLeistungenBetreuerArten), Encoding.UTF8, "application/json");

            OnUpdateKundenLeistungenBetreuerArten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteKundenStatus(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteKundenStatus(int? kundenStatusId = default(int?))
        {
            var uri = new Uri(baseUri, $"KundenStatuses({kundenStatusId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteKundenStatus(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetKundenStatusByKundenStatusId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.KundenStatus> GetKundenStatusByKundenStatusId(string expand = default(string), int? kundenStatusId = default(int?))
        {
            var uri = new Uri(baseUri, $"KundenStatuses({kundenStatusId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKundenStatusByKundenStatusId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.KundenStatus>(response);
        }
        partial void OnUpdateKundenStatus(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateKundenStatus(int? kundenStatusId = default(int?), SinDarElaMobile.Models.DbSinDarEla.KundenStatus kundenStatus = default(SinDarElaMobile.Models.DbSinDarEla.KundenStatus))
        {
            var uri = new Uri(baseUri, $"KundenStatuses({kundenStatusId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(kundenStatus), Encoding.UTF8, "application/json");

            OnUpdateKundenStatus(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitarbeiter(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitarbeiter(int? mitarbeiterId = default(int?))
        {
            var uri = new Uri(baseUri, $"Mitarbeiters({mitarbeiterId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitarbeiter(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitarbeiterByMitarbeiterId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Mitarbeiter> GetMitarbeiterByMitarbeiterId(string expand = default(string), int? mitarbeiterId = default(int?))
        {
            var uri = new Uri(baseUri, $"Mitarbeiters({mitarbeiterId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterByMitarbeiterId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Mitarbeiter>(response);
        }
        partial void OnUpdateMitarbeiter(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitarbeiter(int? mitarbeiterId = default(int?), SinDarElaMobile.Models.DbSinDarEla.Mitarbeiter mitarbeiter = default(SinDarElaMobile.Models.DbSinDarEla.Mitarbeiter))
        {
            var uri = new Uri(baseUri, $"Mitarbeiters({mitarbeiterId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiter), Encoding.UTF8, "application/json");

            OnUpdateMitarbeiter(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitarbeiterArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitarbeiterArten(int? mitarbeiterArtId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterArtens({mitarbeiterArtId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitarbeiterArten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitarbeiterArtenByMitarbeiterArtId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterArten> GetMitarbeiterArtenByMitarbeiterArtId(string expand = default(string), int? mitarbeiterArtId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterArtens({mitarbeiterArtId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterArtenByMitarbeiterArtId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterArten>(response);
        }
        partial void OnUpdateMitarbeiterArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitarbeiterArten(int? mitarbeiterArtId = default(int?), SinDarElaMobile.Models.DbSinDarEla.MitarbeiterArten mitarbeiterArten = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterArten))
        {
            var uri = new Uri(baseUri, $"MitarbeiterArtens({mitarbeiterArtId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterArten), Encoding.UTF8, "application/json");

            OnUpdateMitarbeiterArten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitarbeiterFirmen(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitarbeiterFirmen(int? mitarbeiterFirmaId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterFirmens({mitarbeiterFirmaId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitarbeiterFirmen(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitarbeiterFirmenByMitarbeiterFirmaId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFirmen> GetMitarbeiterFirmenByMitarbeiterFirmaId(string expand = default(string), int? mitarbeiterFirmaId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterFirmens({mitarbeiterFirmaId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterFirmenByMitarbeiterFirmaId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFirmen>(response);
        }
        partial void OnUpdateMitarbeiterFirmen(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitarbeiterFirmen(int? mitarbeiterFirmaId = default(int?), SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFirmen mitarbeiterFirmen = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFirmen))
        {
            var uri = new Uri(baseUri, $"MitarbeiterFirmens({mitarbeiterFirmaId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterFirmen), Encoding.UTF8, "application/json");

            OnUpdateMitarbeiterFirmen(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitarbeiterFortbildungen(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitarbeiterFortbildungen(int? mitarbeiterFortbildungId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterFortbildungens({mitarbeiterFortbildungId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitarbeiterFortbildungen(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitarbeiterFortbildungenByMitarbeiterFortbildungId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungen> GetMitarbeiterFortbildungenByMitarbeiterFortbildungId(string expand = default(string), int? mitarbeiterFortbildungId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterFortbildungens({mitarbeiterFortbildungId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterFortbildungenByMitarbeiterFortbildungId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungen>(response);
        }
        partial void OnUpdateMitarbeiterFortbildungen(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitarbeiterFortbildungen(int? mitarbeiterFortbildungId = default(int?), SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungen mitarbeiterFortbildungen = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungen))
        {
            var uri = new Uri(baseUri, $"MitarbeiterFortbildungens({mitarbeiterFortbildungId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterFortbildungen), Encoding.UTF8, "application/json");

            OnUpdateMitarbeiterFortbildungen(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitarbeiterFortbildungenArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitarbeiterFortbildungenArten(int? fortbildungArtId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterFortbildungenArtens({fortbildungArtId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitarbeiterFortbildungenArten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitarbeiterFortbildungenArtenByFortbildungArtId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungenArten> GetMitarbeiterFortbildungenArtenByFortbildungArtId(string expand = default(string), int? fortbildungArtId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterFortbildungenArtens({fortbildungArtId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterFortbildungenArtenByFortbildungArtId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungenArten>(response);
        }
        partial void OnUpdateMitarbeiterFortbildungenArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitarbeiterFortbildungenArten(int? fortbildungArtId = default(int?), SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungenArten mitarbeiterFortbildungenArten = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterFortbildungenArten))
        {
            var uri = new Uri(baseUri, $"MitarbeiterFortbildungenArtens({fortbildungArtId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterFortbildungenArten), Encoding.UTF8, "application/json");

            OnUpdateMitarbeiterFortbildungenArten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitarbeiterKundenbudget(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitarbeiterKundenbudget(int? mitarbeiterKundenbudgetId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterKundenbudgets({mitarbeiterKundenbudgetId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitarbeiterKundenbudget(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitarbeiterKundenbudgetByMitarbeiterKundenbudgetId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudget> GetMitarbeiterKundenbudgetByMitarbeiterKundenbudgetId(string expand = default(string), int? mitarbeiterKundenbudgetId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterKundenbudgets({mitarbeiterKundenbudgetId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterKundenbudgetByMitarbeiterKundenbudgetId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudget>(response);
        }
        partial void OnUpdateMitarbeiterKundenbudget(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitarbeiterKundenbudget(int? mitarbeiterKundenbudgetId = default(int?), SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudget mitarbeiterKundenbudget = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudget))
        {
            var uri = new Uri(baseUri, $"MitarbeiterKundenbudgets({mitarbeiterKundenbudgetId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterKundenbudget), Encoding.UTF8, "application/json");

            OnUpdateMitarbeiterKundenbudget(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitarbeiterKundenbudgetKategorien(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitarbeiterKundenbudgetKategorien(int? kundenbudgetKategorieId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterKundenbudgetKategoriens({kundenbudgetKategorieId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitarbeiterKundenbudgetKategorien(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitarbeiterKundenbudgetKategorienByKundenbudgetKategorieId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien> GetMitarbeiterKundenbudgetKategorienByKundenbudgetKategorieId(string expand = default(string), int? kundenbudgetKategorieId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterKundenbudgetKategoriens({kundenbudgetKategorieId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterKundenbudgetKategorienByKundenbudgetKategorieId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien>(response);
        }
        partial void OnUpdateMitarbeiterKundenbudgetKategorien(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitarbeiterKundenbudgetKategorien(int? kundenbudgetKategorieId = default(int?), SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien mitarbeiterKundenbudgetKategorien = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien))
        {
            var uri = new Uri(baseUri, $"MitarbeiterKundenbudgetKategoriens({kundenbudgetKategorieId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterKundenbudgetKategorien), Encoding.UTF8, "application/json");

            OnUpdateMitarbeiterKundenbudgetKategorien(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitarbeiterStatus(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitarbeiterStatus(int? mitarbeiterStatusId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterStatuses({mitarbeiterStatusId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitarbeiterStatus(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitarbeiterStatusByMitarbeiterStatusId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterStatus> GetMitarbeiterStatusByMitarbeiterStatusId(string expand = default(string), int? mitarbeiterStatusId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterStatuses({mitarbeiterStatusId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterStatusByMitarbeiterStatusId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterStatus>(response);
        }
        partial void OnUpdateMitarbeiterStatus(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitarbeiterStatus(int? mitarbeiterStatusId = default(int?), SinDarElaMobile.Models.DbSinDarEla.MitarbeiterStatus mitarbeiterStatus = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterStatus))
        {
            var uri = new Uri(baseUri, $"MitarbeiterStatuses({mitarbeiterStatusId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterStatus), Encoding.UTF8, "application/json");

            OnUpdateMitarbeiterStatus(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitarbeiterTaetigkeiten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitarbeiterTaetigkeiten(int? mitarbeiterTaetigkeitenId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterTaetigkeitens({mitarbeiterTaetigkeitenId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitarbeiterTaetigkeiten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitarbeiterTaetigkeitenByMitarbeiterTaetigkeitenId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeiten> GetMitarbeiterTaetigkeitenByMitarbeiterTaetigkeitenId(string expand = default(string), int? mitarbeiterTaetigkeitenId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterTaetigkeitens({mitarbeiterTaetigkeitenId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterTaetigkeitenByMitarbeiterTaetigkeitenId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeiten>(response);
        }
        partial void OnUpdateMitarbeiterTaetigkeiten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitarbeiterTaetigkeiten(int? mitarbeiterTaetigkeitenId = default(int?), SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeiten mitarbeiterTaetigkeiten = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeiten))
        {
            var uri = new Uri(baseUri, $"MitarbeiterTaetigkeitens({mitarbeiterTaetigkeitenId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterTaetigkeiten), Encoding.UTF8, "application/json");

            OnUpdateMitarbeiterTaetigkeiten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitarbeiterTaetigkeitenArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitarbeiterTaetigkeitenArten(int? mitarbeiterTaetigkeitenArtId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterTaetigkeitenArtens({mitarbeiterTaetigkeitenArtId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitarbeiterTaetigkeitenArten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitarbeiterTaetigkeitenArtenByMitarbeiterTaetigkeitenArtId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeitenArten> GetMitarbeiterTaetigkeitenArtenByMitarbeiterTaetigkeitenArtId(string expand = default(string), int? mitarbeiterTaetigkeitenArtId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterTaetigkeitenArtens({mitarbeiterTaetigkeitenArtId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterTaetigkeitenArtenByMitarbeiterTaetigkeitenArtId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeitenArten>(response);
        }
        partial void OnUpdateMitarbeiterTaetigkeitenArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitarbeiterTaetigkeitenArten(int? mitarbeiterTaetigkeitenArtId = default(int?), SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeitenArten mitarbeiterTaetigkeitenArten = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterTaetigkeitenArten))
        {
            var uri = new Uri(baseUri, $"MitarbeiterTaetigkeitenArtens({mitarbeiterTaetigkeitenArtId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterTaetigkeitenArten), Encoding.UTF8, "application/json");

            OnUpdateMitarbeiterTaetigkeitenArten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitarbeiterUrlaub(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitarbeiterUrlaub(int? mitarbeiterUrlaubId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubs({mitarbeiterUrlaubId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitarbeiterUrlaub(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitarbeiterUrlaubByMitarbeiterUrlaubId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaub> GetMitarbeiterUrlaubByMitarbeiterUrlaubId(string expand = default(string), int? mitarbeiterUrlaubId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubs({mitarbeiterUrlaubId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterUrlaubByMitarbeiterUrlaubId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaub>(response);
        }
        partial void OnUpdateMitarbeiterUrlaub(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitarbeiterUrlaub(int? mitarbeiterUrlaubId = default(int?), SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaub mitarbeiterUrlaub = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaub))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubs({mitarbeiterUrlaubId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterUrlaub), Encoding.UTF8, "application/json");

            OnUpdateMitarbeiterUrlaub(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitarbeiterUrlaubDetail(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitarbeiterUrlaubDetail(int? mitarbeiterUrlaubDetailsId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubDetails({mitarbeiterUrlaubDetailsId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitarbeiterUrlaubDetail(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitarbeiterUrlaubDetailByMitarbeiterUrlaubDetailsId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubDetail> GetMitarbeiterUrlaubDetailByMitarbeiterUrlaubDetailsId(string expand = default(string), int? mitarbeiterUrlaubDetailsId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubDetails({mitarbeiterUrlaubDetailsId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterUrlaubDetailByMitarbeiterUrlaubDetailsId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubDetail>(response);
        }
        partial void OnUpdateMitarbeiterUrlaubDetail(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitarbeiterUrlaubDetail(int? mitarbeiterUrlaubDetailsId = default(int?), SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubDetail mitarbeiterUrlaubDetail = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubDetail))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubDetails({mitarbeiterUrlaubDetailsId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterUrlaubDetail), Encoding.UTF8, "application/json");

            OnUpdateMitarbeiterUrlaubDetail(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitarbeiterUrlaubKumuliertAnspruch(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitarbeiterUrlaubKumuliertAnspruch(int? mitarbeiterUrlaubKumuliertAnspruchId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubKumuliertAnspruches({mitarbeiterUrlaubKumuliertAnspruchId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitarbeiterUrlaubKumuliertAnspruch(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitarbeiterUrlaubKumuliertAnspruchByMitarbeiterUrlaubKumuliertAnspruchId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch> GetMitarbeiterUrlaubKumuliertAnspruchByMitarbeiterUrlaubKumuliertAnspruchId(string expand = default(string), int? mitarbeiterUrlaubKumuliertAnspruchId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubKumuliertAnspruches({mitarbeiterUrlaubKumuliertAnspruchId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterUrlaubKumuliertAnspruchByMitarbeiterUrlaubKumuliertAnspruchId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch>(response);
        }
        partial void OnUpdateMitarbeiterUrlaubKumuliertAnspruch(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitarbeiterUrlaubKumuliertAnspruch(int? mitarbeiterUrlaubKumuliertAnspruchId = default(int?), SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch mitarbeiterUrlaubKumuliertAnspruch = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubKumuliertAnspruches({mitarbeiterUrlaubKumuliertAnspruchId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterUrlaubKumuliertAnspruch), Encoding.UTF8, "application/json");

            OnUpdateMitarbeiterUrlaubKumuliertAnspruch(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitarbeiterUrlaubKumuliertDienstzeiten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitarbeiterUrlaubKumuliertDienstzeiten(int? mitarbeiterUrlaubKumuliertDienstzeitenId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubKumuliertDienstzeitens({mitarbeiterUrlaubKumuliertDienstzeitenId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitarbeiterUrlaubKumuliertDienstzeiten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitarbeiterUrlaubKumuliertDienstzeitenByMitarbeiterUrlaubKumuliertDienstzeitenId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten> GetMitarbeiterUrlaubKumuliertDienstzeitenByMitarbeiterUrlaubKumuliertDienstzeitenId(string expand = default(string), int? mitarbeiterUrlaubKumuliertDienstzeitenId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubKumuliertDienstzeitens({mitarbeiterUrlaubKumuliertDienstzeitenId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterUrlaubKumuliertDienstzeitenByMitarbeiterUrlaubKumuliertDienstzeitenId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten>(response);
        }
        partial void OnUpdateMitarbeiterUrlaubKumuliertDienstzeiten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitarbeiterUrlaubKumuliertDienstzeiten(int? mitarbeiterUrlaubKumuliertDienstzeitenId = default(int?), SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten mitarbeiterUrlaubKumuliertDienstzeiten = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten))
        {
            var uri = new Uri(baseUri, $"MitarbeiterUrlaubKumuliertDienstzeitens({mitarbeiterUrlaubKumuliertDienstzeitenId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterUrlaubKumuliertDienstzeiten), Encoding.UTF8, "application/json");

            OnUpdateMitarbeiterUrlaubKumuliertDienstzeiten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitarbeiterVerlaufDienstzeiten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitarbeiterVerlaufDienstzeiten(int? mitarbeiterVerlaufDienstzeitenId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufDienstzeitens({mitarbeiterVerlaufDienstzeitenId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitarbeiterVerlaufDienstzeiten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitarbeiterVerlaufDienstzeitenByMitarbeiterVerlaufDienstzeitenId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten> GetMitarbeiterVerlaufDienstzeitenByMitarbeiterVerlaufDienstzeitenId(string expand = default(string), int? mitarbeiterVerlaufDienstzeitenId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufDienstzeitens({mitarbeiterVerlaufDienstzeitenId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterVerlaufDienstzeitenByMitarbeiterVerlaufDienstzeitenId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten>(response);
        }
        partial void OnUpdateMitarbeiterVerlaufDienstzeiten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitarbeiterVerlaufDienstzeiten(int? mitarbeiterVerlaufDienstzeitenId = default(int?), SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten mitarbeiterVerlaufDienstzeiten = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufDienstzeitens({mitarbeiterVerlaufDienstzeitenId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterVerlaufDienstzeiten), Encoding.UTF8, "application/json");

            OnUpdateMitarbeiterVerlaufDienstzeiten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitarbeiterVerlaufDienstzeitenArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitarbeiterVerlaufDienstzeitenArten(int? mitarbeiterVerlaufDienstzeitenArtId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufDienstzeitenArtens({mitarbeiterVerlaufDienstzeitenArtId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitarbeiterVerlaufDienstzeitenArten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitarbeiterVerlaufDienstzeitenArtenByMitarbeiterVerlaufDienstzeitenArtId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten> GetMitarbeiterVerlaufDienstzeitenArtenByMitarbeiterVerlaufDienstzeitenArtId(string expand = default(string), int? mitarbeiterVerlaufDienstzeitenArtId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufDienstzeitenArtens({mitarbeiterVerlaufDienstzeitenArtId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterVerlaufDienstzeitenArtenByMitarbeiterVerlaufDienstzeitenArtId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten>(response);
        }
        partial void OnUpdateMitarbeiterVerlaufDienstzeitenArten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitarbeiterVerlaufDienstzeitenArten(int? mitarbeiterVerlaufDienstzeitenArtId = default(int?), SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten mitarbeiterVerlaufDienstzeitenArten = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufDienstzeitenArtens({mitarbeiterVerlaufDienstzeitenArtId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterVerlaufDienstzeitenArten), Encoding.UTF8, "application/json");

            OnUpdateMitarbeiterVerlaufDienstzeitenArten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitarbeiterVerlaufGehalt(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitarbeiterVerlaufGehalt(int? mitarbeiterVerlaufGehaltId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufGehalts({mitarbeiterVerlaufGehaltId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitarbeiterVerlaufGehalt(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitarbeiterVerlaufGehaltByMitarbeiterVerlaufGehaltId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufGehalt> GetMitarbeiterVerlaufGehaltByMitarbeiterVerlaufGehaltId(string expand = default(string), int? mitarbeiterVerlaufGehaltId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufGehalts({mitarbeiterVerlaufGehaltId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterVerlaufGehaltByMitarbeiterVerlaufGehaltId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufGehalt>(response);
        }
        partial void OnUpdateMitarbeiterVerlaufGehalt(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitarbeiterVerlaufGehalt(int? mitarbeiterVerlaufGehaltId = default(int?), SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufGehalt mitarbeiterVerlaufGehalt = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufGehalt))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufGehalts({mitarbeiterVerlaufGehaltId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterVerlaufGehalt), Encoding.UTF8, "application/json");

            OnUpdateMitarbeiterVerlaufGehalt(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitarbeiterVerlaufNormalarbeitszeit(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitarbeiterVerlaufNormalarbeitszeit(int? mitarbeiterVerlaufNormalarbeitszeitId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufNormalarbeitszeits({mitarbeiterVerlaufNormalarbeitszeitId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitarbeiterVerlaufNormalarbeitszeit(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitarbeiterVerlaufNormalarbeitszeitByMitarbeiterVerlaufNormalarbeitszeitId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit> GetMitarbeiterVerlaufNormalarbeitszeitByMitarbeiterVerlaufNormalarbeitszeitId(string expand = default(string), int? mitarbeiterVerlaufNormalarbeitszeitId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufNormalarbeitszeits({mitarbeiterVerlaufNormalarbeitszeitId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitarbeiterVerlaufNormalarbeitszeitByMitarbeiterVerlaufNormalarbeitszeitId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit>(response);
        }
        partial void OnUpdateMitarbeiterVerlaufNormalarbeitszeit(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitarbeiterVerlaufNormalarbeitszeit(int? mitarbeiterVerlaufNormalarbeitszeitId = default(int?), SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit mitarbeiterVerlaufNormalarbeitszeit = default(SinDarElaMobile.Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit))
        {
            var uri = new Uri(baseUri, $"MitarbeiterVerlaufNormalarbeitszeits({mitarbeiterVerlaufNormalarbeitszeitId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitarbeiterVerlaufNormalarbeitszeit), Encoding.UTF8, "application/json");

            OnUpdateMitarbeiterVerlaufNormalarbeitszeit(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitteilungen(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitteilungen(int? mitteilungId = default(int?))
        {
            var uri = new Uri(baseUri, $"Mitteilungens({mitteilungId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitteilungen(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitteilungenByMitteilungId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Mitteilungen> GetMitteilungenByMitteilungId(string expand = default(string), int? mitteilungId = default(int?))
        {
            var uri = new Uri(baseUri, $"Mitteilungens({mitteilungId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitteilungenByMitteilungId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Mitteilungen>(response);
        }
        partial void OnUpdateMitteilungen(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitteilungen(int? mitteilungId = default(int?), SinDarElaMobile.Models.DbSinDarEla.Mitteilungen mitteilungen = default(SinDarElaMobile.Models.DbSinDarEla.Mitteilungen))
        {
            var uri = new Uri(baseUri, $"Mitteilungens({mitteilungId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitteilungen), Encoding.UTF8, "application/json");

            OnUpdateMitteilungen(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMitteilungenVerteiler(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMitteilungenVerteiler(int? mitteilungVerteilerId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitteilungenVerteilers({mitteilungVerteilerId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMitteilungenVerteiler(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMitteilungenVerteilerByMitteilungVerteilerId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.MitteilungenVerteiler> GetMitteilungenVerteilerByMitteilungVerteilerId(string expand = default(string), int? mitteilungVerteilerId = default(int?))
        {
            var uri = new Uri(baseUri, $"MitteilungenVerteilers({mitteilungVerteilerId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMitteilungenVerteilerByMitteilungVerteilerId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.MitteilungenVerteiler>(response);
        }
        partial void OnUpdateMitteilungenVerteiler(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMitteilungenVerteiler(int? mitteilungVerteilerId = default(int?), SinDarElaMobile.Models.DbSinDarEla.MitteilungenVerteiler mitteilungenVerteiler = default(SinDarElaMobile.Models.DbSinDarEla.MitteilungenVerteiler))
        {
            var uri = new Uri(baseUri, $"MitteilungenVerteilers({mitteilungVerteilerId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mitteilungenVerteiler), Encoding.UTF8, "application/json");

            OnUpdateMitteilungenVerteiler(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteModule(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteModule(int? modulId = default(int?))
        {
            var uri = new Uri(baseUri, $"Modules({modulId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteModule(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetModuleByModulId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Module> GetModuleByModulId(string expand = default(string), int? modulId = default(int?))
        {
            var uri = new Uri(baseUri, $"Modules({modulId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetModuleByModulId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Module>(response);
        }
        partial void OnUpdateModule(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateModule(int? modulId = default(int?), SinDarElaMobile.Models.DbSinDarEla.Module module = default(SinDarElaMobile.Models.DbSinDarEla.Module))
        {
            var uri = new Uri(baseUri, $"Modules({modulId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(module), Encoding.UTF8, "application/json");

            OnUpdateModule(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteNotizen(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteNotizen(int? notizId = default(int?))
        {
            var uri = new Uri(baseUri, $"Notizens({notizId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteNotizen(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetNotizenByNotizId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Notizen> GetNotizenByNotizId(string expand = default(string), int? notizId = default(int?))
        {
            var uri = new Uri(baseUri, $"Notizens({notizId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetNotizenByNotizId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Notizen>(response);
        }
        partial void OnUpdateNotizen(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateNotizen(int? notizId = default(int?), SinDarElaMobile.Models.DbSinDarEla.Notizen notizen = default(SinDarElaMobile.Models.DbSinDarEla.Notizen))
        {
            var uri = new Uri(baseUri, $"Notizens({notizId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(notizen), Encoding.UTF8, "application/json");

            OnUpdateNotizen(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteProtokoll(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteProtokoll(int? protokollId = default(int?))
        {
            var uri = new Uri(baseUri, $"Protokolls({protokollId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProtokoll(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetProtokollByProtokollId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.Protokoll> GetProtokollByProtokollId(string expand = default(string), int? protokollId = default(int?))
        {
            var uri = new Uri(baseUri, $"Protokolls({protokollId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProtokollByProtokollId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.Protokoll>(response);
        }
        partial void OnUpdateProtokoll(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateProtokoll(int? protokollId = default(int?), SinDarElaMobile.Models.DbSinDarEla.Protokoll protokoll = default(SinDarElaMobile.Models.DbSinDarEla.Protokoll))
        {
            var uri = new Uri(baseUri, $"Protokolls({protokollId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(protokoll), Encoding.UTF8, "application/json");

            OnUpdateProtokoll(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteRegelnAbwesenheiten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteRegelnAbwesenheiten(int? regelnAbwesenheitenId = default(int?))
        {
            var uri = new Uri(baseUri, $"RegelnAbwesenheitens({regelnAbwesenheitenId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteRegelnAbwesenheiten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetRegelnAbwesenheitenByRegelnAbwesenheitenId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SinDarElaMobile.Models.DbSinDarEla.RegelnAbwesenheiten> GetRegelnAbwesenheitenByRegelnAbwesenheitenId(string expand = default(string), int? regelnAbwesenheitenId = default(int?))
        {
            var uri = new Uri(baseUri, $"RegelnAbwesenheitens({regelnAbwesenheitenId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetRegelnAbwesenheitenByRegelnAbwesenheitenId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<SinDarElaMobile.Models.DbSinDarEla.RegelnAbwesenheiten>(response);
        }
        partial void OnUpdateRegelnAbwesenheiten(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateRegelnAbwesenheiten(int? regelnAbwesenheitenId = default(int?), SinDarElaMobile.Models.DbSinDarEla.RegelnAbwesenheiten regelnAbwesenheiten = default(SinDarElaMobile.Models.DbSinDarEla.RegelnAbwesenheiten))
        {
            var uri = new Uri(baseUri, $"RegelnAbwesenheitens({regelnAbwesenheitenId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(regelnAbwesenheiten), Encoding.UTF8, "application/json");

            OnUpdateRegelnAbwesenheiten(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}
