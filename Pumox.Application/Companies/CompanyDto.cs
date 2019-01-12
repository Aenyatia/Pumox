using Pumox.Application.Employees;
using System.Collections.Generic;

namespace Pumox.Application.Companies
{
	public class CompanyDto
	{
		public string Name { get; set; }
		public int EstablishmentYear { get; set; }
		public IEnumerable<EmployeeDto> Employees { get; set; }
	}
}
