using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.JSInterop;


namespace SinDarElaMobile.Pages
{
    public partial class AbmeldungComponent
    {
        public async Task RemoveLocalStorage(string key)
        {
            await JSRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}
