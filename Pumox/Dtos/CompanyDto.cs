using System.Collections.Generic;

namespace Pumox.Dtos
{
	public class CompanyDto
	{
		public string Name { get; set; }
		public int EstablishmentYear { get; set; }
		public IEnumerable<EmployeeDto> Employees { get; set; } = new HashSet<EmployeeDto>();
	}
}
