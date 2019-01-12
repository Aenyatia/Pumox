using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumox.Core.Shared
{
	public abstract class ValueObject
	{
		public abstract IEnumerable<object> GetCompareProperties();

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			if (obj.GetType() != GetType())
				return false;

			var otherObject = (ValueObject)obj;

			return otherObject.GetCompareProperties().SequenceEqual(GetCompareProperties());
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(GetCompareProperties());
		}

		public static bool operator ==(ValueObject left, ValueObject right)
		{
			if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
				return true;

			if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
				return false;

			return left.Equals(right);
		}

		public static bool operator !=(ValueObject left, ValueObject right)
		{
			return !(left == right);
		}
	}
}
