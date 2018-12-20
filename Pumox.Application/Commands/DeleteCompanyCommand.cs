using Pumox.Infrastructure.CQS.Commands;

namespace Pumox.Application.Commands
{
	public class DeleteCompanyCommand : ICommand
	{
		public long CompanyId { get; set; }
	}
}
