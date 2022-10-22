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
    public partial class CopyOfMitarbeiterListeComponent : ComponentBase, IDisposable
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

        int _intMitarbeiterID;
        protected int intMitarbeiterID
        {
            get
            {
                return _intMitarbeiterID;
            }
            set
            {
                if (!object.Equals(_intMitarbeiterID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "intMitarbeiterID", NewValue = value, OldValue = _intMitarbeiterID };
                    _intMitarbeiterID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiter> _rstMitarbeiter;
        protected IEnumerable<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiter> rstMitarbeiter
        {
            get
            {
                return _rstMitarbeiter;
            }
            set
            {
                if (!object.Equals(_rstMitarbeiter, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rstMitarbeiter", NewValue = value, OldValue = _rstMitarbeiter };
                    _rstMitarbeiter = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _rstMitarbeiterCount;
        protected int rstMitarbeiterCount
        {
            get
            {
                return _rstMitarbeiterCount;
            }
            set
            {
                if (!object.Equals(_rstMitarbeiterCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rstMitarbeiterCount", NewValue = value, OldValue = _rstMitarbeiterCount };
                    _rstMitarbeiterCount = value;
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
            intMitarbeiterID = 0;
        }

        protected async System.Threading.Tasks.Task GridMitarbeiterLoadData(LoadDataArgs args)
        {
            try
            {
                var dbSinDarElaGetVwMitarbeitersResult = await DbSinDarEla.GetVwMitarbeiters(filter:$"{args.Filter}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                rstMitarbeiter = dbSinDarElaGetVwMitarbeitersResult.Value.AsODataEnumerable();

                rstMitarbeiterCount = dbSinDarElaGetVwMitarbeitersResult.Count;
            }
            catch (System.Exception dbSinDarElaGetVwMitarbeitersException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load VwMitarbeiters" });
            }
        }

        protected async System.Threading.Tasks.Task ButtonUebernehmenClick(MouseEventArgs args)
        {
            if (intMitarbeiterID != 0) {
              DialogService.Close(intMitarbeiterID);
            }
        }

        protected async System.Threading.Tasks.Task ButtonAbbruchClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
