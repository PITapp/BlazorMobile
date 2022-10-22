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
    public partial class AnmeldungComponent : ComponentBase, IDisposable
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

        bool _bolSichtbarProgressBar;
        protected bool bolSichtbarProgressBar
        {
            get
            {
                return _bolSichtbarProgressBar;
            }
            set
            {
                if (!object.Equals(_bolSichtbarProgressBar, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bolSichtbarProgressBar", NewValue = value, OldValue = _bolSichtbarProgressBar };
                    _bolSichtbarProgressBar = value;
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

        bool _bolAnmeldungOK;
        protected bool bolAnmeldungOK
        {
            get
            {
                return _bolAnmeldungOK;
            }
            set
            {
                if (!object.Equals(_bolAnmeldungOK, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bolAnmeldungOK", NewValue = value, OldValue = _bolAnmeldungOK };
                    _bolAnmeldungOK = value;
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
            bolSichtbarProgressBar = false;
        }

        protected async System.Threading.Tasks.Task Login0Login(dynamic args)
        {
            bolSichtbarProgressBar = true;

            try
            {
                var dbSinDarElaGetBenutzersResult = await DbSinDarEla.GetBenutzers(filter:$"Benutzername eq '{args.Username}'", expand:$"Base", count:true);
                intBenutzerAnzahl = dbSinDarElaGetBenutzersResult.Count;

                if (intBenutzerAnzahl == 1) {
                    Globals.globalBenutzer = dbSinDarElaGetBenutzersResult.Value.AsODataEnumerable().FirstOrDefault();
                }

                bolAnmeldungOK = false;

                Console.WriteLine("Start---123");
Console.WriteLine("1---" + Globals.globalBenutzer.BaseID + "---" + Globals.globalBenutzer.Kennwort + "---" + args.Password + "---" + GetDeterministicHashCode(Globals.globalBenutzer.BaseID.ToString()));

                if (intBenutzerAnzahl == 1) {
                    bolAnmeldungOK = Globals.globalBenutzer.Kennwort == GetDeterministicHashCode(args.Password + Globals.globalBenutzer.BaseID.ToString());
                }

                Console.WriteLine("2");

                if (bolAnmeldungOK == true)
                {
                    await WriteLocalStorage("storageBenutzerIDCode", Globals.globalBenutzer.BenutzerIDCode);
                }

                Console.WriteLine("3");

                if (bolAnmeldungOK == true) {
                    dsoBenutzerProtokoll = new SinDarElaMobile.Models.DbSinDarEla.BenutzerProtokoll(){};
                }

                if (bolAnmeldungOK == true)
                {
                    dsoBenutzerProtokoll.BenutzerID = Globals.globalBenutzer.BenutzerID;
dsoBenutzerProtokoll.Art = "Anmeldung";
dsoBenutzerProtokoll.TimeStamp = DateTime.Now;
                }

                if (bolAnmeldungOK == true)
                {
                    var dbSinDarElaCreateBenutzerProtokollResult = await DbSinDarEla.CreateBenutzerProtokoll(benutzerProtokoll:dsoBenutzerProtokoll);

                }

                if (bolAnmeldungOK == true) {
                UriHelper.NavigateTo("dashboard");
                }

                if (bolAnmeldungOK == false)
                {
                    NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Detail = $"Benutzername oder Kennwort falsch!" });
                }

                if (bolAnmeldungOK == false) {
                    bolSichtbarProgressBar = false;
                }
            }
            catch (System.Exception dbSinDarElaGetBenutzersException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Laden Benutzer fehlerhaft!",Detail = $"{dbSinDarElaGetBenutzersException.Message}" });

            bolSichtbarProgressBar = false;
            }
        }
    }
}
