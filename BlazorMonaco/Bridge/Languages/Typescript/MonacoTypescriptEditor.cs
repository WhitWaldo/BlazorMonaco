using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorMonaco
{
    public partial class MonacoEditor
    {
        #region JavaScript

        public async Task JavaScriptAddExtraLib(string content, string filePath)
        {
            if (jsRuntime == null)
                return;

            await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.typescript.jsAddExtraLib", content, filePath);
        }

        public async Task<Languages.Typescript.CompilerOptions> GetJavaScriptCompilerOptions()
        {        
	        if (jsRuntime == null)
		        return default;

	        return await jsRuntime.InvokeAsync<Languages.Typescript.CompilerOptions>(
		        "blazorMonaco.languages.typescript.jsGetCompilerOptions");
        }

        public async Task<Languages.Typescript.DiagnosticsOptions> GetJavaScriptDiagnosticsOptions()
        {
	        if (jsRuntime == null)
		        return default;

	        return await jsRuntime.InvokeAsync<Languages.Typescript.DiagnosticsOptions>(
		        "blazorMonaco.languages.typescript.jsGetDiagnosticOptions");
        }

        public async Task<bool> GetJavaScriptEagerModelSync()
        {
	        if (jsRuntime == null)
		        return default;

	        return await jsRuntime.InvokeAsync<bool>("blazorMonaco.languages.typescript.jsGetEagerModelSync");
        }

        public async Task<List<Languages.Typescript.IExtraLib>> GetJavaScriptExtraLibs()
        {
	        if (jsRuntime == null)
		        return default;

	        return await jsRuntime.InvokeAsync<List<Languages.Typescript.IExtraLib>>(
		        "blazorMonaco.languages.typescript.jsGetExtraLibs");
        }

        public async Task SetJavaScriptCompilerOptions(Languages.Typescript.CompilerOptions options)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.typescript.jsSetCompilerOptions", options);
        }

        public async Task SetJavaScriptDiagnosticsOptions(Languages.Typescript.DiagnosticsOptions options)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.typescript.jsSetDiagnosticOptions", options);
        }

        public async Task SetJavaScriptEagerModelSync(bool value)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.typescript.jsSetEagerModelSync", value);
        }

        public async Task SetJavaScriptExtraLibs(List<(string content, string filePath)> libs)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.typescript.jsSetExtraLibs", libs);
        }

        public async Task SetJavaScriptMaximumWorkerIdleTime(int value)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.typescript.jsSetMaximumWorkerIdleTime", value);
        }

        public async Task SetJavaScriptWorkerOptions(Languages.Typescript.WorkerOptions options)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.typescript.jsSetWorkerOptions", options);
        }

        #endregion

        #region TypeScript

        public async Task AddTypeScriptExtraLib(string content, string filePath)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.typescript.tsAddExtraLib", content, filePath);
        }

        public async Task<Languages.Typescript.CompilerOptions> GetTypeScriptCompilerOptions()
        {        
	        if (jsRuntime == null)
		        return default;

	        return await jsRuntime.InvokeAsync<Languages.Typescript.CompilerOptions>(
		        "blazorMonaco.languages.typescript.tsGetCompilerOptions");
        }

        public async Task<Languages.Typescript.DiagnosticsOptions> GetTypeScriptDiagnosticsOptions()
        {
	        if (jsRuntime == null)
		        return default;

	        return await jsRuntime.InvokeAsync<Languages.Typescript.DiagnosticsOptions>(
		        "blazorMonaco.languages.typescript.tsGetDiagnosticsOptions");
        }

        public async Task<bool> GetTypeScriptEagerModelSync()
        {
	        if (jsRuntime == null)
		        return default;

	        return await jsRuntime.InvokeAsync<bool>("blazorMonaco.languages.typescript.tsGetEagerModelSync");
        }

        public async Task<List<Languages.Typescript.IExtraLib>> GetTypeScriptExtraLibs()
        {
	        if (jsRuntime == null)
		        return default;

	        return await jsRuntime.InvokeAsync<List<Languages.Typescript.IExtraLib>>(
		        "blazorMonaco.languages.typescript.tsGetExtraLibs");
        }

        public async Task SetTypeScriptCompilerOptions(Languages.Typescript.CompilerOptions options)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.typescript.tsSetCompilerOptions", options);
        }

        public async Task SetTypeScriptDiagnosticsOptions(Languages.Typescript.DiagnosticsOptions options)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.typescript.tsSetDiagnosticOptions", options);
        }

        public async Task SetTypeScriptEagerModelSync(bool value)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.typescript.tsSetEagerModelSync", value);
        }

        public async Task SetTypeScriptExtraLibs(List<(string content, string filePath)> libs)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.typescript.tsSetExtraLibs", libs);
        }

        public async Task SetTypeScriptMaximumWorkerIdleTime(int value)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.typescript.tsSetMaximumWorkerIdleTime", value);
        }

        public async Task SetTypeScriptWorkerOptions(Languages.Typescript.WorkerOptions options)
        {
	        if (jsRuntime == null)
		        return;

	        await jsRuntime.InvokeVoidAsync("blazorMonaco.languages.typescript.tsSetWorkerOptions", options);
        }

        #endregion
    }
}
