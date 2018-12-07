namespace Pumox.Domain
{
	public interface IUnitOfWork
	{
		ICompanyRepository Companies { get; }

		void Commit();
	}
}
