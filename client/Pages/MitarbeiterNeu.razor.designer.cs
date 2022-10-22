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
    public partial class MitarbeiterNeuComponent : ComponentBase, IDisposable
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

        IEnumerable<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterNeu> _rstMitarbeiterNeu;
        protected IEnumerable<SinDarElaMobile.Models.DbSinDarEla.VwMitarbeiterNeu> rstMitarbeiterNeu
        {
            get
            {
                return _rstMitarbeiterNeu;
            }
            set
            {
                if (!object.Equals(_rstMitarbeiterNeu, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rstMitarbeiterNeu", NewValue = value, OldValue = _rstMitarbeiterNeu };
                    _rstMitarbeiterNeu = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterArten> _rstMitarbeiterArten;
        protected IEnumerable<SinDarElaMobile.Models.DbSinDarEla.MitarbeiterArten> rstMitarbeiterArten
        {
            get
            {
                return _rstMitarbeiterArten;
            }
            set
            {
                if (!object.Equals(_rstMitarbeiterArten, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rstMitarbeiterArten", NewValue = value, OldValue = _rstMitarbeiterArten };
                    _rstMitarbeiterArten = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

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

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            Globals.PropertyChanged += OnPropertyChanged;
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var dbSinDarElaGetVwMitarbeiterNeusResult = await DbSinDarEla.GetVwMitarbeiterNeus();
            rstMitarbeiterNeu = dbSinDarElaGetVwMitarbeiterNeusResult.Value.AsODataEnumerable();

            var dbSinDarElaGetMitarbeiterArtensResult = await DbSinDarEla.GetMitarbeiterArtens(orderby:$"Sortierung");
            rstMitarbeiterArten = dbSinDarElaGetMitarbeiterArtensResult.Value.AsODataEnumerable();

            dsoMitarbeiter = new SinDarElaMobile.Models.DbSinDarEla.Mitarbeiter(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(SinDarElaMobile.Models.DbSinDarEla.Mitarbeiter args)
        {
            try
            {
                var dbSinDarElaCreateMitarbeiterResult = await DbSinDarEla.CreateMitarbeiter(mitarbeiter:dsoMitarbeiter);
                DialogService.Close(dbSinDarElaCreateMitarbeiterResult);
            }
            catch (System.Exception dbSinDarElaCreateMitarbeiterException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Mitarbeiter konnte nicht erstellt werden!" });
            }
        }

        protected async System.Threading.Tasks.Task Button1Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
