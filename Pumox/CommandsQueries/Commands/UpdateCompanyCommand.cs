using System.Collections.Generic;
using Pumox.CommandsQueries.Core.Command;
using Pumox.Domain;

namespace Pumox.CommandsQueries.Commands
{
	public class UpdateCompanyCommand : ICommand
	{
		public string Name { get; set; }
		public int EstablishmentYear { get; set; }
		public ICollection<Employee> Employees { get; set; }
	}
}
