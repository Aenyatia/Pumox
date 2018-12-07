using Pumox.Domain;
using Pumox.Infrastructure.EntityFramework;
using Pumox.Specifications.Core;
using System.Collections.Generic;
using System.Linq;

namespace Pumox.Infrastructure.Repositories
{
	public class CompanyRepository : ICompanyRepository
	{
		private readonly ApplicationDbContext _context;

		public CompanyRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public Company GetCompanyById(long id)
		{
			return _context.Companies.SingleOrDefault(c => c.Id == id);
		}

		public IEnumerable<Company> Get(Specification<Company> specification)
		{
			return _context.Companies.Where(specification.ToExpression()).ToList();
		}

		public void Add(Company company)
		{
			_context.Companies.Add(company);
		}
	}
}
