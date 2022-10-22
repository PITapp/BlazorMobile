using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SinDarElaMobile.Models;
using SinDarElaMobile.Models.DbSinDarEla;
using Radzen;

namespace SinDarElaMobile
{
    public partial class GlobalsService
    {
        public event Action<PropertyChangedEventArgs> PropertyChanged;


        SinDarElaMobile.Models.DbSinDarEla.Benutzer _globalBenutzer;
        public SinDarElaMobile.Models.DbSinDarEla.Benutzer globalBenutzer
        {
            get
            {
                return _globalBenutzer;
            }
            set
            {
                if(!object.Equals(_globalBenutzer, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "globalBenutzer", NewValue = value, OldValue = _globalBenutzer, IsGlobal = true };
                    _globalBenutzer = value;
                    PropertyChanged?.Invoke(args);
                }
            }
        }
    }

    public class PropertyChangedEventArgs
    {
        public string Name { get; set; }
        public object NewValue { get; set; }
        public object OldValue { get; set; }
        public bool IsGlobal { get; set; }
    }
}
