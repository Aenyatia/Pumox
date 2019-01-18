using Microsoft.EntityFrameworkCore;
using Pumox.Core.Companies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

		public async Task<IEnumerable<Company>> GetAll()
		{
			return await _context.Companies.ToListAsync();
		}

		public async Task Add(Company company)
		{
			await _context.Companies.AddAsync(company);
			await _context.SaveChangesAsync();
		}

		public async Task Update(Company company)
		{
			_context.Companies.Update(company);
			await _context.SaveChangesAsync();
		}

		public async Task Remove(Company company)
		{
			_context.Companies.Remove(company);
			await _context.SaveChangesAsync();
		}
	}
}
