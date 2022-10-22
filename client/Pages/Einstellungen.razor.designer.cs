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
    public partial class EinstellungenComponent : ComponentBase, IDisposable
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
        protected RadzenDataGrid<SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml> datagridInfotexte;

        int _intLetzteInfotextID;
        protected int intLetzteInfotextID
        {
            get
            {
                return _intLetzteInfotextID;
            }
            set
            {
                if (!object.Equals(_intLetzteInfotextID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "intLetzteInfotextID", NewValue = value, OldValue = _intLetzteInfotextID };
                    _intLetzteInfotextID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml> _rstInfotexte;
        protected IEnumerable<SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml> rstInfotexte
        {
            get
            {
                return _rstInfotexte;
            }
            set
            {
                if (!object.Equals(_rstInfotexte, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rstInfotexte", NewValue = value, OldValue = _rstInfotexte };
                    _rstInfotexte = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _rstInfotexteCount;
        protected int rstInfotexteCount
        {
            get
            {
                return _rstInfotexteCount;
            }
            set
            {
                if (!object.Equals(_rstInfotexteCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rstInfotexteCount", NewValue = value, OldValue = _rstInfotexteCount };
                    _rstInfotexteCount = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        dynamic _findInfotext;
        protected dynamic findInfotext
        {
            get
            {
                return _findInfotext;
            }
            set
            {
                if (!object.Equals(_findInfotext, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "findInfotext", NewValue = value, OldValue = _findInfotext };
                    _findInfotext = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _strTitel;
        protected string strTitel
        {
            get
            {
                return _strTitel;
            }
            set
            {
                if (!object.Equals(_strTitel, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "strTitel", NewValue = value, OldValue = _strTitel };
                    _strTitel = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _strTextHTML;
        protected string strTextHTML
        {
            get
            {
                return _strTextHTML;
            }
            set
            {
                if (!object.Equals(_strTextHTML, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "strTextHTML", NewValue = value, OldValue = _strTextHTML };
                    _strTextHTML = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _intInfotextID;
        protected int intInfotextID
        {
            get
            {
                return _intInfotextID;
            }
            set
            {
                if (!object.Equals(_intInfotextID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "intInfotextID", NewValue = value, OldValue = _intInfotextID };
                    _intInfotextID = value;
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

            intLetzteInfotextID = 0;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            await DialogService.OpenAsync<MeldungOk>($"Info", new Dictionary<string, object>() { {"strMeldung", "Drucken ist für dieses Modul noch nicht aktiviert!"} }, new DialogOptions(){ Width = $"{600}px" });
        }

        protected async System.Threading.Tasks.Task DatagridInfotexteLoadData(LoadDataArgs args)
        {
            var dbSinDarElaGetInfotexteHtmlsResult = await DbSinDarEla.GetInfotexteHtmls(filter:$@"{args.Filter}", orderby:$"Titel", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
            rstInfotexte = dbSinDarElaGetInfotexteHtmlsResult.Value.AsODataEnumerable();

            rstInfotexteCount = dbSinDarElaGetInfotexteHtmlsResult.Count;

            findInfotext = rstInfotexte.FirstOrDefault(x => x.InfotextID == intLetzteInfotextID);

            if (findInfotext == null) {
                findInfotext = rstInfotexte.FirstOrDefault();
            }

            await datagridInfotexte.SelectRow(findInfotext);
        }

        protected async System.Threading.Tasks.Task DatagridInfotexteRowDoubleClick(DataGridRowMouseEventArgs<SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml> args)
        {
            var dialogResult = await DialogService.OpenAsync<EinstellungenInfotexteBearbeiten>($"Bearbeiten Infotext", new Dictionary<string, object>() { {"InfotextID", intInfotextID} });
            if (dialogResult != null) {
                intLetzteInfotextID = dialogResult.InfotextID;
            }

            if (dialogResult != null)
            {
                await datagridInfotexte.Reload();
            }

            if (dialogResult != null)
            {
                await InvokeAsync(() => { StateHasChanged(); });
            }
        }

        protected async System.Threading.Tasks.Task DatagridInfotexteRowSelect(SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml args)
        {
            strTitel = args.Titel;

            strTextHTML = args.Inhalt;

            intInfotextID = args.InfotextID;
        }

        protected async System.Threading.Tasks.Task ButtonNeuerInfotextClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<EinstellungenInfotexteNeu>($"Neuer Infotext", null);
            if (dialogResult != null) {
                intLetzteInfotextID = dialogResult.InfotextID;
            }

            if (dialogResult != null)
            {
                await datagridInfotexte.Reload();
            }

            if (dialogResult != null)
            {
                await InvokeAsync(() => { StateHasChanged(); });
            }
        }

        protected async System.Threading.Tasks.Task ButtonBearbeitenInfotextClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<EinstellungenInfotexteBearbeiten>($"Bearbeiten Infotext", new Dictionary<string, object>() { {"InfotextID", intInfotextID} });
            if (dialogResult != null) {
                intLetzteInfotextID = dialogResult.InfotextID;
            }

            if (dialogResult != null)
            {
                await datagridInfotexte.Reload();
            }

            if (dialogResult != null)
            {
                await InvokeAsync(() => { StateHasChanged(); });
            }
        }

        protected async System.Threading.Tasks.Task ButtonLoeschenInfotextClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<MeldungLoeschen>($"Löschen Infotext", new Dictionary<string, object>() { {"strMeldung", "Soll der Infotext '" + strTitel + "' gelöscht werden?"} });
            try
            {
                if (dialogResult == "Löschen")
                {
                    var dbSinDarElaDeleteInfotexteHtmlResult = await DbSinDarEla.DeleteInfotexteHtml(infotextId:intInfotextID);
                    intLetzteInfotextID = 0;

                    await datagridInfotexte.Reload();

                    await InvokeAsync(() => { StateHasChanged(); });

                        NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Success,Detail = $"Infotext gelöscht" });
                }
            }
            catch (System.Exception dbSinDarElaDeleteInfotexteHtmlException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Detail = $"Infotext konnte nicht gelöscht werden!" });
            }
        }

        protected async System.Threading.Tasks.Task ButtonKopierenClick(MouseEventArgs args)
        {
            await CopyTextToClipboard(strTextHTML);
        }

        protected async System.Threading.Tasks.Task ButtonBearbeitenInfotextEditorClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<EinstellungenInfotexteEditor>($"Bearbeiten", new Dictionary<string, object>() { {"InfotextID", intInfotextID} }, new DialogOptions(){ Width = $"{725}px",AutoFocusFirstElement = false,CloseDialogOnEsc = false,Resizable = true,Draggable = true });
        }
    }
}
