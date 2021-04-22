namespace BlazorMonaco.Languages.Css
{
    public class DiagnosticsOptions
    {
		public Lint Lint { get; set; }
        public bool? Validate { get; set; }
	}

    public class Lint 
    {
		public LintLevel? ArgumentsInColorFunction { get; set; }
        public LintLevel? BoxModel { get;set; }
        public LintLevel? CompatibleVendorPrefixes { get;set; }
        public LintLevel? DuplicateProperties { get; set; }
        public LintLevel? EmptyRules { get; set; } 
        public LintLevel? Float { get; set; }
        public LintLevel? FontFaceProperties { get; set; }
        public LintLevel? HexColorLength { get; set; }
        public LintLevel? IdSelector { get; set; }
        public LintLevel? IeHack { get; set; }
        public LintLevel? ImportStatement { get; set; }
        public LintLevel? Important { get; set; }
        public LintLevel? PropertyIgnoredDueToDisplay { get; set; }
        public LintLevel? UniversalSelector { get; set; }
        public LintLevel? UnknownProperties { get; set; }
        public LintLevel? UnknownVendorSpecificProperties { get; set; }
        public LintLevel? VendorPrefix { get; set; }
        public LintLevel? ZeroUnits { get; set; }
	}

    public enum LintLevel
    {
        Ignore,
        Warning,
        Error
    }

    public class LanguageServiceDefaults
    {
		public DiagnosticsOptions DiagnosticsOptions { get; set; }
        public string LanguageId { get; set; }
        public ModeConfiguration ModeConfiguration { get; set; }
    }

    public class ModeConfiguration
    {
        /// <summary>
        /// Defines whether the built-in color provider is enabled.
        /// </summary>
		public bool? Colors { get; set; }

        /// <summary>
        /// Defines whether the built-in completionItemProvider is enabled.
        /// </summary>
        public bool? CompletionItems { get; set; }

        /// <summary>
        /// Defines whether the built-in definitions provider is enabled.
        /// </summary>
        public bool? Definitions { get;set; }
        
        /// <summary>
        /// Defines whether the built-in diagnostic provider is enabled.
        /// </summary>
        public bool? Diagnostics { get;set; }

        /// <summary>
        /// Defines whether built-in references provider is enabled.
        /// </summary>
        public bool? DocumentHighlights {get;set;}

        /// <summary>
        /// Defines whether the built-in documentSymbolProvider is enabled.
        /// </summary>
        public bool? DocumentSymbols { get; set; }

        /// <summary>
        /// Defines whether the built-in foldingRange provider is enabled.
        /// </summary>
        public bool? FoldingRanges { get; set; }

        /// <summary>
        /// Defines whether the built-in hoverProvider is enabled.
        /// </summary>
        public bool? Hovers { get; set; }

        /// <summary>
        /// Defines whether the built-in references provider is enabled.
        /// </summary>
        public bool? References {get;set;}

        /// <summary>
        /// Defines whether the built-in rename provider is enabled.
        /// </summary>
        public bool? Rename {get; set; }

        /// <summary>
        /// Defines whether the built-in selection range provider 
        /// </summary>
        public bool? SelectionRanges { get; set; }
    }
}
