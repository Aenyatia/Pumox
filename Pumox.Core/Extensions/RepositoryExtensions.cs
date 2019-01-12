using Pumox.Core.Companies;
using System;
using System.Threading.Tasks;

namespace Pumox.Core.Extensions
{
	public static class RepositoryExtensions
	{
		public async static Task<Company> GetOrFail(this ICompanyRepository companyRepository, Guid id)
		{
			var company = await companyRepository.GetCompanyById(id);
			if (company == null)
				throw new Exception($"Company with id: '{id}' was not found.");

			return company;
		}
	}
}
