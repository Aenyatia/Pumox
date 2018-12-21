using Pumox.Core.Domain;
using Pumox.Core.Repositories;
using Pumox.Core.Specifications.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pumox.Infrastructure.EntityFramework.Repositories
{
	public class Fake : ICompanyRepository
	{
		private static readonly ISet<Company> Companies = new HashSet<Company>();

		public Task<Company> GetCompanyById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Company>> Get(Specification<Company> specification)
		{
			throw new NotImplementedException();
		}

		public async Task Add(Company company)
		{
			Companies.Add(company);
			await Task.CompletedTask;
		}

		public Task Remove(Company company)
		{
			throw new NotImplementedException();
		}
	}
}
