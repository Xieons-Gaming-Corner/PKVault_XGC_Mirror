using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

public class DesktopRequestMessage : IEquatable<DesktopRequestMessage>
{
	[CompilerGenerated]
	protected virtual Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(DesktopRequestMessage);
		}
	}

	public string type { get; init; }

	public DesktopRequestMessage(string type)
	{
		this.type = type;
		base._002Ector();
	}

	[CompilerGenerated]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("DesktopRequestMessage");
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
		return true;
	}

	[CompilerGenerated]
	public static bool operator !=(DesktopRequestMessage? left, DesktopRequestMessage? right)
	{
		return !(left == right);
	}

	[CompilerGenerated]
	public static bool operator ==(DesktopRequestMessage? left, DesktopRequestMessage? right)
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
		return EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(type);
	}

	[CompilerGenerated]
	public override bool Equals(object? obj)
	{
		return Equals(obj as DesktopRequestMessage);
	}

	[CompilerGenerated]
	public virtual bool Equals(DesktopRequestMessage? other)
	{
		if ((object)this != other)
		{
			if ((object)other != null && EqualityContract == other.EqualityContract)
			{
				return EqualityComparer<string>.Default.Equals(type, other.type);
			}
			return false;
		}
		return true;
	}

	[CompilerGenerated]
	protected DesktopRequestMessage(DesktopRequestMessage original)
	{
		type = original.type;
	}
}
