using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

[JsonSerializable(typeof(DesktopRequestMessage))]
[JsonSerializable(typeof(FileExploreRequestMessage))]
[JsonSerializable(typeof(FileExploreResponseMessage))]
[JsonSerializable(typeof(OpenFolderRequestMessage))]
[JsonSerializable(typeof(StartFinishRequestMessage))]
[GeneratedCode("System.Text.Json.SourceGeneration", "10.0.14.37416")]
public class DesktopMessageJsonContext : JsonSerializerContext, IJsonTypeInfoResolver
{
	private JsonTypeInfo<DesktopRequestMessage>? _DesktopRequestMessage;

	private JsonTypeInfo<FileExploreRequestMessage>? _FileExploreRequestMessage;

	private JsonTypeInfo<FileExploreResponseMessage>? _FileExploreResponseMessage;

	private JsonTypeInfo<OpenFolderRequestMessage>? _OpenFolderRequestMessage;

	private static readonly JsonSerializerOptions s_defaultOptions = new JsonSerializerOptions();

	[CompilerGenerated]
	private static readonly DesktopMessageJsonContext _003CDefault_003Ek__BackingField = new DesktopMessageJsonContext(new JsonSerializerOptions(s_defaultOptions));

	private static readonly JsonEncodedText PropName_type = JsonEncodedText.Encode("type");

	private static readonly JsonEncodedText PropName_id = JsonEncodedText.Encode("id");

	private static readonly JsonEncodedText PropName_directoryOnly = JsonEncodedText.Encode("directoryOnly");

	private static readonly JsonEncodedText PropName_basePath = JsonEncodedText.Encode("basePath");

	private static readonly JsonEncodedText PropName_title = JsonEncodedText.Encode("title");

	private static readonly JsonEncodedText PropName_multiselect = JsonEncodedText.Encode("multiselect");

	private static readonly JsonEncodedText PropName_values = JsonEncodedText.Encode("values");

	private static readonly JsonEncodedText PropName_path = JsonEncodedText.Encode("path");

	private static readonly JsonEncodedText PropName_isDirectory = JsonEncodedText.Encode("isDirectory");

	private static readonly JsonEncodedText PropName_hasError = JsonEncodedText.Encode("hasError");

	public JsonTypeInfo<DesktopRequestMessage> DesktopRequestMessage => _DesktopRequestMessage ?? (_DesktopRequestMessage = (JsonTypeInfo<DesktopRequestMessage>)base.Options.GetTypeInfo(typeof(DesktopRequestMessage)));

	public JsonTypeInfo<FileExploreRequestMessage> FileExploreRequestMessage => _FileExploreRequestMessage ?? (_FileExploreRequestMessage = (JsonTypeInfo<FileExploreRequestMessage>)base.Options.GetTypeInfo(typeof(FileExploreRequestMessage)));

	public JsonTypeInfo<FileExploreResponseMessage> FileExploreResponseMessage => _FileExploreResponseMessage ?? (_FileExploreResponseMessage = (JsonTypeInfo<FileExploreResponseMessage>)base.Options.GetTypeInfo(typeof(FileExploreResponseMessage)));

	public JsonTypeInfo<OpenFolderRequestMessage> OpenFolderRequestMessage => _OpenFolderRequestMessage ?? (_OpenFolderRequestMessage = (JsonTypeInfo<OpenFolderRequestMessage>)base.Options.GetTypeInfo(typeof(OpenFolderRequestMessage)));

	protected override JsonSerializerOptions? GeneratedSerializerOptions { get; } = s_defaultOptions;

	private JsonTypeInfo<bool> Create_Boolean(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<bool> jsonTypeInfo))
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<bool>(options, JsonMetadataServices.BooleanConverter);
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<DesktopRequestMessage> Create_DesktopRequestMessage(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<DesktopRequestMessage> jsonTypeInfo))
		{
			JsonObjectInfoValues<DesktopRequestMessage> objectInfo = new JsonObjectInfoValues<DesktopRequestMessage>
			{
				ObjectCreator = null,
				ObjectWithParameterizedConstructorCreator = (object[] args) => new DesktopRequestMessage((string)args[0]),
				PropertyMetadataInitializer = (JsonSerializerContext _) => DesktopRequestMessagePropInit(options),
				ConstructorParameterMetadataInitializer = DesktopRequestMessageCtorParamInit,
				ConstructorAttributeProviderFactory = () => typeof(DesktopRequestMessage).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[1] { typeof(string) }, null),
				SerializeHandler = DesktopRequestMessageSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] DesktopRequestMessagePropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[1];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(DesktopRequestMessage),
			Converter = null,
			Getter = (object obj) => ((DesktopRequestMessage)obj).type,
			Setter = delegate
			{
				throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "type",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(DesktopRequestMessage).GetProperty("type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		return array;
	}

	private void DesktopRequestMessageSerializeHandler(Utf8JsonWriter writer, DesktopRequestMessage? value)
	{
		if ((object)value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_type, value.type);
		writer.WriteEndObject();
	}

	private static JsonParameterInfoValues[] DesktopRequestMessageCtorParamInit()
	{
		return new JsonParameterInfoValues[1]
		{
			new JsonParameterInfoValues
			{
				Name = "type",
				ParameterType = typeof(string),
				Position = 0,
				HasDefaultValue = false,
				DefaultValue = null,
				IsNullable = false
			}
		};
	}

	private JsonTypeInfo<FileExploreRequestMessage> Create_FileExploreRequestMessage(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<FileExploreRequestMessage> jsonTypeInfo))
		{
			JsonObjectInfoValues<FileExploreRequestMessage> objectInfo = new JsonObjectInfoValues<FileExploreRequestMessage>
			{
				ObjectCreator = null,
				ObjectWithParameterizedConstructorCreator = (object[] args) => new FileExploreRequestMessage((string)args[0], (int)args[1], (bool)args[2], (string)args[3], (string)args[4], (bool)args[5]),
				PropertyMetadataInitializer = (JsonSerializerContext _) => FileExploreRequestMessagePropInit(options),
				ConstructorParameterMetadataInitializer = FileExploreRequestMessageCtorParamInit,
				ConstructorAttributeProviderFactory = () => typeof(FileExploreRequestMessage).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[6]
				{
					typeof(string),
					typeof(int),
					typeof(bool),
					typeof(string),
					typeof(string),
					typeof(bool)
				}, null),
				SerializeHandler = FileExploreRequestMessageSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] FileExploreRequestMessagePropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[6];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(FileExploreRequestMessage),
			Converter = null,
			Getter = (object obj) => ((FileExploreRequestMessage)obj).type,
			Setter = delegate
			{
				throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "type",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(FileExploreRequestMessage).GetProperty("type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<int> propertyInfo2 = new JsonPropertyInfoValues<int>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(FileExploreRequestMessage),
			Converter = null,
			Getter = (object obj) => ((FileExploreRequestMessage)obj).id,
			Setter = delegate
			{
				throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "id",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(FileExploreRequestMessage).GetProperty("id", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<bool> propertyInfo3 = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(FileExploreRequestMessage),
			Converter = null,
			Getter = (object obj) => ((FileExploreRequestMessage)obj).directoryOnly,
			Setter = delegate
			{
				throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "directoryOnly",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(FileExploreRequestMessage).GetProperty("directoryOnly", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(FileExploreRequestMessage),
			Converter = null,
			Getter = (object obj) => ((FileExploreRequestMessage)obj).basePath,
			Setter = delegate
			{
				throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "basePath",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(FileExploreRequestMessage).GetProperty("basePath", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		array[3].IsGetNullable = false;
		array[3].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(FileExploreRequestMessage),
			Converter = null,
			Getter = (object obj) => ((FileExploreRequestMessage)obj).title,
			Setter = delegate
			{
				throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "title",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(FileExploreRequestMessage).GetProperty("title", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		array[4].IsGetNullable = false;
		array[4].IsSetNullable = false;
		JsonPropertyInfoValues<bool> propertyInfo6 = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(FileExploreRequestMessage),
			Converter = null,
			Getter = (object obj) => ((FileExploreRequestMessage)obj).multiselect,
			Setter = delegate
			{
				throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "multiselect",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(FileExploreRequestMessage).GetProperty("multiselect", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		return array;
	}

	private void FileExploreRequestMessageSerializeHandler(Utf8JsonWriter writer, FileExploreRequestMessage? value)
	{
		if ((object)value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_type, value.type);
		writer.WriteNumber(PropName_id, value.id);
		writer.WriteBoolean(PropName_directoryOnly, value.directoryOnly);
		writer.WriteString(PropName_basePath, value.basePath);
		writer.WriteString(PropName_title, value.title);
		writer.WriteBoolean(PropName_multiselect, value.multiselect);
		writer.WriteEndObject();
	}

	private static JsonParameterInfoValues[] FileExploreRequestMessageCtorParamInit()
	{
		return new JsonParameterInfoValues[6]
		{
			new JsonParameterInfoValues
			{
				Name = "type",
				ParameterType = typeof(string),
				Position = 0,
				HasDefaultValue = false,
				DefaultValue = null,
				IsNullable = false
			},
			new JsonParameterInfoValues
			{
				Name = "id",
				ParameterType = typeof(int),
				Position = 1,
				HasDefaultValue = false,
				DefaultValue = null,
				IsNullable = false
			},
			new JsonParameterInfoValues
			{
				Name = "directoryOnly",
				ParameterType = typeof(bool),
				Position = 2,
				HasDefaultValue = false,
				DefaultValue = null,
				IsNullable = false
			},
			new JsonParameterInfoValues
			{
				Name = "basePath",
				ParameterType = typeof(string),
				Position = 3,
				HasDefaultValue = false,
				DefaultValue = null,
				IsNullable = false
			},
			new JsonParameterInfoValues
			{
				Name = "title",
				ParameterType = typeof(string),
				Position = 4,
				HasDefaultValue = false,
				DefaultValue = null,
				IsNullable = false
			},
			new JsonParameterInfoValues
			{
				Name = "multiselect",
				ParameterType = typeof(bool),
				Position = 5,
				HasDefaultValue = false,
				DefaultValue = null,
				IsNullable = false
			}
		};
	}

	private JsonTypeInfo<FileExploreResponseMessage> Create_FileExploreResponseMessage(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<FileExploreResponseMessage> jsonTypeInfo))
		{
			JsonObjectInfoValues<FileExploreResponseMessage> objectInfo = new JsonObjectInfoValues<FileExploreResponseMessage>
			{
				ObjectCreator = null,
				ObjectWithParameterizedConstructorCreator = (object[] args) => new FileExploreResponseMessage((string)args[0], (int)args[1], (bool)args[2], (string[])args[3]),
				PropertyMetadataInitializer = (JsonSerializerContext _) => FileExploreResponseMessagePropInit(options),
				ConstructorParameterMetadataInitializer = FileExploreResponseMessageCtorParamInit,
				ConstructorAttributeProviderFactory = () => typeof(FileExploreResponseMessage).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[4]
				{
					typeof(string),
					typeof(int),
					typeof(bool),
					typeof(string[])
				}, null),
				SerializeHandler = FileExploreResponseMessageSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] FileExploreResponseMessagePropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[4];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(FileExploreResponseMessage),
			Converter = null,
			Getter = (object obj) => ((FileExploreResponseMessage)obj).type,
			Setter = delegate
			{
				throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "type",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(FileExploreResponseMessage).GetProperty("type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<int> propertyInfo2 = new JsonPropertyInfoValues<int>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(FileExploreResponseMessage),
			Converter = null,
			Getter = (object obj) => ((FileExploreResponseMessage)obj).id,
			Setter = delegate
			{
				throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "id",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(FileExploreResponseMessage).GetProperty("id", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<bool> propertyInfo3 = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(FileExploreResponseMessage),
			Converter = null,
			Getter = (object obj) => ((FileExploreResponseMessage)obj).directoryOnly,
			Setter = delegate
			{
				throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "directoryOnly",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(FileExploreResponseMessage).GetProperty("directoryOnly", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<string[]> propertyInfo4 = new JsonPropertyInfoValues<string[]>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(FileExploreResponseMessage),
			Converter = null,
			Getter = (object obj) => ((FileExploreResponseMessage)obj).values,
			Setter = delegate
			{
				throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "values",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(FileExploreResponseMessage).GetProperty("values", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string[]), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		array[3].IsGetNullable = false;
		array[3].IsSetNullable = false;
		return array;
	}

	private void FileExploreResponseMessageSerializeHandler(Utf8JsonWriter writer, FileExploreResponseMessage? value)
	{
		if ((object)value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_type, value.type);
		writer.WriteNumber(PropName_id, value.id);
		writer.WriteBoolean(PropName_directoryOnly, value.directoryOnly);
		writer.WritePropertyName(PropName_values);
		StringArraySerializeHandler(writer, value.values);
		writer.WriteEndObject();
	}

	private static JsonParameterInfoValues[] FileExploreResponseMessageCtorParamInit()
	{
		return new JsonParameterInfoValues[4]
		{
			new JsonParameterInfoValues
			{
				Name = "type",
				ParameterType = typeof(string),
				Position = 0,
				HasDefaultValue = false,
				DefaultValue = null,
				IsNullable = false
			},
			new JsonParameterInfoValues
			{
				Name = "id",
				ParameterType = typeof(int),
				Position = 1,
				HasDefaultValue = false,
				DefaultValue = null,
				IsNullable = false
			},
			new JsonParameterInfoValues
			{
				Name = "directoryOnly",
				ParameterType = typeof(bool),
				Position = 2,
				HasDefaultValue = false,
				DefaultValue = null,
				IsNullable = false
			},
			new JsonParameterInfoValues
			{
				Name = "values",
				ParameterType = typeof(string[]),
				Position = 3,
				HasDefaultValue = false,
				DefaultValue = null,
				IsNullable = false
			}
		};
	}

	private JsonTypeInfo<OpenFolderRequestMessage> Create_OpenFolderRequestMessage(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<OpenFolderRequestMessage> jsonTypeInfo))
		{
			JsonObjectInfoValues<OpenFolderRequestMessage> objectInfo = new JsonObjectInfoValues<OpenFolderRequestMessage>
			{
				ObjectCreator = null,
				ObjectWithParameterizedConstructorCreator = (object[] args) => new OpenFolderRequestMessage((string)args[0], (string)args[1], (bool)args[2]),
				PropertyMetadataInitializer = (JsonSerializerContext _) => OpenFolderRequestMessagePropInit(options),
				ConstructorParameterMetadataInitializer = OpenFolderRequestMessageCtorParamInit,
				ConstructorAttributeProviderFactory = () => typeof(OpenFolderRequestMessage).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[3]
				{
					typeof(string),
					typeof(string),
					typeof(bool)
				}, null),
				SerializeHandler = OpenFolderRequestMessageSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] OpenFolderRequestMessagePropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[3];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(OpenFolderRequestMessage),
			Converter = null,
			Getter = (object obj) => ((OpenFolderRequestMessage)obj).type,
			Setter = delegate
			{
				throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "type",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(OpenFolderRequestMessage).GetProperty("type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(OpenFolderRequestMessage),
			Converter = null,
			Getter = (object obj) => ((OpenFolderRequestMessage)obj).path,
			Setter = delegate
			{
				throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "path",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(OpenFolderRequestMessage).GetProperty("path", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<bool> propertyInfo3 = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(OpenFolderRequestMessage),
			Converter = null,
			Getter = (object obj) => ((OpenFolderRequestMessage)obj).isDirectory,
			Setter = delegate
			{
				throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "isDirectory",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(OpenFolderRequestMessage).GetProperty("isDirectory", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		return array;
	}

	private void OpenFolderRequestMessageSerializeHandler(Utf8JsonWriter writer, OpenFolderRequestMessage? value)
	{
		if ((object)value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_type, value.type);
		writer.WriteString(PropName_path, value.path);
		writer.WriteBoolean(PropName_isDirectory, value.isDirectory);
		writer.WriteEndObject();
	}

	private static JsonParameterInfoValues[] OpenFolderRequestMessageCtorParamInit()
	{
		return new JsonParameterInfoValues[3]
		{
			new JsonParameterInfoValues
			{
				Name = "type",
				ParameterType = typeof(string),
				Position = 0,
				HasDefaultValue = false,
				DefaultValue = null,
				IsNullable = false
			},
			new JsonParameterInfoValues
			{
				Name = "path",
				ParameterType = typeof(string),
				Position = 1,
				HasDefaultValue = false,
				DefaultValue = null,
				IsNullable = false
			},
			new JsonParameterInfoValues
			{
				Name = "isDirectory",
				ParameterType = typeof(bool),
				Position = 2,
				HasDefaultValue = false,
				DefaultValue = null,
				IsNullable = false
			}
		};
	}

	private JsonTypeInfo<StartFinishRequestMessage> Create_StartFinishRequestMessage(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<StartFinishRequestMessage> jsonTypeInfo))
		{
			JsonObjectInfoValues<StartFinishRequestMessage> objectInfo = new JsonObjectInfoValues<StartFinishRequestMessage>
			{
				ObjectCreator = null,
				ObjectWithParameterizedConstructorCreator = (object[] args) => new StartFinishRequestMessage((string)args[0], (bool)args[1]),
				PropertyMetadataInitializer = (JsonSerializerContext _) => StartFinishRequestMessagePropInit(options),
				ConstructorParameterMetadataInitializer = StartFinishRequestMessageCtorParamInit,
				ConstructorAttributeProviderFactory = () => typeof(StartFinishRequestMessage).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[2]
				{
					typeof(string),
					typeof(bool)
				}, null),
				SerializeHandler = StartFinishRequestMessageSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] StartFinishRequestMessagePropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[2];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(StartFinishRequestMessage),
			Converter = null,
			Getter = (object obj) => ((StartFinishRequestMessage)obj).type,
			Setter = delegate
			{
				throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "type",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(StartFinishRequestMessage).GetProperty("type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<bool> propertyInfo2 = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(StartFinishRequestMessage),
			Converter = null,
			Getter = (object obj) => ((StartFinishRequestMessage)obj).hasError,
			Setter = delegate
			{
				throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "hasError",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(StartFinishRequestMessage).GetProperty("hasError", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		return array;
	}

	private void StartFinishRequestMessageSerializeHandler(Utf8JsonWriter writer, StartFinishRequestMessage? value)
	{
		if ((object)value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_type, value.type);
		writer.WriteBoolean(PropName_hasError, value.hasError);
		writer.WriteEndObject();
	}

	private static JsonParameterInfoValues[] StartFinishRequestMessageCtorParamInit()
	{
		return new JsonParameterInfoValues[2]
		{
			new JsonParameterInfoValues
			{
				Name = "type",
				ParameterType = typeof(string),
				Position = 0,
				HasDefaultValue = false,
				DefaultValue = null,
				IsNullable = false
			},
			new JsonParameterInfoValues
			{
				Name = "hasError",
				ParameterType = typeof(bool),
				Position = 1,
				HasDefaultValue = false,
				DefaultValue = null,
				IsNullable = false
			}
		};
	}

	private JsonTypeInfo<int> Create_Int32(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<int> jsonTypeInfo))
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<int>(options, JsonMetadataServices.Int32Converter);
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<string> Create_String(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<string> jsonTypeInfo))
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<string>(options, JsonMetadataServices.StringConverter);
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<string[]> Create_StringArray(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<string[]> jsonTypeInfo))
		{
			JsonCollectionInfoValues<string[]> collectionInfo = new JsonCollectionInfoValues<string[]>
			{
				ObjectCreator = null,
				SerializeHandler = StringArraySerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateArrayInfo(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void StringArraySerializeHandler(Utf8JsonWriter writer, string[]? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartArray();
		for (int i = 0; i < value.Length; i++)
		{
			writer.WriteStringValue(value[i]);
		}
		writer.WriteEndArray();
	}

	public DesktopMessageJsonContext(JsonSerializerOptions options)
		: base(options)
	{
	}

	private static bool TryGetTypeInfoForRuntimeCustomConverter<TJsonMetadataType>(JsonSerializerOptions options, out JsonTypeInfo<TJsonMetadataType> jsonTypeInfo)
	{
		JsonConverter runtimeConverterForType = GetRuntimeConverterForType(typeof(TJsonMetadataType), options);
		if (runtimeConverterForType != null)
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<TJsonMetadataType>(options, runtimeConverterForType);
			return true;
		}
		jsonTypeInfo = null;
		return false;
	}

	private static JsonConverter? GetRuntimeConverterForType(Type type, JsonSerializerOptions options)
	{
		for (int i = 0; i < options.Converters.Count; i++)
		{
			JsonConverter jsonConverter = options.Converters[i];
			if (jsonConverter != null && jsonConverter.CanConvert(type))
			{
				return ExpandConverter(type, jsonConverter, options, validateCanConvert: false);
			}
		}
		return null;
	}

	private static JsonConverter ExpandConverter(Type type, JsonConverter converter, JsonSerializerOptions options, bool validateCanConvert = true)
	{
		if (validateCanConvert && !converter.CanConvert(type))
		{
			throw new InvalidOperationException($"The converter '{converter.GetType()}' is not compatible with the type '{type}'.");
		}
		if (converter is JsonConverterFactory jsonConverterFactory)
		{
			converter = jsonConverterFactory.CreateConverter(type, options);
			if (converter == null || converter is JsonConverterFactory)
			{
				throw new InvalidOperationException($"The converter '{jsonConverterFactory.GetType()}' cannot return null or a JsonConverterFactory instance.");
			}
		}
		return converter;
	}

	public override JsonTypeInfo? GetTypeInfo(Type type)
	{
		base.Options.TryGetTypeInfo(type, out JsonTypeInfo typeInfo);
		return typeInfo;
	}

	JsonTypeInfo? IJsonTypeInfoResolver.GetTypeInfo(Type type, JsonSerializerOptions options)
	{
		if (type == typeof(bool))
		{
			return Create_Boolean(options);
		}
		if (type == typeof(DesktopRequestMessage))
		{
			return Create_DesktopRequestMessage(options);
		}
		if (type == typeof(FileExploreRequestMessage))
		{
			return Create_FileExploreRequestMessage(options);
		}
		if (type == typeof(FileExploreResponseMessage))
		{
			return Create_FileExploreResponseMessage(options);
		}
		if (type == typeof(OpenFolderRequestMessage))
		{
			return Create_OpenFolderRequestMessage(options);
		}
		if (type == typeof(StartFinishRequestMessage))
		{
			return Create_StartFinishRequestMessage(options);
		}
		if (type == typeof(int))
		{
			return Create_Int32(options);
		}
		if (type == typeof(string))
		{
			return Create_String(options);
		}
		if (type == typeof(string[]))
		{
			return Create_StringArray(options);
		}
		return null;
	}
}
