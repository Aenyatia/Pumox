using Pumox.Domain;
using System.Collections.Generic;

namespace Pumox.Commands
{
	public class UpdateCompany
	{
		public string Name { get; set; }
		public int EstablishmentYear { get; set; }
		public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
	}
}
