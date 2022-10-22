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
    public partial class ZzAutomatischErzeugenComponent : ComponentBase, IDisposable
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

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            Globals.PropertyChanged += OnPropertyChanged;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            await DialogService.OpenAsync<MeldungFortschritt>("MeldungFortschritt", new Dictionary<string, object>() { {"strMeldung", "Test..."} });
        }

        protected async System.Threading.Tasks.Task Button1Click(MouseEventArgs args)
        {
            await DialogService.OpenAsync<MeldungJaNein>("MeldungJaNein", new Dictionary<string, object>() { {"strMeldung", "Test..."} });
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            await DialogService.OpenAsync<MeldungLoeschen>("MeldungLoeschen", new Dictionary<string, object>() { {"strMeldung", "Test..."} });
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            await DialogService.OpenAsync<MeldungOk>("MeldungOK", new Dictionary<string, object>() { {"strMeldung", "Test..."} });
        }
    }
}
