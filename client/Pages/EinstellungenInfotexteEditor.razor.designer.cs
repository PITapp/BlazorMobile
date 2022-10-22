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
    public partial class EinstellungenInfotexteEditorComponent : ComponentBase, IDisposable
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

        [Parameter]
        public dynamic InfotextID { get; set; }

        bool _bolEditorAenderungen;
        protected bool bolEditorAenderungen
        {
            get
            {
                return _bolEditorAenderungen;
            }
            set
            {
                if (!object.Equals(_bolEditorAenderungen, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bolEditorAenderungen", NewValue = value, OldValue = _bolEditorAenderungen };
                    _bolEditorAenderungen = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml _dsoInfotexteHTML;
        protected SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml dsoInfotexteHTML
        {
            get
            {
                return _dsoInfotexteHTML;
            }
            set
            {
                if (!object.Equals(_dsoInfotexteHTML, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "dsoInfotexteHTML", NewValue = value, OldValue = _dsoInfotexteHTML };
                    _dsoInfotexteHTML = value;
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

        string _strInhalt;
        protected string strInhalt
        {
            get
            {
                return _strInhalt;
            }
            set
            {
                if (!object.Equals(_strInhalt, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "strInhalt", NewValue = value, OldValue = _strInhalt };
                    _strInhalt = value;
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
            bolEditorAenderungen = false;

            var dbSinDarElaGetInfotexteHtmlByInfotextIdResult = await DbSinDarEla.GetInfotexteHtmlByInfotextId(infotextId:InfotextID);
            dsoInfotexteHTML = dbSinDarElaGetInfotexteHtmlByInfotextIdResult;

            strTitel = dbSinDarElaGetInfotexteHtmlByInfotextIdResult.Titel;

            strInhalt = dbSinDarElaGetInfotexteHtmlByInfotextIdResult.Inhalt;
        }

        protected async System.Threading.Tasks.Task HtmlEditor0Change(string args)
        {
            bolEditorAenderungen = true;
        }

        protected async System.Threading.Tasks.Task ButtonKopierenClick(MouseEventArgs args)
        {
            await CopyTextToClipboard(strInhalt);
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            try
            {
                var dbSinDarElaUpdateInfotexteHtmlResult = await DbSinDarEla.UpdateInfotexteHtml(infotextId:InfotextID, infotexteHtml:dsoInfotexteHTML);
                    NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Success,Detail = $"Infotext gespeichert" });

                DialogService.Close(dbSinDarElaUpdateInfotexteHtmlResult);
            }
            catch (System.Exception dbSinDarElaUpdateInfotexteHtmlException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Detail = $"Infotext konnte nicht gespeichert werden!" });
            }
        }

        protected async System.Threading.Tasks.Task Button1Click(MouseEventArgs args)
        {
            if (bolEditorAenderungen == false) {
              DialogService.Close(null);
            }

            if (bolEditorAenderungen == true) {
              var dialogResult = await DialogService.OpenAsync<MeldungJaNein>($"Text geändert", new Dictionary<string, object>() { {"strMeldung", "Der Text wurde geändert! Soll die Bearbeitung wirklich abgebrochen werden?"} }, new DialogOptions(){ Width = $"{720}px",AutoFocusFirstElement = false,CloseDialogOnEsc = false });
                if (dialogResult == "Ja") {
                  DialogService.Close(null);
                }
            }
        }
    }
}
