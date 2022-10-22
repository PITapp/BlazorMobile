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
    public partial class EinstellungenInfotexteNeuComponent : ComponentBase, IDisposable
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

        SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml _dsoInfotexte;
        protected SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml dsoInfotexte
        {
            get
            {
                return _dsoInfotexte;
            }
            set
            {
                if (!object.Equals(_dsoInfotexte, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "dsoInfotexte", NewValue = value, OldValue = _dsoInfotexte };
                    _dsoInfotexte = value;
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
            dsoInfotexte = new SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(SinDarElaMobile.Models.DbSinDarEla.InfotexteHtml args)
        {
            try
            {
                var dbSinDarElaCreateInfotexteHtmlResult = await DbSinDarEla.CreateInfotexteHtml(infotexteHtml:dsoInfotexte);
                    NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Success,Detail = $"Infotext erstellt" });

                DialogService.Close(dbSinDarElaCreateInfotexteHtmlResult);
            }
            catch (System.Exception dbSinDarElaCreateInfotexteHtmlException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Detail = $"Infotext konnte nicht erstellt werden!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
