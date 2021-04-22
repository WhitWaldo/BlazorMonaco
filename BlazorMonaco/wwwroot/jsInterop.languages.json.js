if (!require.getConfig().paths.vs)
	require.config({ paths: {'vs': '_content/BlazorMonaco/lib/monaco-editor/min/vs'}});
window.blazorMonaco = window.blazorMonaco || {};

window.blazorMonaco.languages.json = {
	setDiagnosticsOptions: function(options) {
		monaco.languages.json.jsonDefaults.setDiagnosticsOptions(options);
	},

	setModeConfiguration: function(modeConfiguration) {
		monaco.languages.json.jsonDefaults.setModeConfiguration(modeConfiguration);
	}
}