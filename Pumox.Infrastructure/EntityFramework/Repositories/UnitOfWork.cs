using Pumox.Core.Repositories;
using System.Threading.Tasks;

namespace Pumox.Infrastructure.EntityFramework.Repositories
{
	public sealed class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;

		// put here all repositories
		public ICompanyRepository Companies { get; }

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			Companies = new CompanyRepository(_context);
		}

		public async Task Commit()
		{
			await _context.SaveChangesAsync();
		}
	}
}
