using Pumox.Application.Companies.Models;
using Pumox.Common.CQS.Commands;
using System;
using System.Collections.Generic;

namespace Pumox.Application.Companies.Commands
{
	public class CreateCompany : ICommand
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int EstablishmentYear { get; set; }
		public IEnumerable<CompanyEmployees> Employees { get; set; }
	}
}
