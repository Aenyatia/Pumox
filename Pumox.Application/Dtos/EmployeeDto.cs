using Pumox.Core.Domain;
using System;

namespace Pumox.Application.Dtos
{
	public class EmployeeDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public JobTitle JobTitle { get; set; }
	}
}
