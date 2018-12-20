using Pumox.CQS.Core.Command;

namespace Pumox.CQS.Commands
{
	public class DeleteCompanyCommand : ICommand
	{
		public long CompanyId { get; set; }
	}
}
