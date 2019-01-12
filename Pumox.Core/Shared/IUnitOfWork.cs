using Pumox.Core.Companies;
using Pumox.Core.Employees;
using System.Threading.Tasks;

namespace Pumox.Core.Shared
{
	public interface IUnitOfWork
	{
		ICompanyRepository Companies { get; }
		IEmployeeRepository Employees { get; }

		Task Commit();
	}
}
