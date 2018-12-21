using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Pumox.Core.Domain
{
	public sealed class Company : Entity
	{
		public string Name { get; private set; }
		public int EstablishmentYear { get; private set; }
		public ICollection<Employee> Employees { get; private set; }

		public Company(Guid id, string name, int establishmentYear, ICollection<Employee> employees)
			: base(id)
		{
			Name = name;
			EstablishmentYear = establishmentYear;
			Employees = employees;
		}

		public void UpdateCompany(string name, int establishmentYear, ICollection<Employee> employees)
		{
			Name = name;
			EstablishmentYear = establishmentYear;
			Employees = employees;
		}
	}
}
