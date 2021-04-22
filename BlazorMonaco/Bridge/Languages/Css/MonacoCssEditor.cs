using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorMonaco
{
    public partial class MonacoEditor
    {
	    public async Task SetCssDiagnosticsOptions(Languages.Css.DiagnosticsOptions options)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.css.setCssDiagnosticsOptions", options);
        }

        public async Task SetCssModeConfiguration(Languages.Css.ModeConfiguration configuration)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.css.setCssModeConfiguration", configuration);
        }

        public async Task SetLessDiagnosticsOptions(Languages.Css.DiagnosticsOptions options)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.css.setLessDiagnosticsOptions", options);
        }

        public async Task SetLessModeConfiguration(Languages.Css.ModeConfiguration configuration)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.css.setLessModeConfiguration", configuration);
        }

        public async Task SetScssDiagnosticsOptions(Languages.Css.DiagnosticsOptions options)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.css.scssDefaults.setScssDiagnosticsOptions",
		        options);
        }

        public async Task SetScssModeConfiguration(Languages.Css.ModeConfiguration configuration)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.css.scssDefaults.setScssModeConfiguration",
		        configuration);
        }
    }
}
