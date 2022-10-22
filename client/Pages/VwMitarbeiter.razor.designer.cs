using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using SinDarElaMobile.Models.DbSinDarEla;
using SinDarElaMobile.Client.Pages;

namespace SinDarElaMobile.Pages
{
    public partial class VwMitarbeiterComponent : ComponentBase, IDisposable
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        [Inject]
        protected GlobalsService Globals { get; set; }

        partial void OnDispose();

        public void Dispose()
        {
            Globals.PropertyChanged -= OnPropertyChanged;
            OnDispose();
        }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected DbSinDarElaService DbSinDarEla { get; set; }
        protected RadzenDataGrid<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiter> grid0;

        string _search;
        protected string search
        {
            get
            {
                return _search;
            }
            set
            {
                if (!object.Equals(_search, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "search", NewValue = value, OldValue = _search };
                    _search = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiter> _getVwMitarbeitersResult;
        protected IEnumerable<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiter> getVwMitarbeitersResult
        {
            get
            {
                return _getVwMitarbeitersResult;
            }
            set
            {
                if (!object.Equals(_getVwMitarbeitersResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getVwMitarbeitersResult", NewValue = value, OldValue = _getVwMitarbeitersResult };
                    _getVwMitarbeitersResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getVwMitarbeitersCount;
        protected int getVwMitarbeitersCount
        {
            get
            {
                return _getVwMitarbeitersCount;
            }
            set
            {
                if (!object.Equals(_getVwMitarbeitersCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getVwMitarbeitersCount", NewValue = value, OldValue = _getVwMitarbeitersCount };
                    _getVwMitarbeitersCount = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            Globals.PropertyChanged += OnPropertyChanged;
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            if (string.IsNullOrEmpty(search)) {
                search = "";
            }
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await DbSinDarEla.ExportVwMitarbeitersToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "NameGesamt,MitarbeiterArt,Anrede,NameKuerzel,TitelVorne,TitelHinten,Strasse,PLZ,Ort,Geburtsdatum,Versicherungsnummer,Staatsangehoerigkeit,Telefon1,Telefon2,EMail1,EMail2,Notiz,KontoName,KontoNummer,KontoInfo,Notfallkontakt,NotfallkontaktTelefon" }, $"Vw Mitarbeiter");

            }

            if (args == null || args.Value == "xlsx")
            {
                await DbSinDarEla.ExportVwMitarbeitersToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "NameGesamt,MitarbeiterArt,Anrede,NameKuerzel,TitelVorne,TitelHinten,Strasse,PLZ,Ort,Geburtsdatum,Versicherungsnummer,Staatsangehoerigkeit,Telefon1,Telefon2,EMail1,EMail2,Notiz,KontoName,KontoNummer,KontoInfo,Notfallkontakt,NotfallkontaktTelefon" }, $"Vw Mitarbeiter");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var dbSinDarElaGetVwMitarbeitersResult = await DbSinDarEla.GetVwMitarbeiters(filter:$@"(contains(NameGesamt,""{search}"") or contains(MitarbeiterArt,""{search}"") or contains(Anrede,""{search}"") or contains(Name1,""{search}"") or contains(Name2,""{search}"") or contains(NameKuerzel,""{search}"") or contains(TitelVorne,""{search}"") or contains(TitelHinten,""{search}"") or contains(Strasse,""{search}"") or contains(PLZ,""{search}"") or contains(Ort,""{search}"") or contains(Versicherungsnummer,""{search}"") or contains(Staatsangehoerigkeit,""{search}"") or contains(Telefon1,""{search}"") or contains(Telefon2,""{search}"") or contains(EMail1,""{search}"") or contains(EMail2,""{search}"") or contains(Notiz,""{search}"") or contains(KontoName,""{search}"") or contains(KontoNummer,""{search}"") or contains(KontoInfo,""{search}"") or contains(Notfallkontakt,""{search}"") or contains(NotfallkontaktTelefon,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getVwMitarbeitersResult = dbSinDarElaGetVwMitarbeitersResult.Value.AsODataEnumerable();

                getVwMitarbeitersCount = dbSinDarElaGetVwMitarbeitersResult.Count;
            }
            catch (System.Exception dbSinDarElaGetVwMitarbeitersException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load VwMitarbeiters" });
            }
        }
    }
}
