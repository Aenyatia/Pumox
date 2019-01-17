using Pumox.Core.Extensions;
using Pumox.Core.Shared;
using System;
using System.Collections.Generic;

namespace Pumox.Core.Employees
{
	public class Address : ValueObject
	{
		public string Street { get; private set; }
		public string City { get; private set; }
		public Country Country { get; set; }

		private Address(string street, string city)
		{
			Street = street;
			City = city;
		}

		public static Address Create(string street, string city)
		{
			if (street.IsEmpty())
				throw new ArgumentException("Street is required.", nameof(street));

			if (city.IsEmpty())
				throw new ArgumentException("City is required.", nameof(city));

			return new Address(street, city);
		}

		public override IEnumerable<object> GetCompareProperties()
		{
			yield return Street;
			yield return City;
		}
	}
}
