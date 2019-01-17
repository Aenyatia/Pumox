using Pumox.Core.Extensions;
using System;

namespace Pumox.Core.Employees
{
	public class Country
	{
		public Guid Id { get; private set; }
		public string Name { get; private set; }

		public Country(Guid id, string name)
		{
			if (name.IsEmpty())
				throw new ArgumentException("Country name is required.", nameof(name));

			Id = id;
			Name = name;
		}
	}
}
