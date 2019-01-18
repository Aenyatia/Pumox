using Microsoft.EntityFrameworkCore;
using Pumox.Core.Countries;
using System;
using System.Threading.Tasks;

namespace Pumox.Infrastructure.EntityFramework.Repositories
{
	public class CountryRepository : ICountryRepository
	{
		private readonly ApplicationDbContext _context;

		public CountryRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Country> GetCountryById(Guid id)
		{
			return await _context.Countries.SingleOrDefaultAsync(c => c.Id == id);
		}
	}
}
