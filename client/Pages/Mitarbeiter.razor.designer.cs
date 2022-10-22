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
    public partial class MitarbeiterComponent : ComponentBase, IDisposable
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
        protected RadzenDataGrid<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiter> gridMitarbeiter;
        protected RadzenDataGrid<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterFirmen> gridFirmen;
        protected RadzenDataGrid<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterTaetigkeiten> gridTaetigkeiten;
        protected RadzenDataGrid<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterKunden> gridKunden;

        SinDarElaMobile.Models.DbSinDarEla.Mitarbeiter _dsoMitarbeiter;
        protected SinDarElaMobile.Models.DbSinDarEla.Mitarbeiter dsoMitarbeiter
        {
            get
            {
                return _dsoMitarbeiter;
            }
            set
            {
                if (!object.Equals(_dsoMitarbeiter, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "dsoMitarbeiter", NewValue = value, OldValue = _dsoMitarbeiter };
                    _dsoMitarbeiter = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        SinDarElaMobile.Models.DbSinDarEla.Base _dsoBase;
        protected SinDarElaMobile.Models.DbSinDarEla.Base dsoBase
        {
            get
            {
                return _dsoBase;
            }
            set
            {
                if (!object.Equals(_dsoBase, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "dsoBase", NewValue = value, OldValue = _dsoBase };
                    _dsoBase = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _strMitarbeiterName;
        protected string strMitarbeiterName
        {
            get
            {
                return _strMitarbeiterName;
            }
            set
            {
                if (!object.Equals(_strMitarbeiterName, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "strMitarbeiterName", NewValue = value, OldValue = _strMitarbeiterName };
                    _strMitarbeiterName = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<SinDarElaMobile.Models.DbSinDarEla.BaseAnreden> _rstBaseAnreden;
        protected IEnumerable<SinDarElaMobile.Models.DbSinDarEla.BaseAnreden> rstBaseAnreden
        {
            get
            {
                return _rstBaseAnreden;
            }
            set
            {
                if (!object.Equals(_rstBaseAnreden, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rstBaseAnreden", NewValue = value, OldValue = _rstBaseAnreden };
                    _rstBaseAnreden = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _txbSuchenMitarbeiter;
        protected string txbSuchenMitarbeiter
        {
            get
            {
                return _txbSuchenMitarbeiter;
            }
            set
            {
                if (!object.Equals(_txbSuchenMitarbeiter, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "txbSuchenMitarbeiter", NewValue = value, OldValue = _txbSuchenMitarbeiter };
                    _txbSuchenMitarbeiter = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiter> _rstVwMitarbeiter;
        protected IEnumerable<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiter> rstVwMitarbeiter
        {
            get
            {
                return _rstVwMitarbeiter;
            }
            set
            {
                if (!object.Equals(_rstVwMitarbeiter, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rstVwMitarbeiter", NewValue = value, OldValue = _rstVwMitarbeiter };
                    _rstVwMitarbeiter = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _rstVwMitarbeiterCount;
        protected int rstVwMitarbeiterCount
        {
            get
            {
                return _rstVwMitarbeiterCount;
            }
            set
            {
                if (!object.Equals(_rstVwMitarbeiterCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rstVwMitarbeiterCount", NewValue = value, OldValue = _rstVwMitarbeiterCount };
                    _rstVwMitarbeiterCount = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterFirmen> _getVwMitarbeiterFirmensResult;
        protected IEnumerable<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterFirmen> getVwMitarbeiterFirmensResult
        {
            get
            {
                return _getVwMitarbeiterFirmensResult;
            }
            set
            {
                if (!object.Equals(_getVwMitarbeiterFirmensResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getVwMitarbeiterFirmensResult", NewValue = value, OldValue = _getVwMitarbeiterFirmensResult };
                    _getVwMitarbeiterFirmensResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterTaetigkeiten> _getVwMitarbeiterTaetigkeitensResult;
        protected IEnumerable<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterTaetigkeiten> getVwMitarbeiterTaetigkeitensResult
        {
            get
            {
                return _getVwMitarbeiterTaetigkeitensResult;
            }
            set
            {
                if (!object.Equals(_getVwMitarbeiterTaetigkeitensResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getVwMitarbeiterTaetigkeitensResult", NewValue = value, OldValue = _getVwMitarbeiterTaetigkeitensResult };
                    _getVwMitarbeiterTaetigkeitensResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterKunden> _getVwMitarbeiterKundensResult;
        protected IEnumerable<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterKunden> getVwMitarbeiterKundensResult
        {
            get
            {
                return _getVwMitarbeiterKundensResult;
            }
            set
            {
                if (!object.Equals(_getVwMitarbeiterKundensResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getVwMitarbeiterKundensResult", NewValue = value, OldValue = _getVwMitarbeiterKundensResult };
                    _getVwMitarbeiterKundensResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bolTest;
        protected bool bolTest
        {
            get
            {
                return _bolTest;
            }
            set
            {
                if (!object.Equals(_bolTest, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bolTest", NewValue = value, OldValue = _bolTest };
                    _bolTest = value;
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
            if (Globals.globalBenutzer == null) {
            UriHelper.NavigateTo("anmeldung-laden");
            }

            try
            {
                if (Globals.globalBenutzer != null)
                {
                    var dbSinDarElaGetMitarbeiterByMitarbeiterIdResult = await DbSinDarEla.GetMitarbeiterByMitarbeiterId(mitarbeiterId:Globals.globalBenutzer.LetzteMitarbeiterID);
                    dsoMitarbeiter = dbSinDarElaGetMitarbeiterByMitarbeiterIdResult;

                    var dbSinDarElaGetBaseByBaseIdResult = await DbSinDarEla.GetBaseByBaseId(baseId:dsoMitarbeiter.BaseID);
                    dsoBase = dbSinDarElaGetBaseByBaseIdResult;

                    strMitarbeiterName = dbSinDarElaGetBaseByBaseIdResult.Name1 + ' ' + dbSinDarElaGetBaseByBaseIdResult.Name2;

                    var dbSinDarElaGetBaseAnredensResult = await DbSinDarEla.GetBaseAnredens();
                    rstBaseAnreden = dbSinDarElaGetBaseAnredensResult.Value.AsODataEnumerable();
                }
            }
            catch (System.Exception dbSinDarElaGetMitarbeiterByMitarbeiterIdException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Detail = $"Kein Mitarbeiter ausgewählt!" });

            strMitarbeiterName = "Klicke auf [Suchen] um einen Mitarbeiter auszuwählen!";
            }

            if (string.IsNullOrEmpty(txbSuchenMitarbeiter)) {
                txbSuchenMitarbeiter = "";
            }
        }

        protected async System.Threading.Tasks.Task ButtonBerichreClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<MeldungOk>($"Info", new Dictionary<string, object>() { {"strMeldung", "Berichte ist für dieses Modul noch nicht aktiviert!"} }, new DialogOptions(){ Width = $"{600}px" });
        }

        protected async System.Threading.Tasks.Task ButtonListenClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<MitarbeiterListen>($"Listen Mitarbeiter", null, new DialogOptions(){ Width = $"{1700}px",AutoFocusFirstElement = false,Resizable = true,Draggable = true });
        }

        protected async System.Threading.Tasks.Task ButtonSuchenClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<MitarbeiterSuchen>($"Suchen", null, new DialogOptions(){ Width = $"{350}px",AutoFocusFirstElement = false,Draggable = true });
            if (dialogResult != null) {
                Globals.globalBenutzer.LetzteMitarbeiterID = dialogResult;
            }

            if (dialogResult != null)
            {
                await Load();
            }
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            UriHelper.NavigateTo("dashboard");
        }

        protected async System.Threading.Tasks.Task GridMitarbeiterLoadData(LoadDataArgs args)
        {
            try
            {
                var dbSinDarElaGetVwMitarbeitersResult = await DbSinDarEla.GetVwMitarbeiters(filter:$@"(contains(NameGesamt,""{txbSuchenMitarbeiter}"") or contains(Strasse,""{txbSuchenMitarbeiter}"") or contains(PLZ,""{txbSuchenMitarbeiter}"") or contains(Ort,""{txbSuchenMitarbeiter}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$@"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                rstVwMitarbeiter = dbSinDarElaGetVwMitarbeitersResult.Value.AsODataEnumerable();

                rstVwMitarbeiterCount = dbSinDarElaGetVwMitarbeitersResult.Count;
            }
            catch (System.Exception dbSinDarElaGetVwMitarbeitersException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load VwMitarbeiters" });
            }
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await DbSinDarEla.ExportVwMitarbeitersToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(gridMitarbeiter.Query.Filter)? "true" : gridMitarbeiter.Query.Filter)}", OrderBy = $"{gridMitarbeiter.Query.OrderBy}", Expand = "", Select = "NameGesamt,MitarbeiterArt,Anrede,NameKuerzel,TitelVorne,TitelHinten,Strasse,PLZ,Ort,Geburtsdatum,Versicherungsnummer,Staatsangehoerigkeit,Telefon1,Telefon2,EMail1,EMail2,Notiz,KontoName,KontoNummer,KontoInfo,Notfallkontakt,NotfallkontaktTelefon" }, $"VwMitarbeiter");

            }

            if (args == null || args.Value == "xlsx")
            {
                await DbSinDarEla.ExportVwMitarbeitersToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(gridMitarbeiter.Query.Filter)? "true" : gridMitarbeiter.Query.Filter)}", OrderBy = $"{gridMitarbeiter.Query.OrderBy}", Expand = "", Select = "NameGesamt,MitarbeiterArt,Anrede,NameKuerzel,TitelVorne,TitelHinten,Strasse,PLZ,Ort,Geburtsdatum,Versicherungsnummer,Staatsangehoerigkeit,Telefon1,Telefon2,EMail1,EMail2,Notiz,KontoName,KontoNummer,KontoInfo,Notfallkontakt,NotfallkontaktTelefon" }, $"VwMitarbeiter");

            }
        }

        protected async System.Threading.Tasks.Task GridFirmenLoadData(LoadDataArgs args)
        {
            try
            {
                var dbSinDarElaGetVwMitarbeiterFirmensResult = await DbSinDarEla.GetVwMitarbeiterFirmens(filter:$"MitarbeiterID eq {Globals.globalBenutzer.LetzteMitarbeiterID}");
                getVwMitarbeiterFirmensResult = dbSinDarElaGetVwMitarbeiterFirmensResult.Value.AsODataEnumerable();
            }
            catch (System.Exception dbSinDarElaGetVwMitarbeiterFirmensException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load VwMitarbeiterFirmens" });
            }
        }

        protected async System.Threading.Tasks.Task GridTaetigkeitenLoadData(LoadDataArgs args)
        {
            try
            {
                var dbSinDarElaGetVwMitarbeiterTaetigkeitensResult = await DbSinDarEla.GetVwMitarbeiterTaetigkeitens(filter:$"MitarbeiterID eq {Globals.globalBenutzer.LetzteMitarbeiterID}");
                getVwMitarbeiterTaetigkeitensResult = dbSinDarElaGetVwMitarbeiterTaetigkeitensResult.Value.AsODataEnumerable();
            }
            catch (System.Exception dbSinDarElaGetVwMitarbeiterTaetigkeitensException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load VwMitarbeiterTaetigkeitens" });
            }
        }

        protected async System.Threading.Tasks.Task GridKundenLoadData(LoadDataArgs args)
        {
            try
            {
                var dbSinDarElaGetVwMitarbeiterKundensResult = await DbSinDarEla.GetVwMitarbeiterKundens(filter:$"MitarbeiterID eq {Globals.globalBenutzer.LetzteMitarbeiterID}");
                getVwMitarbeiterKundensResult = dbSinDarElaGetVwMitarbeiterKundensResult.Value.AsODataEnumerable();
            }
            catch (System.Exception dbSinDarElaGetVwMitarbeiterKundensException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load VwMitarbeiterKundens" });
            }
        }

        protected async System.Threading.Tasks.Task GridKundenRowSelect(SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterKunden args)
        {
            bolTest = false;
        }
    }
}
