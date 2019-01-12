using System.Threading.Tasks;

namespace Pumox.Core.Companies
{
	public interface ICompanyService
	{
		Task Add(Company company);
	}
}
