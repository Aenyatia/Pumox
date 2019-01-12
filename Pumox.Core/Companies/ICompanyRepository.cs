using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pumox.Core.Companies
{
	public interface ICompanyRepository
	{
		Task<Company> GetCompanyById(Guid id);
		Task<IEnumerable<Company>> GetAll();

		Task Add(Company company);
		Task Update(Company company);
		Task Remove(Company company);
	}
}
