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

		public Employee(Guid id, string firstName, string lastName, DateTime dateOfBirth, JobTitle jobTitle)
			: base(id)
		{
			FirstName = firstName;
			LastName = lastName;
			DateOfBirth = dateOfBirth;
			JobTitle = jobTitle;
		}
	}
}
