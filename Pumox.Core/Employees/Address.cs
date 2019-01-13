using Pumox.Core.Shared;
using System.Collections.Generic;

namespace Pumox.Core.Employees
{
	public class Address : ValueObject
	{
		public string Street { get; private set; }
		public string City { get; private set; }

		private Address(string street, string city)
		{
			Street = street;
			City = city;
		}

		public static Address Create(string street, string city)
		{
			return new Address(street, city);
		}

		public override IEnumerable<object> GetCompareProperties()
		{
			yield return Street;
			yield return City;
		}
	}
}
