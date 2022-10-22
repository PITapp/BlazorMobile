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
    public partial class AnmeldungLadenComponent : ComponentBase, IDisposable
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

        string _strBenutzerIDCode;
        protected string strBenutzerIDCode
        {
            get
            {
                return _strBenutzerIDCode;
            }
            set
            {
                if (!object.Equals(_strBenutzerIDCode, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "strBenutzerIDCode", NewValue = value, OldValue = _strBenutzerIDCode };
                    _strBenutzerIDCode = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _intBenutzerAnzahl;
        protected int intBenutzerAnzahl
        {
            get
            {
                return _intBenutzerAnzahl;
            }
            set
            {
                if (!object.Equals(_intBenutzerAnzahl, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "intBenutzerAnzahl", NewValue = value, OldValue = _intBenutzerAnzahl };
                    _intBenutzerAnzahl = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

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
            strBenutzerIDCode = await ReadLocalStorage("storageBenutzerIDCode");

            var dbSinDarElaGetBenutzersResult = await DbSinDarEla.GetBenutzers(filter:$"BenutzerIDCode eq '{strBenutzerIDCode}'", expand:$"Base", count:true);
            intBenutzerAnzahl = dbSinDarElaGetBenutzersResult.Count;

            if (intBenutzerAnzahl == 1) {
                Globals.globalBenutzer = dbSinDarElaGetBenutzersResult.Value.AsODataEnumerable().FirstOrDefault();
            }

            if (intBenutzerAnzahl == 1) {
                dsoBenutzerProtokoll = new SinDarElaMobile.Models.DbSinDarEla.BenutzerProtokoll(){};
            }

            if (intBenutzerAnzahl == 1)
            {
                dsoBenutzerProtokoll.BenutzerID = Globals.globalBenutzer.BenutzerID;
dsoBenutzerProtokoll.Art = "AutomatischeAnmeldung";
dsoBenutzerProtokoll.TimeStamp = DateTime.Now;
            }

            if (intBenutzerAnzahl == 1)
            {
                var dbSinDarElaCreateBenutzerProtokollResult = await DbSinDarEla.CreateBenutzerProtokoll(benutzerProtokoll:dsoBenutzerProtokoll);

            }

            if (intBenutzerAnzahl == 1) {
            UriHelper.NavigateTo("dashboard");
            }

            if (intBenutzerAnzahl != 1) {
            UriHelper.NavigateTo("anmeldung");
            }
        }
    }
}
