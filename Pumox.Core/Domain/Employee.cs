using System;

namespace Pumox.Core.Domain
{
	public sealed class Employee
	{
		public long Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public JobTitle JobTitle { get; set; }
	}
}
