if (!require.getConfig().paths.vs)
	require.config({ paths: {'vs': '_content/BlazorMonaco/lib/monaco-editor/min/vs'}});
window.blazorMonaco = window.blazorMonaco || {};

window.blazorMonaco.languages.typescript = {
	//JavaScript
	jsAddExtraLib: function(content, filePath) {
		monaco.languages.typescript.javascriptDefaults.addExtraLib(content, filePath);
	},
	jsGetCompilerOptions: function() {
		return monaco.languages.typescript.javascriptDefaults.getCompilerOptions();
	},
	jsGetDiagnosticsOptions: function() {
		return monaco.languages.typescript.javascriptDefaults.getDiagnosticsOptions();
	},
	jsGetEagerModelSync: function() {
		return monaco.languages.typescript.javascriptDefaults.getEagerModelSync();
	},
	jsGetExtraLibs: function() {
		return monaco.languages.typescript.javascriptDefaults.getExtraLibs();
	},
	jsSetCompilerOptions: function(options) {
		monaco.languages.typescript.javascriptDefaults.setCompilerOptions(options);
	},
	jsSetDiagnosticsOptions: function(options) {
		monaco.languages.typescript.javascriptDefaults.setDiagnosticsOptions(options);
	},
	jsSetEagerModelSync: function(value) {
		monaco.languages.typescript.javascriptDefaults.setEagerModelSync(value);
	},
	jsSetExtraLibs: function(libs) {
		monaco.languages.typescript.javascriptDefaults.setExtraLibs(libs);
	},
	jsSetMaximumWorkerIdleTime: function (value) {
		monaco.languages.typescript.javascriptDefaults.setMaximumWorkerIdleTime(value);
	},
	jsSetWorkerOptions: function(options) {
		monaco.languages.typescript.javascriptDefaults.setWorkerOptions(options);
	},
	//TypeScript
	tsAddExtraLib: function(content, filePath) {
		monaco.languages.typescript.typescriptDefaults.addExtraLib(content, filePath);
	},
	tsGetCompilerOptions: function() {
		return monaco.languages.typescript.typescriptDefaults.getCompilerOptions();
	},
	tsGetDiagnosticsOptions: function() {
		return monaco.languages.typescript.typescriptDefaults.getDiagnosticsOptions();
	},
	tsGetEagerModelSync: function() {
		return monaco.languages.typescript.typescriptDefaults.getEagerModelSync();
	},
	tsGetExtraLibs: function() {
		return monaco.languages.typescript.typescriptDefaults.getExtraLibs();
	},
	tsSetCompilerOptions: function(options) {
		monaco.languages.typescript.typescriptDefaults.setCompilerOptions(options);
	},
	tsSetDiagnosticsOptions: function(options) {
		monaco.languages.typescript.typescriptDefaults.setDiagnosticsOptions(options);
	},
	tsSetEagerModelSync: function(value) {
		monaco.languages.typescript.typescriptDefaults.setEagerModelSync(value);
	},
	tsSetExtraLibs: function(libs) {
		monaco.languages.typescript.typescriptDefaults.setExtraLibs(libs);
	},
	tsSetMaximumWorkerIdleTime: function (value) {
		monaco.languages.typescript.typescriptDefaults.setMaximumWorkerIdleTime(value);
	},
	tsSetWorkerOptions: function(options) {
		monaco.languages.typescript.typescriptDefaults.setWorkerOptions(options);
	},
	typescriptVersion: function() {
		return monaco.languages.typescript.typescriptVersion;
	},
//	getJavaScriptWorker() {
//		return monaco.languages.typescript.getJavaScriptWorker();
//	},
//	getTypeScriptWorker() {
//		return monaco.languages.typescript.getTypeScriptWorker();
//	}
}