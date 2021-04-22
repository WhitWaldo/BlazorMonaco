if (!require.getConfig().paths.vs)
	require.config({ paths: {'vs': '_content/BlazorMonaco/lib/monaco-editor/min/vs'}});
window.blazorMonaco = window.blazorMonaco || {};

window.blazorMonaco.languages.css = {
	setCssDiagnosticsOptions: function(options) {
		monaco.languages.css.cssDefaults.setDiagnosticsOptions(options);
	},

	setCssModeConfiguration: function(modeConfiguration) {
		monaco.languages.css.cssDefaults.setModeConfiguration(modeConfiguration);
	},

	setLessDiagnosticsOptions: function(options) {
		monaco.languages.css.lessDefaults.setDiagnosticsOptions(options);
	},

	setLessModeConfiguration: function(modeConfiguration) {
		monaco.languages.css.lessDefaults.setModeConfiguration(modeConfiguration);
	},

	setScssDiagnosticsOptions: function(options) {
		monaco.languages.css.scssDefaults.setDiagnosticsOptions(options);
	},

	setScssModeConfiguration: function(modeConfiguration) {
		monaco.languages.css.scssDefaults.setModeConfiguration(modeConfiguration);
	}
}