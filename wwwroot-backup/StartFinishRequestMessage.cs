using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

public class StartFinishRequestMessage : IEquatable<StartFinishRequestMessage>
{
	[CompilerGenerated]
	protected virtual Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(StartFinishRequestMessage);
		}
	}

	public string type { get; init; }

	public bool hasError { get; init; }

	public StartFinishRequestMessage(string type, bool hasError)
	{
		this.type = type;
		this.hasError = hasError;
		base._002Ector();
	}

	[CompilerGenerated]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("StartFinishRequestMessage");
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
		builder.Append(", hasError = ");
		builder.Append(hasError.ToString());
		return true;
	}

	[CompilerGenerated]
	public static bool operator !=(StartFinishRequestMessage? left, StartFinishRequestMessage? right)
	{
		return !(left == right);
	}

	[CompilerGenerated]
	public static bool operator ==(StartFinishRequestMessage? left, StartFinishRequestMessage? right)
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
		return (EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(type)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(hasError);
	}

	[CompilerGenerated]
	public override bool Equals(object? obj)
	{
		return Equals(obj as StartFinishRequestMessage);
	}

	[CompilerGenerated]
	public virtual bool Equals(StartFinishRequestMessage? other)
	{
		if ((object)this != other)
		{
			if ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(type, other.type))
			{
				return EqualityComparer<bool>.Default.Equals(hasError, other.hasError);
			}
			return false;
		}
		return true;
	}

	[CompilerGenerated]
	protected StartFinishRequestMessage(StartFinishRequestMessage original)
	{
		type = original.type;
		hasError = original.hasError;
	}
}
