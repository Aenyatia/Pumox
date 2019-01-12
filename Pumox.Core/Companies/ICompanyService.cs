using Pumox.Core.Employees;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pumox.Core.Companies
{
	public interface ICompanyService
	{
		Task Add(Guid id, string name, int establishmentYear, IEnumerable<Employee> employees);
		Task Update(Guid id, string name, int establishmentYear, IEnumerable<Employee> employees);
		Task Delete(Guid id);
	}
}
