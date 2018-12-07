using Pumox.Specifications.Core;
using System.Collections.Generic;

namespace Pumox.Domain
{
	public interface ICompanyRepository
	{
		Company GetCompanyById(long id);
		IEnumerable<Company> Get(Specification<Company> specification);

		void Add(Company company);
		void Remove(Company company);
	}
}
