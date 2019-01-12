using Pumox.Core.Employees;
using Pumox.Core.Extensions;
using Pumox.Core.Shared;
using System;
using System.Collections.Generic;

namespace Pumox.Core.Companies
{
	public sealed class Company : Entity
	{
		private readonly ISet<Employee> _employees = new HashSet<Employee>();

		public string Name { get; private set; }
		public int EstablishmentYear { get; private set; }
		public DateTime CreatedAt { get; private set; }
		public DateTime UpdatedAt { get; private set; }

		public IEnumerable<Employee> Employees => _employees;

		public Company(Guid id, string name, int establishmentYear)
			: base(id)
		{
			Validate(name, establishmentYear);

			Name = name;
			EstablishmentYear = establishmentYear;
			CreatedAt = DateTime.UtcNow;
		}

		public void UpdateCompany(string name, int establishmentYear)
		{
			Validate(name, establishmentYear);

			Name = name;
			EstablishmentYear = establishmentYear;
			UpdatedAt = DateTime.UtcNow;
		}

		public void AddEmployee(Employee employee)
		{
			_employees.Add(employee);
		}

		public void SetEmployees(IEnumerable<Employee> employees)
		{
			if (employees == null)
				throw new ArgumentNullException(nameof(employees), "List of employees cannot be null.");

			_employees.Clear();

			foreach (var employee in employees)
				AddEmployee(employee);
		}

		private static void Validate(string name, int estabishmentYear)
		{
			if (name.IsEmpty())
				throw new Exception("Company name is required.");

			if (estabishmentYear <= 0)
				throw new ArgumentOutOfRangeException(nameof(estabishmentYear), "Establishment year should be greater then 0.");
		}
	}
}
