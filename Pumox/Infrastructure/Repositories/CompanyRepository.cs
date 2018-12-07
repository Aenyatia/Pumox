using Pumox.Domain;
using Pumox.Infrastructure.EntityFramework;

namespace Pumox.Infrastructure.Repositories
{
	public class CompanyRepository : ICompanyRepository
	{
		private readonly ApplicationDbContext _context;

		public CompanyRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public void Add(Company company)
		{
			_context.Companies.Add(company);
		}
	}
}
