using System.Collections.Generic;

namespace BlazorMonaco.Languages.Json
{
	public class JsonModel
	{
		public LanguageServiceDefaults JsonDefaults => new LanguageServiceDefaults();
	}

	public class DiagnosticsOptions
	{
		/// <summary>
		/// If set, comments are tolerated. If set to false, syntax errors will be emitted for comments.
		/// </summary>
		public bool? AllowComments { get; }

		/// <summary>
		/// If set, the schema service would load schema content on-demand with 'fetch' if available.
		/// </summary>
		public bool? EnableSchemaRequest { get; }

		/// <summary>
		/// The severity of problems that occurred when resolving and loading schemas. If set to <see cref="SeverityLevel.Ignore"/>, schema
		/// validation will be skipped. If not set, '<see cref="SeverityLevel.Warning"/>' is used.
		/// </summary>
		public SeverityLevel? SchemaRequest { get; }

		/// <summary>
		/// The severity of problems from schema validation. If set to <see cref="SeverityLevel.Ignore"/>, schema
		/// validation will be skipped. If not set, '<see cref="SeverityLevel.Warning"/>' is used.
		/// </summary>
		public SeverityLevel? SchemaValidation { get; }

		/// <summary>
		/// A list of known schemas and/or associations of schemas to file names.
		/// </summary>
		public List<string> Schemas { get; }

		/// <summary>
		/// If set, the validator will be enabled and perform syntax validation as well as schema-based
		/// validation.
		/// </summary>
		public bool? Validate { get; }
	}

	public class LanguageServiceDefaults
	{
		public DiagnosticsOptions DiagnosticsOptions { get; private set;}

		public string LanguageId { get; }

		public ModeConfiguration ModeConfiguration { get; private set; }

		public void SetDiagnosticsOptions(DiagnosticsOptions options)
		{
			DiagnosticsOptions = options;
		}

		public void SetModeConfiguration(ModeConfiguration config)
		{
			ModeConfiguration = config;
		}
	}

	public class ModeConfiguration
	{
		/// <summary>
		/// Defines whether the built-in color provider is enabled.
		/// </summary>
		public bool? Colors { get; }

		/// <summary>
		/// Defines whether the built-in completionItemProvider is enabled.
		/// </summary>
		public bool? CompletionItems { get; }

		/// <summary>
		/// Defines whether the built-in diagnostic provider is enabled.
		/// </summary>
		public bool? Diagnostics { get; }

		/// <summary>
		/// Defines whether the built-in documentFormattingEdit provider is enabled.
		/// </summary>
		public bool? DocumentFormattingEdits { get; }

		/// <summary>
		/// Defines whether the built-in documentRangeFormattingEdit provider is enabled.
		/// </summary>
		public bool? DocumentRangeFormattingEdits { get; }

		/// <summary>
		/// Defines whether the built-in documentSymbolProvider is enabled.
		/// </summary>
		public bool? DocumentSymbols { get; }

		/// <summary>
		/// Defines whether the built-in foldingRange provider is enabled.
		/// </summary>
		public bool? FoldingRanges { get; }

		/// <summary>
		/// Defines whether the built-in hoverProvider is enabled.
		/// </summary>
		public bool? Hovers { get; }

		/// <summary>
		/// Defines whether the built-in selection range provider is enabled.
		/// </summary>
		public bool? SelectionRanges { get; }

		/// <summary>
		/// Defines whether the built-in tokens provider is enabled.
		/// </summary>
		public bool? Tokens { get; }
	}

	public enum SeverityLevel
	{
		Error,
		Warning,
		Ignore
	}
}