using System.Collections.Generic;

namespace Pumox.Application.Dtos
{
	public class CompanyDto
	{
		public string Name { get; set; }
		public int EstablishmentYear { get; set; }
		public IEnumerable<EmployeeDto> Employees { get; set; }
	}
}
