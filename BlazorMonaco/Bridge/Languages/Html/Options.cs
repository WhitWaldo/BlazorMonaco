using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BlazorMonaco.Languages.Html
{
    public class CompletionConfiguration
    {
		public Dictionary<string,bool> Index {get; set; }
	}

    public class LanguageServiceDefaults
    {
		public string LanguageId {get;set;}
        public ModeConfiguration ModeConfiguration { get; set; }
    }

    public class Options
    {
        /// <summary>
        /// If set, comments are tolerated. If set to false, syntax errors will be emitted for comments.
        /// </summary>
		public HTMLFormatConfiguration Format { get; set; }

        /// <summary>
        /// A list of known schemas and/or associations of schemas to file names.
        /// </summary>
        public CompletionConfiguration Suggest { get; set; }
    }

    public class HTMLFormatConfiguration
    {
		public string ContentUnformatted { get;set; }
        public bool EnWithNewline { get;set; }
        public string ExtraLiners { get; set; }
        public bool IndentHandlebars { get; set; }
        public bool IndentInnerHtml { get; set; }
        public bool InsertSpaces { get;set; }
        public int MaxPreserveNewLines { get; set; }
        public bool PreserveNewLines {get;set;}
        public int TabSize { get; set; }
        public string Unformatted { get; set; }
        public WrapAttributes WrapAttributes { get; set; }
        public int WrapLineLength { get; set; }
	}

    public enum WrapAttributes
    {
        [EnumMember(Value="auto")]
	    Auto,
        [EnumMember(Value="force")]
	    Force,
        [EnumMember(Value="force-aligned")]
	    ForceAligned,
        [EnumMember(Value="force-expand-multiline")]
	    ForceExpandMultiline
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
        /// Defines whether the built-in diagnostic provider is enabled.
        /// </summary>
        public bool? Diagnostics { get; set; }

        /// <summary>
        /// Defines whether the built-in documentFormattingEdit provider is enabled.
        /// </summary>
        public bool? DocumentFormattingEdits { get; set; }

        /// <summary>
        /// Defines whether the built-in references provider is enabled.
        /// </summary>
        public bool? DocumentHighlights { get; set; }

        /// <summary>
        /// Defines whether the built-in documentRangeFormattingEdit provider is enabled.
        /// </summary>
        public bool? DocumentRangeFormattingEdits { get;set; }

        /// <summary>
        /// Defines whether the built-in documentSymbolProvider is enabled.
        /// </summary>
        public bool? DocumentSymbols { get;set; }

        /// <summary>
        /// Defines whether the built-in foldingRanges provider is enabled.
        /// </summary>
        public bool? FoldingRanges { get; set; }

        /// <summary>
        /// Defines whether the built-in hoverProvider is enabled.
        /// </summary>
        public bool? Hovers { get; set; }

        /// <summary>
        /// Defines whether the built-in definitions provider is enabled.
        /// </summary>
        public bool? Links { get; set; }

        /// <summary>
        /// Defines whether the built-in rename provider is enabled.
        /// </summary>
        public bool? Rename { get;set; }

        /// <summary>
        /// Defines whether the built-in selection range provider is enabled.
        /// </summary>
        public bool? SelectionRanges { get; set; }
    }
}
