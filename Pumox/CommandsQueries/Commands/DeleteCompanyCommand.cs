using Pumox.CommandsQueries.Core.Command;

namespace Pumox.CommandsQueries.Commands
{
	public class DeleteCompanyCommand : ICommand
	{
		public long CompanyId { get; set; }
	}
}
