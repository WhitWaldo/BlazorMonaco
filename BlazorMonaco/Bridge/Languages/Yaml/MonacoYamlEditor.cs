using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorMonaco
{
    public partial class MonacoEditor
    {
        public async Task SetYamlDiagnosticsOptions(Languages.Yaml.DiagnosticsOptions options)
        {
            if (jsRuntime == null)
                return;

            await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.yaml.setDiagnosticsOptions", options);
        }
    }
}
