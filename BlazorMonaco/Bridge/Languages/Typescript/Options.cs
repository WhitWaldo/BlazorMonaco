using System.Collections.Generic;

namespace BlazorMonaco.Languages.Typescript
{
    public class CompilerOptions
    {
        public bool? AllowJs { get; set; }
        public bool? AllowSyntheticDefaultImports { get; set; }
        public bool? AllowUmdGlobalAccess { get; set; }
        public bool? AllowUnreachableCode { get; set; }
        public bool? AllowUnusedLabels { get; set; }
        public bool? AlwaysStrict { get; set; }
        public string BaseUrl { get; set; }
        public string Charset { get; set; }
        public bool? CheckJs { get; set; }
        public bool? Composite { get; set; }
        public bool? Declaration { get; set; }
        public string DeclarationDir { get; set; }
        public bool? DeclarationMap { get; set; }
        public bool? DisableSizeLimit { get; set; }
        public bool? DisableSourceOfProjectReferenceRedirect { get; set; }
        public bool? DownLevelIteration { get; set; }
        public bool? EmitBOM { get; set; }
        public bool? EmitDeclarationOnly { get; set; }
        public bool? EmitDecoratorMetadata { get; set; }
        public bool? EsModuleInterop { get; set; }
        public bool? ExperimentalDecorators { get; set; }
        public bool? ForceConsistentCasingInFileNames { get; set; }
        public bool? ImportHelpers { get; set; }
        public bool? InlineSourceMap { get; set; }
        public bool? InlineSources { get; set; }
        public bool? IsolatedModules { get; set; }
        public JsxEmit? Jsx { get; set; }
        public string JsxFactory { get; set; }
        public bool? KeyOfStringsOnly { get; set; }
        public List<string> Lib { get; set; }
        public string Locale { get; set; }
        public string MapRoot { get; set; }
        public int MaxNodeModuleJsDepth { get; set; }
        public ModuleKind? Module { get; set; }
        public ModuleResolutionKind? ModuleResolution { get; set; }
        public NewLineKind? NewLine { get; set; }
        public bool? NoEmit { get; set; }
        public bool? NoEmitHelpers { get; set; }
        public bool? NoEmitOnError { get; set; }
        public bool? NoErrorTruncation { get; set; }
        public bool? NoFallthroughCasesInSwitch { get; set; }
        public bool? NoImplicitAny { get; set; }
        public bool? NoImplicitReturns { get; set; }
        public bool? NoImplicitThis { get; set; }
        public bool? NoImplicitUseStrict { get; set; }
        public bool? NoLib { get; set; }
        public bool? NoResolve { get; set; }
        public bool? NoStrictGenericChecks { get; set; }
        public bool? NoUnusedLocals { get; set; }
        public bool? NoUnusedParameters { get; set; }
        public string OutDir { get; set; }
        public string OutFile { get; set; }
        public Dictionary<string, string> Paths { get; set; }
        public bool PreserveConstEnums { get; set; }
        public bool PreserveSymlinks { get; set; }
        public string Project { get; set; }
        public string ReactNamespace { get; set; }
        public bool? RemoveComments { get; set; }
        public bool? ResolveJsonModule { get; set; }
        public string RootDir { get; set; }
        public List<string> RootDirs { get; set; }
        public bool? SkipDefaultLibCheck { get; set; }
        public bool? SkipLibCheck { get; set; }
        public bool? SourceMap { get; set; }
        public string SourceRoot { get; set; }
        public bool? Strict { get; set; }
        public bool? StrictBindCallApply { get; set; }
        public bool? StrictFunctionTypes { get; set; }
        public bool? StrictNullChecks { get; set; }
        public bool? StrictPropertyInitialization { get; set; }
        public bool? StripInternal { get; set; }
        public bool? SuppressExcessPropertyErrors { get; set; }
        public bool? SuppressImplicitAnyIndexErrors { get; set; }
        public ScriptTarget? Target { get; set; }
        public bool? TraceResolution { get; set; }
        public List<string> TypeRoots { get; set; }
        public List<string> Types { get; set; }
        public bool? UseDefineForClassFields { get; set; }
    }

    public class Diagnostic
    {
        public Category Category { get; set; }
        public int Code { get; set; }

        /// <summary>
        /// TypeScriptWorker removes all but the fileName property to avoid serializing circular JSON structures.
        /// </summary>
        public string File { get; set; }
        public int Length { get; set; }
        public DiagnosticMessageChain MessageText { get; set; }
        public List<DiagnosticRelatedInformation> RelatedInformation { get; set; }
        public object ReportsDeprecated { get; set; }

        /// <summary>
        /// May store more in future. For now, this will simply be <see cref="true"/> to indicate when a
        /// diagnostic is an unused-identifier diagnostic.
        /// </summary>
        public object ReportsUnnecessary { get; set; }
        public string Source { get; set; }
        public int Number { get; set; }
    }

    public class DiagnosticMessageChain
    {
        public Category Category { get; set; }
        public int Code {get; set; }
        public string MessageText {get; set; }
        public List<DiagnosticMessageChain> Next { get; set; } = null;
    }

    public class DiagnosticRelatedInformation
    {
        public Category Category { get; set; }
        public int Code { get; set; }
        public string File { get; set; }
        public int Length { get; set; }
        public DiagnosticMessageChain MessageText {get; set; }
        public int Start { get; set; }
    }

    public class DiagnosticsOptions
    {
        public List<int> DiagnosticCodesToIgnore { get; set; }
        public bool? NoSemanticValidation { get; set; }
        public bool? NoSuggestionDiagnostics { get; set; }
        public bool? NoSyntaxValidation { get; set; }
    }

    public class EmitOutput
    {
        public bool EmitSkipped { get;set; }
        public List<OutputFile> OutputFiles {get; set; }
	}

    public class IExtraLib
    {
        public string Content { get; set; }
        public int Version { get; set; }
    }
    
    public class LanguageServiceDefaults
    {
        
	}

    public class MapLike
    {

    }

    public class OutputFile
    {

	}

    public class TypeScriptWorker
    {

    }

    public class WorkerOptions
    {

    }

    public enum Category
    {
        Warning = 0,
        Error = 1,
        Suggestion = 2,
        Message = 3
    }

    public enum JsxEmit
    {
        None = 0,
        Preserve = 1,
        React = 2,
        ReactJSX = 4,
        ReactJSXDev = 5,
        ReactNative = 3
    }

    public enum ModuleResolutionKind
    {
        Classic = 1,
        NodeJs = 2
    }

    public enum ScriptTarget
    {
        ES3 = 0,
        ES5 = 1,
        ES2015 = 2,
        ES2016 = 3,
        ES2017 = 4,
        ES2018 = 5,
        ES2019 = 6,
        ES2020 = 7,
        ESNext = 99,
        JSON = 100,
        Latest = 99
    }

    public enum ModuleKind
    {
        AMD = 2,
        CommonJS = 1,
        ES2015 = 5,
        ESNext = 99,
        None = 0,
        System = 4,
        UMD = 3
    }

    public enum NewLineKind
    {
        CarriageReturnLineFeed = 0,
        LineFeed = 1
    }
}
