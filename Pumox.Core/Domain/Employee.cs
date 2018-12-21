using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Pumox.Core.Domain
{
	public sealed class Employee : ValueObject
	{
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public DateTime DateOfBirth { get; private set; }
		public JobTitle JobTitle { get; private set; }

		private Employee(string firstName, string lastName, DateTime dateOfBirth, JobTitle jobTitle)
		{
			FirstName = firstName;
			LastName = lastName;
			DateOfBirth = dateOfBirth;
			JobTitle = jobTitle;
		}

		public static Result<Employee> Create(string firstName, string lastName, DateTime dateOfBirth, JobTitle jobTitle)
		{
			var errors = new List<string>();

			if (string.IsNullOrWhiteSpace(firstName))
				errors.Add(DomainError.FirstNameRequired);

			if (string.IsNullOrWhiteSpace(lastName))
				errors.Add(DomainError.LastNameRequired);

			if (dateOfBirth >= DateTime.Now)
				errors.Add(DomainError.InvalidBirthdate);

			return errors.Any()
				? Result.Fail<Employee>(errors)
				: Result.Ok(new Employee(firstName, lastName, dateOfBirth, jobTitle));
		}

		public override IEnumerable<object> GetProperties()
		{
			yield return FirstName;
			yield return LastName;
			yield return DateOfBirth;
			yield return JobTitle;
		}
	}
}
