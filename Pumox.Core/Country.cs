using System;
using Pumox.Core.Extensions;
using Pumox.Core.Shared;

namespace Pumox.Core
{
	public class Country : Entity
	{
		public string Name { get; private set; }

		public Country(Guid id, string name)
			: base(id)
		{
			if (name.IsEmpty())
				throw new ArgumentException("Country name is required.", nameof(name));

			Name = name;
		}
	}
}
