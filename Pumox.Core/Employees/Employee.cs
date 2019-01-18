using Pumox.Core.Extensions;
using Pumox.Core.Shared;
using System;

namespace Pumox.Core.Employees
{
	public sealed class Employee : Entity
	{
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public DateTime DateOfBirth { get; private set; }
		public JobTitle JobTitle { get; private set; }
		public Address Address { get; private set; }

		public DateTime CreatedAt { get; private set; }
		public DateTime UpdatedAt { get; private set; }

		public Employee(Guid id, string firstName, string lastName, DateTime dateOfBirth, JobTitle jobTitle)
			: base(id)
		{
			Validate(firstName, lastName, dateOfBirth);

			FirstName = firstName;
			LastName = lastName;
			DateOfBirth = dateOfBirth;
			JobTitle = jobTitle;

			CreatedAt = DateTime.UtcNow;
		}

		public void Update(string firstName, string lastName, DateTime dateOfBirth, JobTitle jobTitle)
		{
			Validate(firstName, lastName, dateOfBirth);

			FirstName = firstName;
			LastName = lastName;
			DateOfBirth = dateOfBirth;
			JobTitle = jobTitle;

			UpdatedAt = DateTime.UtcNow;
		}

		public void SetAddress(Address address)
		{
			if (address == null)
				throw new ArgumentNullException(nameof(address));

			if (Address == address)
				return;

			Address = address;
		}

		private static void Validate(string firstName, string lastName, DateTime dateOfBirth)
		{
			if (firstName.IsEmpty())
				throw new Exception("First name is required.");

			if (lastName.IsEmpty())
				throw new Exception("Last name is required.");

			if (dateOfBirth.Date > DateTime.UtcNow.Date)
				throw new ArgumentOutOfRangeException(nameof(dateOfBirth), "Invalid date of birth.");
		}
	}
}
