if (!require.getConfig().paths.vs)
	require.config({ paths: {'vs': '_content/BlazorMonaco/lib/monaco-editor/min/vs'}});
window.blazorMonaco = window.blazorMonaco || {};

window.blazorMonaco.languages.html = {
	setHandlebarOptions: function(options) {
		monaco.languages.html.handlebarDefaults.setOptions(options);
	},
	setHtmlOptions: function(options) {
		monaco.languages.html.htmlDefaults.setOptions(options);
	},
	setRazorOptions: function(options) {
		monaco.languages.html.razorDefaults.setOptions(options);
	}
}