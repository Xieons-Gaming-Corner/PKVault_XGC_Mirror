using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

public class OpenFolderRequestMessage : IEquatable<OpenFolderRequestMessage>
{
	[CompilerGenerated]
	protected virtual Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(OpenFolderRequestMessage);
		}
	}

	public string type { get; init; }

	public string path { get; init; }

	public bool isDirectory { get; init; }

	public OpenFolderRequestMessage(string type, string path, bool isDirectory)
	{
		this.type = type;
		this.path = path;
		this.isDirectory = isDirectory;
		base._002Ector();
	}

	[CompilerGenerated]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("OpenFolderRequestMessage");
		stringBuilder.Append(" { ");
		if (PrintMembers(stringBuilder))
		{
			stringBuilder.Append(' ');
		}
		stringBuilder.Append('}');
		return stringBuilder.ToString();
	}

	[CompilerGenerated]
	protected virtual bool PrintMembers(StringBuilder builder)
	{
		RuntimeHelpers.EnsureSufficientExecutionStack();
		builder.Append("type = ");
		builder.Append((object?)type);
		builder.Append(", path = ");
		builder.Append((object?)path);
		builder.Append(", isDirectory = ");
		builder.Append(isDirectory.ToString());
		return true;
	}

	[CompilerGenerated]
	public static bool operator !=(OpenFolderRequestMessage? left, OpenFolderRequestMessage? right)
	{
		return !(left == right);
	}

	[CompilerGenerated]
	public static bool operator ==(OpenFolderRequestMessage? left, OpenFolderRequestMessage? right)
	{
		if ((object)left != right)
		{
			return left?.Equals(right) ?? false;
		}
		return true;
	}

	[CompilerGenerated]
	public override int GetHashCode()
	{
		return ((EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(type)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(path)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(isDirectory);
	}

	[CompilerGenerated]
	public override bool Equals(object? obj)
	{
		return Equals(obj as OpenFolderRequestMessage);
	}

	[CompilerGenerated]
	public virtual bool Equals(OpenFolderRequestMessage? other)
	{
		if ((object)this != other)
		{
			if ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(type, other.type) && EqualityComparer<string>.Default.Equals(path, other.path))
			{
				return EqualityComparer<bool>.Default.Equals(isDirectory, other.isDirectory);
			}
			return false;
		}
		return true;
	}

	[CompilerGenerated]
	protected OpenFolderRequestMessage(OpenFolderRequestMessage original)
	{
		type = original.type;
		path = original.path;
		isDirectory = original.isDirectory;
	}
}
