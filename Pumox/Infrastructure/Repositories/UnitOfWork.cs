using Pumox.Domain;
using Pumox.Infrastructure.EntityFramework;

namespace Pumox.Infrastructure.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
		public ICompanyRepository Companies { get; }

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;

			Companies = new CompanyRepository(_context);
		}

		public void Commit()
		{
			_context.SaveChanges();
		}
	}
}
