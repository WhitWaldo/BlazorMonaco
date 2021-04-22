if (!require.getConfig().paths.vs)
	require.config({ paths: {'vs': '_content/BlazorMonaco/lib/monaco-editor/min/vs'}});
window.blazorMonaco = window.blazorMonaco || {};

window.blazorMonaco.languages.yaml = {
	setDiagnosticsOptions: function(options) {
		return monaco.languages.yaml.yamlDefaults.setDiagnosticsOptions(options);
	}
}