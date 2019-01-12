using System;

namespace Pumox.Application.Companies.Commands.Models
{
	public class CompanyEmployee
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string DateOfBirth { get; set; }
		public string JobTitle { get; set; }
	}
}
