using Pumox.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pumox.Commands
{
	public class CreateCompany
	{
		[Required]
		public string Name { get; set; }

		// from 0 to today year
		[Required]
		public int EstablishmentYear { get; set; }

		[Required]
		public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
	}
}
