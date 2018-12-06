using Pumox.CQRS.Core.Command;

namespace Pumox.CQRS.Commands
{
	public class DeleteCompanyCommand : ICommand
	{
		public long CompanyId { get; set; }
	}
}
