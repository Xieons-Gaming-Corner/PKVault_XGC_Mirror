using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

public class FileExploreRequestMessage : IEquatable<FileExploreRequestMessage>
{
	[CompilerGenerated]
	protected virtual Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(FileExploreRequestMessage);
		}
	}

	public string type { get; init; }

	public int id { get; init; }

	public bool directoryOnly { get; init; }

	public string basePath { get; init; }

	public string title { get; init; }

	public bool multiselect { get; init; }

	public FileExploreRequestMessage(string type, int id, bool directoryOnly, string basePath, string title, bool multiselect)
	{
		this.type = type;
		this.id = id;
		this.directoryOnly = directoryOnly;
		this.basePath = basePath;
		this.title = title;
		this.multiselect = multiselect;
		base._002Ector();
	}

	[CompilerGenerated]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("FileExploreRequestMessage");
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
		builder.Append(", id = ");
		builder.Append(id.ToString());
		builder.Append(", directoryOnly = ");
		builder.Append(directoryOnly.ToString());
		builder.Append(", basePath = ");
		builder.Append((object?)basePath);
		builder.Append(", title = ");
		builder.Append((object?)title);
		builder.Append(", multiselect = ");
		builder.Append(multiselect.ToString());
		return true;
	}

	[CompilerGenerated]
	public static bool operator !=(FileExploreRequestMessage? left, FileExploreRequestMessage? right)
	{
		return !(left == right);
	}

	[CompilerGenerated]
	public static bool operator ==(FileExploreRequestMessage? left, FileExploreRequestMessage? right)
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
		return (((((EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(type)) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(id)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(directoryOnly)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(basePath)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(title)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(multiselect);
	}

	[CompilerGenerated]
	public override bool Equals(object? obj)
	{
		return Equals(obj as FileExploreRequestMessage);
	}

	[CompilerGenerated]
	public virtual bool Equals(FileExploreRequestMessage? other)
	{
		if ((object)this != other)
		{
			if ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(type, other.type) && EqualityComparer<int>.Default.Equals(id, other.id) && EqualityComparer<bool>.Default.Equals(directoryOnly, other.directoryOnly) && EqualityComparer<string>.Default.Equals(basePath, other.basePath) && EqualityComparer<string>.Default.Equals(title, other.title))
			{
				return EqualityComparer<bool>.Default.Equals(multiselect, other.multiselect);
			}
			return false;
		}
		return true;
	}

	[CompilerGenerated]
	protected FileExploreRequestMessage(FileExploreRequestMessage original)
	{
		type = original.type;
		id = original.id;
		directoryOnly = original.directoryOnly;
		basePath = original.basePath;
		title = original.title;
		multiselect = original.multiselect;
	}
}
