using Microsoft.EntityFrameworkCore;
using System;

namespace Pumox.Domain
{
	[Owned]
	public class Employee
	{
		public long Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public JobTitle JobTitle { get; set; }
	}
}
