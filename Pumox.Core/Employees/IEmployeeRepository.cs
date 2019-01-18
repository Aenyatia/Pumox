using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pumox.Core.Employees
{
	public interface IEmployeeRepository
	{
		Task<Employee> GetEmployeeById(Guid id);
		Task<IEnumerable<Employee>> GetAll();

		Task Add(Employee employee);
		Task Update(Employee employee);
		Task Delete(Employee employee);
	}
}
