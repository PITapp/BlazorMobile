using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.JSInterop;


namespace SinDarElaMobile.Pages
{
    public partial class AnmeldungComponent
    {
        public async Task WriteLocalStorage(string key, string value)
        {
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", new object[] { key, value });
        }

        public async Task<string> ReadLocalStorage(string key)
        {
            return await JSRuntime.InvokeAsync<string>("localStorage.getItem", key);
        }

        public async Task RemoveLocalStorage(string key)
        {
            await JSRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }

        public async Task ClearLocalStorage()
        {
            await JSRuntime.InvokeVoidAsync("localStorage.clear");
        }

        public string GetDeterministicHashCode(string str)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < str.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ str[i];
                    if (i == str.Length - 1)
                        break;
                    hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
                }

                return (hash1 + (hash2 * 1566083941937216591)).ToString();
            }
        }

    }
}
