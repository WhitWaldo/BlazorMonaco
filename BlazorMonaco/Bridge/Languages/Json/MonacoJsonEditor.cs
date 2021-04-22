using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorMonaco
{
    public partial class MonacoEditor
    {
        public async Task SetDiagnosticsOptions(Languages.Json.DiagnosticsOptions options)
        {
            if (jsRuntime == null)
                return;

            await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.json.jsonDefaults.setDiagnosticsOptions", options);
        }

        public async Task SetModeConfiguration(Languages.Json.ModeConfiguration configuration)
        {
            if (jsRuntime == null)
                return;

            await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.json.jsonDefaults.setModeConfiguration",
                configuration);
        }
    }
}
