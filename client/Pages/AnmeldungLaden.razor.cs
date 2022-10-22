using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.JSInterop;

namespace SinDarElaMobile.Pages
{
    public partial class AnmeldungLadenComponent
    {
        public async Task<string> ReadLocalStorage(string key)
        {
            return await JSRuntime.InvokeAsync<string>("localStorage.getItem", key);
        }
    }
}
