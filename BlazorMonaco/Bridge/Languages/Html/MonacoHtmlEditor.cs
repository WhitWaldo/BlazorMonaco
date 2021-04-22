using System.Threading.Tasks;
using BlazorMonaco.Languages.Html;
using Microsoft.JSInterop;

namespace BlazorMonaco
{
    public partial class MonacoEditor
    {
        public async Task SetHandlebarOptions(LanguageServiceDefaults defaults)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.html.handlebarDefaults.setOptions", defaults);
        }

        public async Task SetHtmlOptions(LanguageServiceDefaults defaults)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.html.htmlDefaults.setOptions", defaults);
		}

        public async Task SetRazorOptions(LanguageServiceDefaults defaults)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.html.razorDefaults.setOptions", defaults);
        }
    }
}
