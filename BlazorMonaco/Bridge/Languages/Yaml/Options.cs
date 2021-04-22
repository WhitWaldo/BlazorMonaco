using System.Collections.Generic;

namespace BlazorMonaco.Languages.Yaml
{
	public class DiagnosticsOptions
	{
		/// <summary>
		/// If set, the validator will be enabled and perform syntax validation as well as schema-based validation.
		/// </summary>
		public bool? Validate { get; set; }

		/// <summary>
		/// A list of known schemas and/or associations of schemas to file names.
		/// </summary>
		public List<YamlSchema> Schemas { get; set; }

		/// <summary>
		/// If set, the schema service would load schema content on-demand with 'fetch' if available.
		/// </summary>
		public bool? EnableSchemaRequest { get; set; }

		/// <summary>
		/// If specified, this prefix will be added to all on-demand schema requests.
		/// </summary>
		public string Prefix { get; set; }

		/// <summary>
		/// Whether or not Kubernetes YAML is supported.
		/// </summary>
		public bool? IsKubernetes { get;set; }
		public bool? Format { get; set; }
	}

	public class YamlSchema
	{
		/// <summary>
		/// The URI of the schemas, which is also the identifier of the schema.
		/// </summary>
		public string Uri { get;set; }

		/// <summary>
		/// A list of file names that are associated to the schema. The "*" wildcard can be used.
		/// </summary>
		/// <example>
		/// "*.schema.json"
		/// </example>
		/// /// <example>
		/// "package.json"
		/// </example>
		public List<string> FileMatch { get; set; }

		/// <summary>
		/// The schema for the given URI as a serialized JSON string
		/// </summary>
		public string Schema { get;set; }
	}
}
