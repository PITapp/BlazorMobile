using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.JSInterop;

namespace SinDarElaMobile.Pages
{
    public partial class EinstellungenInfotexteEditorComponent
    {
        private async Task CopyTextToClipboard(string text)
        {
            await JSRuntime.InvokeVoidAsync("copyTextToClipboard", text);
        }
    }
}
