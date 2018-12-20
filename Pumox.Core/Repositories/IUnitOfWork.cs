using System.Threading.Tasks;

namespace Pumox.Core.Repositories
{
	public interface IUnitOfWork
	{
		ICompanyRepository Companies { get; }

		Task Commit();
	}
}
