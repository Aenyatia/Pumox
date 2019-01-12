using System;
using Microsoft.EntityFrameworkCore;
using Pumox.Core.Domain;
using Pumox.Core.Specifications.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pumox.Core.Companies;

namespace Pumox.Infrastructure.EntityFramework.Repositories
{
	public sealed class CompanyRepository : ICompanyRepository
	{
		private readonly ApplicationDbContext _context;

		public CompanyRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Company> GetCompanyById(Guid id)
		{
			return await _context.Companies.SingleOrDefaultAsync(c => c.Id == id);
		}

		public async Task<IEnumerable<Company>> Get(Specification<Company> specification)
		{
			return await _context.Companies
				.Include(c => c.Employees)
				.Where(specification.ToExpression())
				.ToListAsync();
		}

		public async Task Add(Company company)
		{
			await _context.Companies.AddAsync(company);
		}

		public async Task Remove(Company company)
		{
			_context.Companies.Remove(company);

			await Task.CompletedTask;
		}
	}
}
