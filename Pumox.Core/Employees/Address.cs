using Pumox.Core.Extensions;
using Pumox.Core.Shared;
using System;
using System.Collections.Generic;
using Pumox.Core.Countries;

namespace Pumox.Core.Employees
{
	public class Address : ValueObject
	{
		public string Street { get; private set; }
		public string City { get; private set; }
		public Country Country { get; private set; }

		private Address(string street, string city, Country country)
		{
			Street = street;
			City = city;
			Country = country;
		}

		public static Address Create(string street, string city, Country country)
		{
			if (street.IsEmpty())
				throw new ArgumentException("Street is required.", nameof(street));

			if (city.IsEmpty())
				throw new ArgumentException("City is required.", nameof(city));

			if (country == null)
				throw new ArgumentNullException(nameof(country));

			return new Address(street, city, country);
		}

		public override IEnumerable<object> GetCompareProperties()
		{
			yield return Street;
			yield return City;
			yield return Country;
		}
	}
}
