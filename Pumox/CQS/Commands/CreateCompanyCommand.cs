using System.Collections.Generic;
using Pumox.CQS.Core.Command;
using Pumox.Domain;

namespace Pumox.CQS.Commands
{
	public class CreateCompanyCommand : ICommand
	{
		public string Name { get; set; }
		public int EstablishmentYear { get; set; }
		public ICollection<Employee> Employees { get; set; }
	}
}
