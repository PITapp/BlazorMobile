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
    public partial class AbmeldungComponent : ComponentBase, IDisposable
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

        SinDarElaMobile.Models.DbSinDarEla.BenutzerProtokoll _dsoBenutzerProtokoll;
        protected SinDarElaMobile.Models.DbSinDarEla.BenutzerProtokoll dsoBenutzerProtokoll
        {
            get
            {
                return _dsoBenutzerProtokoll;
            }
            set
            {
                if (!object.Equals(_dsoBenutzerProtokoll, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "dsoBenutzerProtokoll", NewValue = value, OldValue = _dsoBenutzerProtokoll };
                    _dsoBenutzerProtokoll = value;
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
            await RemoveLocalStorage("storageBenutzerIDCode");

            dsoBenutzerProtokoll = new SinDarElaMobile.Models.DbSinDarEla.BenutzerProtokoll(){};

            dsoBenutzerProtokoll.BenutzerID = Globals.globalBenutzer.BenutzerID;
dsoBenutzerProtokoll.Art = "Abmeldung";
dsoBenutzerProtokoll.TimeStamp = DateTime.Now;

            var dbSinDarElaCreateBenutzerProtokollResult = await DbSinDarEla.CreateBenutzerProtokoll(benutzerProtokoll:dsoBenutzerProtokoll);
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            UriHelper.NavigateTo("anmeldung");
        }
    }
}
