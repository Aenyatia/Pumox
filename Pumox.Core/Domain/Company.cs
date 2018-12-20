using System.Collections.Generic;

namespace Pumox.Core.Domain
{
	public sealed class Company
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public int EstablishmentYear { get; set; }
		public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
	}
}
