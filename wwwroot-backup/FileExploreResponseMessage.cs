using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

public class FileExploreResponseMessage : IEquatable<FileExploreResponseMessage>
{
	[CompilerGenerated]
	protected virtual Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(FileExploreResponseMessage);
		}
	}

	public string type { get; init; }

	public int id { get; init; }

	public bool directoryOnly { get; init; }

	public string[] values { get; init; }

	public FileExploreResponseMessage(string type, int id, bool directoryOnly, string[] values)
	{
		this.type = type;
		this.id = id;
		this.directoryOnly = directoryOnly;
		this.values = values;
		base._002Ector();
	}

	[CompilerGenerated]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("FileExploreResponseMessage");
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
		builder.Append(", values = ");
		builder.Append(values);
		return true;
	}

	[CompilerGenerated]
	public static bool operator !=(FileExploreResponseMessage? left, FileExploreResponseMessage? right)
	{
		return !(left == right);
	}

	[CompilerGenerated]
	public static bool operator ==(FileExploreResponseMessage? left, FileExploreResponseMessage? right)
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
		return (((EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(type)) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(id)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(directoryOnly)) * -1521134295 + EqualityComparer<string[]>.Default.GetHashCode(values);
	}

	[CompilerGenerated]
	public override bool Equals(object? obj)
	{
		return Equals(obj as FileExploreResponseMessage);
	}

	[CompilerGenerated]
	public virtual bool Equals(FileExploreResponseMessage? other)
	{
		if ((object)this != other)
		{
			if ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(type, other.type) && EqualityComparer<int>.Default.Equals(id, other.id) && EqualityComparer<bool>.Default.Equals(directoryOnly, other.directoryOnly))
			{
				return EqualityComparer<string[]>.Default.Equals(values, other.values);
			}
			return false;
		}
		return true;
	}

	[CompilerGenerated]
	protected FileExploreResponseMessage(FileExploreResponseMessage original)
	{
		type = original.type;
		id = original.id;
		directoryOnly = original.directoryOnly;
		values = original.values;
	}
}
