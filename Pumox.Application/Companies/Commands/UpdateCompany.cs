using Pumox.Common.CQS.Commands;
using System;
using System.Collections.Generic;
using Pumox.Application.Companies.Commands.Models;

namespace Pumox.Application.Companies.Commands
{
	public class UpdateCompany : ICommand
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int EstablishmentYear { get; set; }
		public IEnumerable<CompanyEmployee> Employees { get; set; }
	}
}
