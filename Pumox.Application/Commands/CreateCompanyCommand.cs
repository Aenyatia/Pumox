using System;
using System.Collections.Generic;
using Pumox.Common.CQS.Commands;

namespace Pumox.Application.Commands
{
	public class CreateCompanyCommand : ICommand
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int EstablishmentYear { get; set; }
		public IEnumerable<CompanyEmployee> Employees { get; set; }

		public class CompanyEmployee
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string DateOfBirth { get; set; }
			public string JobTitle { get; set; }
		}
	}
}
