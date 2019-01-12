using System;
using Pumox.Core.Employees;

namespace Pumox.Application.Employees
{
	public class EmployeeDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public JobTitle JobTitle { get; set; }
	}
}
