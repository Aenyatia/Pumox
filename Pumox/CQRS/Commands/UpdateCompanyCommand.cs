using Pumox.CQRS.Core.Command;
using Pumox.Domain;
using System.Collections.Generic;

namespace Pumox.CQRS.Commands
{
	public class UpdateCompanyCommand : ICommand
	{
		public string Name { get; set; }
		public int EstablishmentYear { get; set; }
		public ICollection<Employee> Employees { get; set; }
	}
}
