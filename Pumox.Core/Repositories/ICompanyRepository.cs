using System;
using Pumox.Core.Domain;
using Pumox.Core.Specifications.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pumox.Core.Repositories
{
	public interface ICompanyRepository
	{
		Task<Company> GetCompanyById(Guid id);
		Task<IEnumerable<Company>> Get(Specification<Company> specification);

		Task Add(Company company);
		Task Remove(Company company);
	}
}
